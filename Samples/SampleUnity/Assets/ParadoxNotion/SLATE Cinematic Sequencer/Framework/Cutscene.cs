using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Slate{

	[DisallowMultipleComponent]
	public class Cutscene : MonoBehaviour, IDirector{

		public const float VERSION_NUMBER = 1.72f;

		///How the cutscene wraps
		public enum WrapMode{
			Once,
			Loop,
			PingPong
		}

		///What happens when cutscene stops
		public enum StopMode{
			Skip,
			Rewind,
			Hold,
			SkipRewindNoUndo
		}

		///Update modes for cutscene
		public enum UpdateMode{
			Normal,
			AnimatePhysics,
			UnscaledTime
		}

		///The direction the cutscene can play. An enum for clarity.
		public enum PlayingDirection{
			Forwards,
			Backwards
		}

		///Raised when any cutscene starts playing.
		public static event System.Action<Cutscene> OnCutsceneStarted;
		///Raised when any cutscene stops playing.
		public static event System.Action<Cutscene> OnCutsceneStopped;

		///Raised when a cutscene section has been reached.
		public event System.Action<Section> OnSectionReached;
		///Raised when a global message has been send by this cutscene.
		public event System.Action<string, object> OnGlobalMessageSend;
		
		//used internaly for a callback provided in Play
		private event System.Action OnStop;

		[SerializeField] [Tooltip("When is the cutscene updated.")]
		private UpdateMode _updateMode;
		[SerializeField] [Tooltip("How the cutscene wraps (relevant to runtime only)")]
		private WrapMode _defaultWrapMode;
		[SerializeField] [Tooltip("What will happen when the cutscene is stopped.")]
		private StopMode _defaultStopMode;
		[SerializeField] [Tooltip("The speed at which the cutscene is playing. Can be both positive or negative.")]
		private float _playbackSpeed = 1f;
		[SerializeField] [Tooltip("If enabled, you can set only some layers to be active for the duration of this cutscene.")]
		private bool _explicitActiveLayers;
		[SerializeField] [Tooltip("The layers to enable, all other layers will be disabled. Only affects gameobjects in the scene root.")]
		private LayerMask _activeLayers = -1;

		[HideInInspector]
		public List<CutsceneGroup> groups = new List<CutsceneGroup>();

		[SerializeField] [HideInInspector]
		private float _length = 20f;
		[SerializeField] [HideInInspector]
		private float _viewTimeMin = 0f;
		[SerializeField] [HideInInspector]
		private float _viewTimeMax = 21f;

		[System.NonSerialized]
		private float _currentTime;
		[System.NonSerialized]
		private float _playTimeStart;
		[System.NonSerialized]
		private float _playTimeEnd;
		[System.NonSerialized]
		private Transform _groupsRoot;
		[System.NonSerialized]
		private List<IDirectableTimePointer> timePointers;
		[System.NonSerialized]
		private List<IDirectableTimePointer> unsortedStartTimePointers;
		[System.NonSerialized]
		private Dictionary<GameObject, bool> affectedLayerGOStates;
		[System.NonSerialized]
		private static Dictionary<string, Cutscene> allSceneCutscenes = new Dictionary<string, Cutscene>();
		[System.NonSerialized]
		private bool preInitialized;
		[System.NonSerialized]
		private bool _isReSampleFrame;

		//The root on which groups are added for organization
		public Transform groupsRoot{
			get
			{
				if (_groupsRoot == null){
					_groupsRoot = transform.Find("__GroupsRoot__");
					if (_groupsRoot == null){
						_groupsRoot = new GameObject("__GroupsRoot__").transform;
						_groupsRoot.SetParent(this.transform);
					}

					#if UNITY_EDITOR
					_groupsRoot.gameObject.hideFlags = Prefs.showTransforms? 0 : HideFlags.HideInHierarchy;
					_groupsRoot.gameObject.SetActive(false); //we dont need it or children active
					#endif
				}

				return _groupsRoot;
			}
		}

		///When is the cutscene updated
		public UpdateMode updateMode{
			get {return _updateMode;}
			set {_updateMode = value;}
		}

		///How the cutscene wraps when playing by default
		public WrapMode defaultWrapMode{
			get {return _defaultWrapMode;}
			set {_defaultWrapMode = value;}
		}

		///What will happen when the cutscene is stopped by default
		public StopMode defaultStopMode{
			get {return _defaultStopMode;}
			set {_defaultStopMode = value;}
		}

		///Will active layers option be used?
		public bool explicitActiveLayers{
			get {return _explicitActiveLayers;}
			set {_explicitActiveLayers = value;}
		}

		///The layers that will be active when the cutscene is active. Everything else is disabled for the duration of the cutscene
		public LayerMask activeLayers{
			get {return _activeLayers;}
			set {_activeLayers = value;}
		}

		///The single Director Group of the cutscene
		public DirectorGroup directorGroup{
			get
			{
				//DirectorGroup should always be in index 0.
				if (groups.Count > 0 && groups[0] is DirectorGroup){
					return (DirectorGroup)groups[0];
				}
				//but it it's not, find it.
				return groups.Find( g => g is DirectorGroup) as DirectorGroup;
			}
		}

		///The single Camera Track of the cutscene
		public CameraTrack cameraTrack{
			get {return directorGroup.tracks.Find( t => t is CameraTrack ) as CameraTrack;}
		}

		///The current sample time
		public float currentTime{
			get{return _currentTime;}
			set{_currentTime = Mathf.Clamp(value, 0, length);}
		}

		///Total length
		public float length{
			get {return _length;}
			set {_length = Mathf.Max(value, 0.1f);}
		}

		//Min view time
		public float viewTimeMin{
			get {return _viewTimeMin;}
			set {if (viewTimeMax > 0) _viewTimeMin = Mathf.Min(value, viewTimeMax - 0.25f);}
		}

		//Max view time
		public float viewTimeMax{
			get {return _viewTimeMax;}
			set {_viewTimeMax = Mathf.Max(value, viewTimeMin + 0.25f, 0 );}
		}

		//The time the WrapMode is taking effect in runtime. Usually equal to 0.
		public float playTimeStart{
			get {return _playTimeStart;}
			set {_playTimeStart = Mathf.Clamp(value, 0, playTimeEnd);}
		}

		//The time the WrapMode is taking effect in runtime. Usually equal to length.
		public float playTimeEnd{
			get {return _playTimeEnd;}
			set {_playTimeEnd = Mathf.Clamp(value, playTimeStart, length);}
		}

		///The speed at which the cutscene is played back. Can be positive or negative. Not applicaple when Sampled manually without calling Play().
		public float playbackSpeed{
			get {return _playbackSpeed;}
			set {_playbackSpeed = value;}
		}

		///All directable elements within the cutscene
		public List<IDirectable> directables{get; private set;}

		///Is cutscene playing? (Note: it can be paused and isActive still be true)
		public bool isActive{get; private set;}
		
		///Is cutscene paused?
		public bool isPaused{get; private set;}

		///The direction the cutscene is playing if at all
		public PlayingDirection playingDirection{get; private set;}
		
		///The WrapMode the cutscene is currently using
		public WrapMode playingWrapMode{get; private set;}

		///The last sampled time
		public float previousTime{get; private set;}

		//internal use. will be true when Sampling due to ReSample call 
		bool IDirector.isReSampleFrame{get {return _isReSampleFrame;} }

		//internal use
		GameObject IDirector.context{get {return this.gameObject;}}

		///The remaining playing time.
		public float remainingTime{
			get
			{
				if (playingDirection == PlayingDirection.Forwards){
					return playTimeEnd - currentTime;
				}
				if (playingDirection == PlayingDirection.Backwards){
					return currentTime - playTimeStart;
				}
				return 0;
			}
		}


		//UNITY CALLBACK
		protected void Awake(){
			Validate();
			allSceneCutscenes[this.name] = this;
			if (directorGroup != null){
				directorGroup.OnSectionReached += SectionReached;
			}
		}

		//UNITY CALLBACK
		protected void OnDestroy(){
			StopAllCoroutines();
			isActive = false;
			allSceneCutscenes.Remove(this.name);
		}

		//A director section has been reached
		void SectionReached(Section section){
			SendGlobalMessage("OnSectionReached", section);
			if (OnSectionReached != null){
				OnSectionReached(section);
			}
		}

		///Get all affected actors within the groups of the cutscene
		public IEnumerable<GameObject> GetAffectedActors(){
			return groups.OfType<ActorGroup>().Select(g => g.actor);
		}

		///Get the key in/out time pointers of all directables
		public float[] GetKeyTimes(){
			if (timePointers == null){
				InitializeTimePointers();
			}
			return timePointers.Select(t => t.time).ToArray();
		}

		///Start or resume playing the cutscene at optional start time and optional provided callback for when it stops
		public void Play() { Play(0); }
		public void Play(System.Action callback){ Play(0, callback); }
		public void Play(float startTime){ Play(startTime, length, defaultWrapMode); }
		public void Play(float startTime, System.Action callback){ Play(startTime, length, defaultWrapMode, callback); }
		public void Play
			(
			float startTime,
			float endTime,
			WrapMode wrapMode = WrapMode.Once,
			System.Action callback = null,
			PlayingDirection playDirection = PlayingDirection.Forwards
			)
		{

			if (startTime > endTime && playDirection != PlayingDirection.Backwards){
				Debug.LogError("End Time must be greater than Start Time.", gameObject);
				return;
			}

			if (isPaused){ //if it's paused resume.
				Debug.LogWarning("Play called on a Paused cutscene. Cutscene will now resume instead.", gameObject);
				playingDirection = playDirection;
				Resume();
				return;
			}

			if (isActive){
				Debug.LogWarning("Cutscene is already Running.", gameObject);
				return;
			}

			playTimeStart    = 0; //for mathf.clamp setter

			playTimeEnd      = endTime;
			playTimeStart    = startTime;
			currentTime      = startTime;
			playingWrapMode  = wrapMode;
			playingDirection = playDirection;

			if (playDirection == PlayingDirection.Forwards){
				if (currentTime >= playTimeEnd){
					currentTime = playTimeStart;
				}
			}

			if (playDirection == PlayingDirection.Backwards){
				if (currentTime <= playTimeStart){
					currentTime = playTimeEnd;
				}
			}


			isActive = true;
			isPaused = false;
			OnStop   = callback != null? callback : OnStop;

			SendGlobalMessage("OnCutsceneStarted", this);
			if (OnCutsceneStarted != null){
				OnCutsceneStarted(this);
			}

			StartCoroutine(Internal_UpdateCutscene());
		}


		///Stops the cutscene completely.
		public void Stop(){ Stop(defaultStopMode); }
		public void Stop(StopMode stopMode){
		
			if (!isActive){
				Debug.LogWarning("Called Stop on a non-active cutscene", gameObject);
				return;
			}

			isActive = false;
			isPaused = false;

			if (stopMode == StopMode.Skip){
				Sample( playingDirection == PlayingDirection.Forwards? playTimeEnd : playTimeStart );
			}

			if (stopMode == StopMode.Rewind){
				Sample( playingDirection == PlayingDirection.Forwards? playTimeStart : playTimeEnd );
			}

			if (stopMode == StopMode.SkipRewindNoUndo){
				Sample( playingDirection == PlayingDirection.Forwards? playTimeEnd : playTimeStart );
				RewindNoUndo();
			}

			SendGlobalMessage("OnCutsceneStopped", this);
			if (OnCutsceneStopped != null){
				OnCutsceneStopped(this);
			}

			if (OnStop != null){
				OnStop();
			}
		}


		///Start or resume playing the cutscene at reverse, at optional new start time and optional provided callback for when it stops
		public void PlayReverse(){ PlayReverse(0, length); }
		public void PlayReverse(float startTime, float endTime){ Play(startTime, endTime, WrapMode.Once, null, PlayingDirection.Backwards); }
		///Pause the cutscene
		public void Pause(){ isPaused = true; }
		///Resume if cutscene was active
		public void Resume(){ isPaused = false;	}
		///Skip the cutscene to the end
		public void SkipAll(){ if (isActive) Stop(StopMode.Skip); else Sample(length); }
		///Rewind the cutscene to it's initial 0 time state
		public void Rewind(){ if (isActive) Stop(StopMode.Rewind); else Sample(0); }

		///Rewinds the cutscene to it's initial 0 time state without undoing anything, thus keeping current state as finalized.
		public void RewindNoUndo(){
			if (isActive){
				Stop(StopMode.Hold);
			}
			currentTime = playingDirection == PlayingDirection.Forwards? 0 : length;
			previousTime = currentTime; //this is why no undo is happening
			Sample();
		}

		[System.Obsolete("Use 'SkipCurrentSection' instead")]
		public void Skip(){SkipCurrentSection();}
		///Skip the cutscene time to the next Section or end time if none.
		public void SkipCurrentSection(){
			var forward = playingDirection == PlayingDirection.Forwards;
			var section = forward? directorGroup.GetSectionAfter(currentTime) : directorGroup.GetSectionBefore(currentTime);
			currentTime = section != null? section.time : (forward? length : 0);
		}


		////Set the cutscene time to a specific section by name
		public bool JumpToSection(string name){ return JumpToSection(GetSectionByName(name)); }
		public bool JumpToSection(Section section){
			if (section == null){
				Debug.LogError("Null Section Provided", gameObject);
				return false;
			}
			currentTime = section.time;
			return true;
		}


		///Start playing from a specific Section
		public bool PlayFromSection(string name){ return PlayFromSection(name, defaultWrapMode); }
		public bool PlayFromSection(string name, WrapMode wrap, System.Action callback = null){ return PlayFromSection(GetSectionByName(name), wrap, callback); }

		public bool PlayFromSection(Section section){ return PlayFromSection(section, defaultWrapMode); }
		public bool PlayFromSection(Section section, WrapMode wrap, System.Action callback = null){
			if (section == null){
				Debug.LogError("Null Section Provided", gameObject);
				return false;
			}
			Play(section.time, length, wrap, callback);
			return true;
		}


		///Play a specific Section only
		public bool PlaySection(string name){ return PlaySection(GetSectionByName(name), defaultWrapMode); }
		public bool PlaySection(string name, WrapMode wrap, System.Action callback = null){ return PlaySection(GetSectionByName(name), wrap, callback); }

		public bool PlaySection(Section section){ return PlaySection(section, defaultWrapMode); }
		public bool PlaySection(Section section, WrapMode wrap, System.Action callback = null){
			if (section == null){
				Debug.LogError("Null Section Provided", gameObject);
				return false;
			}
			var nextSection = directorGroup.GetSectionAfter(section.time);
			var endTime = nextSection != null? nextSection.time : length;
			Play(section.time, endTime, wrap, callback);
			return true;
		}



		///Sample cutscene state at time specified (currentTime by default)
		///You can call this however and whenever you like without any pre-requirements
		public void Sample(){ Sample(currentTime); }
		public void Sample(float time){

			currentTime = time;

			//ignore same minmax times
			if ( (currentTime == 0 || currentTime == length) && previousTime == currentTime ){
				return;
			}

			//Initialize time pointers if required.
			if (!preInitialized && currentTime > 0 && previousTime == 0){
				InitializeTimePointers();
			}

			//Sample started
			if (currentTime > 0 && currentTime < length && (previousTime == 0 || previousTime == length)){
				OnSampleStarted();
			}

			//Sample pointers
			if (timePointers != null){
				Internal_SamplePointers(currentTime, previousTime);
			}

			//Sample ended
			if ((currentTime == 0 || currentTime == length) && previousTime > 0 && previousTime < length){
				OnSampleEnded();
			}

			previousTime = currentTime;
		}

/*
		// *Personal Reminder.*
		void Internal_SuperSamplePointers(float time, float previousTime, int framerate){
			var sampleRate = (1f/framerate);
			if (time == previousTime || Mathf.Abs(time - previousTime) < sampleRate){
				Internal_SamplePointers(time, previousTime);
				return;
			}
			if (time > previousTime){
				for (var t = previousTime + sampleRate; t <= time + sampleRate; t += sampleRate ){
					var current = Mathf.Min( t, time );
					var previous = Mathf.Max( t - sampleRate, previousTime );
					Internal_SamplePointers(current, previous);
				}
			}
			if (time < previousTime){
				for (var t = previousTime - sampleRate; t >= time - sampleRate; t -= sampleRate ){
					var current = Mathf.Max( t, time );
					var previous = Mathf.Min( t + sampleRate, previousTime );
					Internal_SamplePointers(current, previous);
				}
			}
		}
*/

		//Samples the initialized pointers.
		void Internal_SamplePointers(float currentTime, float previousTime){
			//Update timePointers triggering forwards
			if (!Application.isPlaying || currentTime > previousTime){
				for (var i = 0; i < timePointers.Count; i++){
					try {timePointers[i].TriggerForward(currentTime, previousTime);}
					catch (System.Exception e){
						Debug.LogError(string.Format("{0}\n{1}", e.Message, e.StackTrace), gameObject);
						continue; //always continue
					}
				}
			}

			//Update timePointers triggering backwards
			if (!Application.isPlaying || currentTime < previousTime){
				for (var i = timePointers.Count-1; i >= 0; i--){
					try {timePointers[i].TriggerBackward(currentTime, previousTime);}
					catch (System.Exception e){
						Debug.LogError(string.Format("{0}\n{1}", e.Message, e.StackTrace), gameObject);
						continue; //always continue
					}
				}
			}

			//Update timePointers
			if (unsortedStartTimePointers != null){
				for (var i = 0; i < unsortedStartTimePointers.Count; i++){
					try {unsortedStartTimePointers[i].Update(currentTime, previousTime);}
					catch (System.Exception e){
						Debug.LogError(string.Format("{0}\n{1}", e.Message, e.StackTrace), gameObject);
						continue; //always continue
					}
				}
			}			
		}

		///Resamples cutscene. Useful when action settings have been changed
		public void ReSample(){

			if (Application.isPlaying){
				return;
			}

			if (currentTime > 0 && currentTime < length && timePointers != null){
				_isReSampleFrame = true;

				#if UNITY_EDITOR
				Dictionary<AnimatedParameter, CutsceneUtility.ChangedParameterCallbacks> cache = null;
				if (!Prefs.autoKey){
					cache = CutsceneUtility.changedParameterCallbacks.ToDictionary(e => e.Key, e => e.Value);
				}
				#endif

				Internal_SamplePointers(0, currentTime);
				Internal_SamplePointers(currentTime, 0);

				#if UNITY_EDITOR
				if (!Prefs.autoKey && cache != null){
					foreach (var pair in cache){ pair.Value.Restore(); }
				}
				#endif

				_isReSampleFrame = false;
			}
		}


		//Initialize the time pointers (in/out). Bottom to top.
		//Time pointers dectate all directables execution order. All pointers are collapsed into a list and ordered by their time.
		//Reverse() is used for in case pointers have same time. This is mostly true for groups and tracks.
		//(Group Enter -> Track Enter -> Clip Enter | Clip Exit -> Track Exit -> Group Exit)
		void InitializeTimePointers(){

			timePointers = new List<IDirectableTimePointer>();
			unsortedStartTimePointers = new List<IDirectableTimePointer>();

			foreach(IDirectable group in groups.AsEnumerable().Reverse()){
				if (group.isActive && group.Initialize()){
					var p1 = new StartTimePointer(group);
					timePointers.Add(p1);

					foreach (IDirectable track in group.children.Reverse()){
						if (track.isActive && track.Initialize()){
							var p2 = new StartTimePointer(track);
							timePointers.Add(p2);

							foreach(IDirectable clip in track.children){
								if (clip.isActive && clip.Initialize()){
									var p3 = new StartTimePointer(clip);
									timePointers.Add(p3);

									unsortedStartTimePointers.Add(p3);
									timePointers.Add(new EndTimePointer(clip));
								}
							}

							unsortedStartTimePointers.Add(p2);
							timePointers.Add(new EndTimePointer(track));
						}
					}

					unsortedStartTimePointers.Add(p1);
					timePointers.Add(new EndTimePointer(group));
				}
			}
			
			timePointers = timePointers.OrderBy(p => p.time).ToList();
		}


		//When Sample begins
		void OnSampleStarted(){
			SetLayersActive();
			DirectorGUI.current.enabled = true;
			for (var i = 0; i < directables.Count; i++){
				try { directables[i].RootEnabled(); }
				catch (System.Exception e) {
					Debug.LogError(string.Format("{0}\n{1}", e.Message, e.StackTrace), gameObject);
					continue; //always continue;
				}
			}
		}

		//When Sample ends
		void OnSampleEnded(){
			RestoreLayersActive();
			DirectorGUI.current.enabled = false;
			for (var i = 0; i < directables.Count; i++){
				try { directables[i].RootDisabled(); }
				catch (System.Exception e) {
					Debug.LogError(string.Format("{0}\n{1}", e.Message, e.StackTrace), gameObject);
					continue; //always continue;
				}				
			}
		}

		//use of active layers to toggle root object on or off during cutscene
		void SetLayersActive(){
			if (explicitActiveLayers){
				var rootObjects = this.gameObject.scene.GetRootGameObjects();
				affectedLayerGOStates = new Dictionary<GameObject, bool>();
				for (var i = 0; i < rootObjects.Length; i++){
					var o = rootObjects[i];
					affectedLayerGOStates[o] = o.activeInHierarchy;
					o.SetActive( (activeLayers.value & (1 << o.layer)) > 0 );
				}
			}
		}

		//restore layer object states.
		void RestoreLayersActive(){
			if (affectedLayerGOStates != null){
				foreach(var pair in affectedLayerGOStates){
					if (pair.Key != null){
						pair.Key.SetActive(pair.Value);
					}
				}
			}
		}


		//internal updater
		IEnumerator Internal_UpdateCutscene(){

			Sample(); //do a preliminary sample first at wherever the currentTime currently is at.

			while (isActive){

				while (isPaused){
					if (updateMode == UpdateMode.AnimatePhysics){
						yield return new WaitForFixedUpdate();
					}
					Sample(); //sample current time even while is paused
					yield return null;
				}

				if (!isActive){
					yield break;
				}

				if (updateMode == UpdateMode.AnimatePhysics){
					yield return new WaitForFixedUpdate();
				}


				var delta = Time.deltaTime;
				if (updateMode == UpdateMode.AnimatePhysics){
					delta = Time.fixedDeltaTime;
				}
				if (updateMode == UpdateMode.UnscaledTime){
					delta = Time.unscaledDeltaTime;
				}
				delta *= playbackSpeed;


				//update time
				currentTime += playingDirection == PlayingDirection.Forwards? delta : -delta;


				if (playingWrapMode == WrapMode.Once){
					if (currentTime >= playTimeEnd && playingDirection == PlayingDirection.Forwards){
						Stop();
						yield break;
					}

					if (currentTime <= playTimeStart && playingDirection == PlayingDirection.Backwards){
						Stop();
						yield break;
					}
				}

				if (playingWrapMode == WrapMode.Loop){
					if (currentTime >= playTimeEnd){
						currentTime = playTimeStart + float.Epsilon;
					}
					if (currentTime <= playTimeStart){
						currentTime = playTimeEnd - float.Epsilon;
					}
				}

				if (playingWrapMode == WrapMode.PingPong){
					if (currentTime >= playTimeEnd){
						currentTime = playTimeEnd - float.Epsilon;
						playingDirection = playbackSpeed >= 0? PlayingDirection.Backwards : PlayingDirection.Forwards;
					}
					if (currentTime <= playTimeStart){
						currentTime = playTimeStart + float.Epsilon;
						playingDirection = playbackSpeed >= 0? PlayingDirection.Forwards : PlayingDirection.Backwards;
					}
				}

				Sample();

				yield return null;
			}
		}



		///Gather and validate directables.
		///This is done in Awake as well as in editor when a directable is added or removed and OnValidate.
		public void Validate(){

#if SLATE_USE_EXPRESSIONS
			//flush exp enviroment before validating directables
			FlushExpressionEnvironment();
#endif

			if (groupsRoot.transform.parent != this.transform){	groupsRoot.transform.parent = this.transform; }

			directables = new List<IDirectable>();
			foreach(IDirectable group in groups.AsEnumerable().Reverse()){
				directables.Add(group);
				group.Validate(this, null);
				foreach(IDirectable track in group.children.Reverse()){
					directables.Add(track);
					track.Validate(this, group);
					foreach(IDirectable clip in track.children){
						directables.Add(clip);
						clip.Validate(this, track);
					}
				}
			}
		}


#if SLATE_USE_EXPRESSIONS
		///The root Environment used for expressions.
		///One is created when requested.
		private StagPoint.Eval.Environment expressionEnvironment;
		StagPoint.Eval.Environment IDirector.GetExpressionEnvironment(){
			if (expressionEnvironment != null){
				return expressionEnvironment;
			}

			expressionEnvironment = Slate.Expressions.GlobalEnvironment.Get().Push();
			Slate.Expressions.ExpressionCutsceneWrapper.Wrap(this, expressionEnvironment);
			return expressionEnvironment;
		}

		///Flush/Release the expressions environment
		void FlushExpressionEnvironment(){
			expressionEnvironment = null;
		}
#endif

		///Play a cutscene of specified name that exists either in the Resources folder or in the scene. In that order.
		public static Cutscene Play(string name){ return Play(name, null); }
		public static Cutscene Play(string name, System.Action callback){
			var cutscene = FindFromResources(name);
			if (cutscene != null){
				var instance = (Cutscene)Instantiate(cutscene);
				Debug.Log("Instantiating cutscene from Resources");
				instance.Play(()=>
				{
                    DeepCore.Unity3D.UnityHelper.Destroy(instance.gameObject);
					Debug.Log("Instantiated Cutscene Destroyed");
					if (callback != null){
						callback();
					}
				});
				return cutscene;
			}
			
			cutscene = Find(name);
			if (cutscene != null){
				cutscene.Play(callback);
				return cutscene;
			}

			return null;
		}

		///Find a cutscene from Resources folder
		public static Cutscene FindFromResources(string name){
			var go = Resources.Load(name, typeof(GameObject)) as GameObject;
			if (go != null){
				var cut = go.GetComponent<Cutscene>();
				if (cut != null){
					return cut;
				}
			}
			Debug.LogWarning(string.Format("Cutscene of name '{0}' does not exists in the Resources folder", name));
			return null;
		}

		///Find a cutscene of specified name that exists in the scene
		public static Cutscene Find(string name){
			Cutscene cutscene = null;
			if (allSceneCutscenes.TryGetValue(name, out cutscene)){
				return cutscene;
			}
			Debug.LogError(string.Format("Cutscene of name '{0}' does not exists in the scene", name));
			return null;
		}
	
		///Sends a message to all affected gameObject actors (including Director Camera), as well as the cutscene gameObject itself.
		public void SendGlobalMessage(string message, object value = null){
			this.gameObject.SendMessage(message, SendMessageOptions.DontRequireReceiver);
			foreach(var actor in GetAffectedActors()){
				if (actor != null){
					actor.SendMessage(message, SendMessageOptions.DontRequireReceiver);
				}
			}

			if (OnGlobalMessageSend != null){
				OnGlobalMessageSend(message, value);
			}

			#if UNITY_EDITOR
			Debug.Log(string.Format("<b>({0}) Global Message Send:</b> '{1}' ({2})", name, message, value), gameObject);
			#endif
		}

		///Set the target actor of an Actor Group by the group's name.
		public void SetGroupActorOfName(string groupName, GameObject newActor){
			
			if (currentTime > 0){
				Debug.LogError("Setting a Group Actor is only allowed when the Cutscene is not active and is rewinded", gameObject);
				return;				
			}

			var group = groups.OfType<ActorGroup>().FirstOrDefault( g => g.name.ToLower() == groupName.ToLower() );
			if (group == null){
				Debug.LogError(string.Format("Actor Group with name '{0}' doesn't exist in cutscene", groupName), gameObject);
				return;
			}

			group.actor = newActor;
		}

		//...
		public override string ToString(){
			return string.Format("'{0}' Cutscene", name);
		}


		///Get a section by name
		public Section GetSectionByName(string name){
			return directorGroup.GetSectionByName(name);
		}

		///Get a section by UID
		public Section GetSectionByUID(string UID){
			return directorGroup.GetSectionByUID(UID);
		}

		///All section names of the DirectorGroup
		public Section[] GetSections(){
			return directorGroup.sections.ToArray();
		}

		///Returns a named section's length
		public float GetSectionLength(string name){
			var section = directorGroup.GetSectionByName(name);
			if (section != null){
				var nextSection = directorGroup.GetSectionAfter(section.time);
				return nextSection != null? nextSection.time - section.time : length - section.time;
			}
			return -1;
		}

		///All section names of the DirectorGroup
		public string[] GetSectionNames(){
			return directorGroup.sections.Select(s => s.name).ToArray();
		}

		///Get all names of SendGlobalMessage ActionClips
		public string[] GetDefinedEventNames(){
			var result = new List<string>();
			foreach(var track in directorGroup.tracks.OfType<DirectorActionTrack>()){
				foreach(var clip in track.actions.OfType<Slate.ActionClips.SendGlobalMessage>()){
					result.Add(clip.message);
				}
			}
			return result.ToArray();
		}

		///By default cutscene is initialized when it starts playing.
		///You can pre-initialize it if you want so for performance in case there is any lag when cutscene is started.
		public void PreInitialize(){
			InitializeTimePointers();
			preInitialized = true;
		}

		
		///Render the cutscene to an image sequence in runtime and get a Texture2D[] of the rendered frames.
		///This operation will take several frames to complete. Use the callback parameter to get the result when rendering is done.
		public void RenderCutscene(int width, int height, int frameRate, System.Action<Texture2D[]> Callback){
			
			if (!Application.isPlaying){
				Debug.LogError("Rendering Cutscene with RenderCutscene function is only meant for runtime", this);
				return;
			}

			if (isActive){
				Debug.LogWarning("You called RenderCutscene to an actively playing Cutscene. The cutscene will now Stop.", this);
				Stop();
			}

			StartCoroutine(Internal_RenderCutscene(width, height, frameRate, Callback));
		}

		//runtime rendering to Texture2D[]
		IEnumerator Internal_RenderCutscene(int width, int height, int frameRate, System.Action<Texture2D[]> Callback){
			var renderSequence = new List<Texture2D>();
			var sampleRate = 1f/frameRate;
			for (var i = sampleRate; i <= length; i += sampleRate){
				Sample(i);
				yield return new WaitForEndOfFrame();
				var texture = new Texture2D(width, height, TextureFormat.RGB24, false);
				texture.ReadPixels(new Rect(0, 0, width, height), 0, 0);
				texture.Apply();
				renderSequence.Add(texture);
			}
			Callback(renderSequence.ToArray());
		}

		////////////////////////////////////////
		///////////GUI AND EDITOR STUFF/////////
		////////////////////////////////////////
		#if UNITY_EDITOR

		[ContextMenu("Reset")] //override
		void Reset(){ ClearAll(); }
		[ContextMenu("Copy Component")] //override
		void CopyComponent(){}
		[ContextMenu("Remove Component")] //override
		void RemoveComponent(){	Debug.LogWarning("Removing the Cutscene Component is not possible. Please delete the GameObject instead");	}
		[ContextMenu("Show Transforms")]
		void ShowTransforms(){ Prefs.showTransforms = true; groupsRoot.hideFlags = HideFlags.None; }
		[ContextMenu("Hide Transforms")]
		void HideTransforms(){ Prefs.showTransforms = false; groupsRoot.hideFlags = HideFlags.HideInHierarchy; }

		protected void OnValidate(){
			if (!Application.isPlaying && !UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode){
				Validate();
			}
		}

		protected void OnDrawGizmos(){
			var l = Prefs.gizmosLightness;
			Gizmos.color = new Color(l,l,l);
			Gizmos.DrawSphere(transform.position, 0.025f);
			Gizmos.color = Color.white;
			Gizmos.DrawIcon(transform.position, "Cutscene Gizmo");
			for (var i = 0; i < directables.Count; i++){
				var directable = directables[i];
				directable.DrawGizmos( CutsceneUtility.selectedObject == directable );
			}
		}


		public static Cutscene Create(Transform parent = null){
			var cutscene = new GameObject("Cutscene").AddComponent<Cutscene>();
			if (parent != null){
				cutscene.transform.SetParent(parent, false);
			}
			cutscene.transform.localPosition = Vector3.zero;
			cutscene.transform.localRotation = Quaternion.identity;
			return cutscene;
		}

		///Add a group to the cutscene.
		public T AddGroup<T>(GameObject targetActor = null) where T:CutsceneGroup{ return (T)AddGroup(typeof(T), targetActor); }
		public CutsceneGroup AddGroup(System.Type type, GameObject targetActor = null){
			
			if (!type.IsSubclassOf(typeof(CutsceneGroup)) || type.IsAbstract ){
				return null;
			}

			if (type == typeof(DirectorGroup) && directorGroup != null){
				Debug.LogWarning("A Cutscene can only contain one Director Group", this);
				return directorGroup;
			}

			var newGroup = new GameObject(type.Name).AddComponent(type) as CutsceneGroup;
			UnityEditor.Undo.RegisterCreatedObjectUndo(newGroup.gameObject, "Add Group");
			UnityEditor.Undo.SetTransformParent(newGroup.transform, groupsRoot, "Add Group");
			UnityEditor.Undo.RegisterCompleteObjectUndo(this, "Add Group");
			newGroup.transform.localPosition = Vector3.zero;
			newGroup.actor = targetActor;
			groups.Add(newGroup);
			Validate();

			if (type != typeof(DirectorGroup) && targetActor != null){
				if (targetActor.GetComponent<Animator>() != null){
					newGroup.AddTrack<AnimatorTrack>();
				}
				if (targetActor.GetComponent<Animation>() != null){
					newGroup.AddTrack<AnimationTrack>();
				}
			}

			CutsceneUtility.selectedObject = newGroup;
			return newGroup;
		}

		///Duplicate a group in the cutscene.
		public CutsceneGroup DuplicateGroup(CutsceneGroup group, GameObject targetActor = null){
			
			if (group == null || (group is DirectorGroup) ){
				return null;
			}

			var newGroup = (CutsceneGroup)Instantiate(group);
			UnityEditor.Undo.RegisterCreatedObjectUndo(newGroup.gameObject, "Duplicate Group");
			UnityEditor.Undo.SetTransformParent(newGroup.transform, groupsRoot, "Duplicate Group");
			UnityEditor.Undo.RegisterCompleteObjectUndo(this, "Duplicate Group");
			newGroup.actor = targetActor;
			newGroup.transform.localPosition = Vector3.zero;
			groups.Add(newGroup);
			Validate();
			CutsceneUtility.selectedObject = newGroup;
			return newGroup;
		}

		///Delete a group from the cutscene.
		public void DeleteGroup(CutsceneGroup group){
			
			if (group is DirectorGroup){
				Debug.LogWarning("The Director Group can't be removed from the Cutscene", gameObject);
				return;
			}

			UnityEditor.Undo.RegisterCompleteObjectUndo(this, "Delete Group");
			groups.Remove(group);
			Validate();
			UnityEditor.Undo.DestroyObjectImmediate(group.gameObject);
		}


		public void ClearAll(){
			
			if (_groupsRoot != null){
				Sample(0); //rewind first
				UnityEditor.Undo.RegisterFullObjectHierarchyUndo(gameObject, "Clear Cutscene");
				foreach(var group in groups.ToArray()){
					UnityEditor.Undo.DestroyObjectImmediate(group.gameObject);
				}
				groups.Clear();
			}

			var directorGroup = AddGroup<DirectorGroup>();
			directorGroup.AddTrack<CameraTrack>();
			directorGroup.AddTrack<DirectorAudioTrack>();
			directorGroup.AddTrack<DirectorActionTrack>();
			CutsceneUtility.selectedObject = null;
			length = 20;
			viewTimeMin = -1;
			viewTimeMax = 21;
		}

		#endif
	}
}