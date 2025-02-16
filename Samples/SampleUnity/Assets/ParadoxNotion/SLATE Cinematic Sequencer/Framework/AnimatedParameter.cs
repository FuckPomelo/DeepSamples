﻿using UnityEngine;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System;

namespace Slate{

	///Defines a parameter (property/field) that can be animated
	[System.Serializable]
	public class AnimatedParameter : IAnimatableData{

		///Used for storing the meta data
		[System.Serializable]
		class SerializationMetaData{
			public bool enabled = true;
			public string parameterName;
			public string declaringTypeName;
			public string transformHierarchyPath;
			public ParameterType parameterType;

			public Type declaringType{get;private set;}
			public PropertyInfo property{get;private set;}
			public FieldInfo field{get;private set;}
			public Type animatedType{get;private set;}
			public void Deserialize(){
				declaringType = ReflectionTools.GetType(declaringTypeName);
				if (declaringType != null){
					property      = declaringType.RTGetProperty(parameterName);
					field         = declaringType.RTGetField(parameterName);
					animatedType  = property != null? property.PropertyType : field != null? field.FieldType : null;
				}
			}
		}

		///The type of the parameter.
		///This is an enum in case more are added.
		public enum ParameterType{
			NotSet,
			Property,
			Field
		}

		///This event is raised when a parameter is changed with argument being the IAnimatableData parameter.
		public static event System.Action<IAnimatableData> onParameterChanged;
		//used to compare values are same
		private const float COMPARE_THRESHOLD = 0.001f;
		//used to seperate keyframes
		private const float PROXIMITY_TOLERANCE = 1f/30;

		[SerializeField]
		private string _serializedData;
		[SerializeField]
		private AnimationCurve[] _curves;
		[SerializeField]
		private string _scriptExpression;

		///Is the parameter enabled and will be used?
		public bool enabled{
			get {return data.enabled;}
		}

		///Set the parameter enabled/disabled
		public void SetEnabled(bool value, float time){
			if (enabled != value){
				RecordUndo();
				data.enabled = value;
				serializedData = JsonUtility.ToJson(data);
				if (snapshot != null){
					if (value == false){ //revert
						SetCurrentValue(snapshot);
					}
					if (value == true){ //evaluate
						Evaluate(time, 0);
					}
				}
				NotifyChange();
			}
		}

		//Serialized json data
		private string serializedData{
			get {return _serializedData;}
			set {_serializedData = value;}
		}

		//Serialization structure
		[System.NonSerialized]
		private SerializationMetaData _data;
		private SerializationMetaData data{
			get
			{
				if (_data != null){
					return _data;
				}

				_data = JsonUtility.FromJson<SerializationMetaData>(serializedData);
				_data.Deserialize();
				return _data;
			}
		}

		///The animation curves of the parameter
		public AnimationCurve[] curves{
			get {return _curves;}
			private set {_curves = value;}
		}

		///The script expression used if any
		public string scriptExpression{
			get {return _scriptExpression;}
			set
			{
				if (_scriptExpression != value){
					RecordUndo();
					_scriptExpression = value;
					#if SLATE_USE_EXPRESSIONS
					CompileExpression();
					#endif
				}
			}
		}


		///Get the meta info from the deserialized data. These are basicaly shortcuts
		public string parameterName {get {return data.parameterName;}}
		public Type animatedType{ get {return data.animatedType;} }
		public ParameterType parameterType{ get {return data.parameterType;} }
		public string transformHierarchyPath{ get {return data.transformHierarchyPath;} }
		public Type declaringType{	get	{return data.declaringType;} }
		public PropertyInfo property{ get {return data.property; } }
		public FieldInfo field{ get {return data.field; } }
		public bool isProperty{ get {return parameterType == ParameterType.Property;} }
		///

		///The IKeyable reference this parameters belongs to
		public IKeyable keyable {get; private set;}
		///The snapshot value before evaluation
		public object snapshot {get; private set;}
		///The last evaluated value. Mostly used to check value changes
		public object currentEval {get; private set;}
		///Used to virtualy parent transform based parameters if not null
		public Transform virtualTransformParent {get; private set;}

#if SLATE_USE_EXPRESSIONS
		///The compiled expression if any
		public StagPoint.Eval.Expression compiledExpression {get; private set;}
		///The compile exception if any
		public System.Exception compileException{get; private set;}
#endif

		///The animation target object (fetched from IKeyable reference)
		public object targetObject{
			get {return keyable != null? keyable.animatedParametersTarget : null;}
		}

		///The types supported for animation
		public static readonly Type[] supportedTypes = new Type[]{
			typeof(bool),
			typeof(int),
			typeof(float),
			typeof(Vector2),
			typeof(Vector3),
			typeof(Color)
		};

		[System.NonSerialized]
		private object _animatableAttribute; ///Cache of possible [AnimatableParameter] attribute used for creating this parameter
		public AnimatableParameterAttribute animatableAttribute{
			get
			{
				if (_animatableAttribute == null){
					var m = GetMemberInfo();
					if (m == null){	return null; }
					var att = m.RTGetAttribute<AnimatableParameterAttribute>(true);
					_animatableAttribute = att != null? att : new object();
				}
				return _animatableAttribute as AnimatableParameterAttribute;
			}
		}

		///External means that the parameter was not created by the use of [AnimatableParameter] attribute, but rather added manually.
		public bool isExternal{
			get	{ return animatableAttribute == null; }
		}
	
		///shortcuts for curves
		private AnimationCurve curve1{
			get {return curves[0];}
			set {curves[0] = value;}
		}
		private AnimationCurve curve2{
			get {return curves[1];}
			set {curves[1] = value;}
		}
		private AnimationCurve curve3{
			get {return curves[2];}
			set {curves[2] = value;}
		}
		private AnimationCurve curve4{
			get {return curves[3];}
			set {curves[3] = value;}
		}
		////

		///Is all good to go?
		public bool isValid{
			get
			{
				if (string.IsNullOrEmpty(serializedData) || data == null){
					return false;
				}
				return isProperty? property != null : field != null;
			}
		}

		///The PropertyInfo or FieldInfo used
		public MemberInfo GetMemberInfo(){
			if (isValid){
				return isProperty? (MemberInfo)property : (MemberInfo)field;
			}
			return null;
		}


		///The curves used
		public AnimationCurve[] GetCurves(){
			return curves;
		}

		///Creates a new animated parameter out of a member info that optionaly exists on a component in child transform of root transform.
		public AnimatedParameter(MemberInfo member, IKeyable keyable, Transform child, Transform root){
			this.keyable = keyable;
			if (member is PropertyInfo){
				ConstructWithProperty( (PropertyInfo)member, child, root);
				return;
			}
			if (member is FieldInfo){
				ConstructWithField( (FieldInfo)member, child, root);
				return;
			}
			Debug.LogError("MemberInfo provided is neither Property nor Field");
		}

		//construct with PropertyInfo
		void ConstructWithProperty(PropertyInfo targetProperty, Transform child, Transform root){

			if ( !supportedTypes.Contains(targetProperty.PropertyType) ){
				Debug.LogError(string.Format("Type '{0}' is not supported for animation", targetProperty.PropertyType) );
				return;				
			}

			if (!targetProperty.CanRead || !targetProperty.CanWrite){
				Debug.LogError("Animated Property must be able to both read and write");
				return;
			}

			if (targetProperty.RTGetGetMethod().IsStatic){
				Debug.LogError("Static Properties are not supported");
				return;
			}

			var newData               = new SerializationMetaData();
			newData.parameterType     = ParameterType.Property;
			newData.parameterName     = targetProperty.Name;
			newData.declaringTypeName = targetProperty.RTReflectedType().FullName;

			if (child != null && root != null){
				newData.transformHierarchyPath = CalculateTransformPath( root, child );
			}

			serializedData = JsonUtility.ToJson(newData);
			InitializeCurves();
		}

		//construct with FieldInfo
		void ConstructWithField(FieldInfo targetField, Transform child, Transform root){

			if ( !supportedTypes.Contains(targetField.FieldType) ){
				Debug.LogError(string.Format("Type '{0}' is not supported for animation", targetField.FieldType) );
				return;
			}

			if (targetField.IsStatic){
				Debug.LogError("Static Fields are not supported");
				return;
			}

			var newData               = new SerializationMetaData();
			newData.parameterType     = ParameterType.Field;
			newData.parameterName     = targetField.Name;
			newData.declaringTypeName = targetField.RTReflectedType().FullName;

			if (child != null && root != null){
				newData.transformHierarchyPath = CalculateTransformPath( root, child );
			}

			serializedData = JsonUtility.ToJson(newData);
			InitializeCurves();
		}


		///Returns true if this animated parameter points to the same property/field as the provided one does.
		public bool CompareTo(AnimatedParameter animParam){
			if (parameterName == animParam.parameterName &&
				declaringType == animParam.declaringType &&
				transformHierarchyPath == animParam.transformHierarchyPath)
			{
				return true;
			}
			return false;
		}


		string CalculateTransformPath(Transform root, Transform child){
			var path = new List<string>();
			var curr = child;
			while(curr != root && curr != null){
				path.Add(curr.name);
				curr = curr.parent;
			}
			path.Reverse();
			return string.Join("/", path.ToArray());
		}

		Transform ResolveTransformPath(Transform root){
			var transform = root;
			foreach(var tName in transformHierarchyPath.Split('/')){
				transform = transform.Find(tName);
				if (transform == null){
					return null;
				}
			}
			return transform;
		}

		void InitializeCurves(){

			if (animatedType == typeof(bool)){
				curves = new AnimationCurve[1];
				curve1 = new AnimationCurve();
				return;
			}
			if (animatedType == typeof(int)){
				curves = new AnimationCurve[1];
				curve1 = new AnimationCurve();
				return;
			}
			if (animatedType == typeof(float)){
				curves = new AnimationCurve[1];
				curve1 = new AnimationCurve();
				return;
			}
			if (animatedType == typeof(Vector2)){
				curves = new AnimationCurve[2];
				curve1 = new AnimationCurve();
				curve2 = new AnimationCurve();
				return;
			}
			if (animatedType == typeof(Vector3)){
				curves = new AnimationCurve[3];
				curve1 = new AnimationCurve();
				curve2 = new AnimationCurve();
				curve3 = new AnimationCurve();
				return;
			}
			if (animatedType == typeof(Color)){
				curves = new AnimationCurve[4];
				curve1 = new AnimationCurve();
				curve2 = new AnimationCurve();
				curve3 = new AnimationCurve();
				curve4 = new AnimationCurve();
				return;
			}

			Debug.LogError(string.Format("Parameter Type '{0}' is not supported", animatedType.Name));
		}






		///Validate the parameter within the context of provided keyable reference
		public void Validate(IKeyable keyable){
			this.keyable = keyable;
			#if SLATE_USE_EXPRESSIONS
			CompileExpression();
			#endif
		}


		///Set the virtual parent for transform based parameters
		public void SetVirtualTransformParent(Transform virtualTransformParent){
			this.virtualTransformParent = virtualTransformParent;
		}

		///Store a snapshot for restoring later.
		public void SetSnapshot(){

			if (!isValid){
				return;
			}

			//always save snapshot even if disabled for in case it get's enabled
			snapshot = GetCurrentValue();
			currentEval = snapshot;
		}

		///Try to add new key if the value has changed
		public bool TryAutoKey(float time){

			if (!isValid || !enabled){
				return false;
			}

			if (!HasAnyKey() && !isExternal){
				return false;
			}

			if (HasChanged()){
				SetKeyCurrent(time);
				return true;
			}

			return false;
		}

		///Sets the final evaluated value at time on the target
		public void Evaluate(float time, float previousTime, float weight = 1){

			//evaluate curves first
			if (!Application.isPlaying){
				#if UNITY_EDITOR
				Internal_Evaluate_Editor(time, previousTime, weight);
				#endif
			} else {
				Internal_Evaluate_Runtime(time, previousTime, weight);
			}


#if SLATE_USE_EXPRESSIONS
			//evaluate expression second
			if (compiledExpression != null){
				var xpValue = compiledExpression.Execute();
				if (xpValue.GetType() == typeof(object[])){
					xpValue = ArrayToValue( (object[])xpValue );
				}
				currentEval = xpValue;
				SetCurrentValue(xpValue);
			}
#endif

		}

		///Restore the snapshot on the target
		public void RestoreSnapshot(){

			if (!isValid || !enabled){
				return;
			}

			if (snapshot != null){
				if (isExternal){
					SetCurrentValue(snapshot);
				}
			}

			currentEval = null;
			snapshot = null;
		}

#if SLATE_USE_EXPRESSIONS
		private StagPoint.Eval.Environment expressionEnvironment;
		public StagPoint.Eval.Environment GetExpressionEnvironment(){
			if (expressionEnvironment != null){
				return expressionEnvironment;
			}
			expressionEnvironment = keyable.GetExpressionEnvironment().Push();
			Slate.Expressions.ExpressionParameterWrapper.Wrap(this, expressionEnvironment);
			return expressionEnvironment;
		}

		///Compile the expression if any
		void CompileExpression(){
			expressionEnvironment = null;
			compiledExpression = null;
			compileException = null;
			if (string.IsNullOrEmpty(scriptExpression)){
				return;
			}
			
			try
			{
				compiledExpression = StagPoint.Eval.EvalEngine.Compile(scriptExpression, GetExpressionEnvironment());
				if (compiledExpression.Type == typeof(void)){
					throw new System.Exception( string.Format("Expression must return a value of type '{0}'", animatedType.FriendlyName()) );
				}
				var value = compiledExpression.Execute();
				var valueType = value.GetType();
				if (valueType == typeof(object[])){
					if (ArrayToValue( (object[])value ) == null){
						throw new System.Exception("Return array has different number of arguments.");
					}
				} else {
					if ( !animatedType.RTIsAssignableFrom(valueType) ){
						throw new System.Exception(string.Format("Result Expression Type is '{0}', but '{1}' is required.", valueType.FriendlyName(), animatedType.FriendlyName()));
					}
				}
			}
			catch (System.Exception exc)
			{
				compileException = exc;
				compiledExpression = null;
			}
		}

		private object ArrayToValue(object[] array){
			if (array == null || array.Length != curves.Length){
				return null;
			}
			if (animatedType == typeof(bool)){
				return Convert.ChangeType(array[0], typeof(bool));
			}
			if (animatedType == typeof(int)){
				return Convert.ChangeType(array[0], typeof(int));
			}
			if (animatedType == typeof(float)){
				return Convert.ChangeType(array[0], typeof(float));
			}
			if (animatedType == typeof(Vector2)){
				return new Vector2( (float)Convert.ChangeType(array[0], typeof(float)), (float)Convert.ChangeType(array[1], typeof(float)) );
			}
			if (animatedType == typeof(Vector3)){
				return new Vector3( (float)Convert.ChangeType(array[0], typeof(float)), (float)Convert.ChangeType(array[1], typeof(float)), (float)Convert.ChangeType(array[2], typeof(float)) );
			}
			if (animatedType == typeof(Color)){
				return new Color( (float)Convert.ChangeType(array[0], typeof(float)), (float)Convert.ChangeType(array[1], typeof(float)), (float)Convert.ChangeType(array[2], typeof(float)), (float)Convert.ChangeType(array[3], typeof(float)) );
			}
			return null;
		}
#endif


		///Resolves the final object to be used.
		[System.NonSerialized]
		private object _resolved = null;
		public object ResolvedObject(){

			if (targetObject == null || targetObject.Equals(null)){
				return null;
			}

			//if snapshot not null, means at least one time this has been evaluated
			if (snapshot != null && _resolved != null && !_resolved.Equals(null) ){
				return _resolved;
			}

			if (targetObject is GameObject){

				if ( !string.IsNullOrEmpty(transformHierarchyPath) ){
					var transform = ResolveTransformPath( (targetObject as GameObject).transform );
					return _resolved = transform != null? transform.GetComponent(declaringType) : null;
				}

				return _resolved = (targetObject as GameObject).GetComponent(declaringType);
			}

			return _resolved = targetObject;
		}


		///Gets the current raw property value from target
		public object GetCurrentValue(){

			if (!isValid){
				return null;
			}
			
			var obj = ResolvedObject();
			if (obj == null || obj.Equals(null)){
				return null;
			}

			if (obj is Transform){ //special treat
				var transform = obj as Transform;
				var value = default(Vector3);
				if (parameterName == "localPosition"){
					value = transform.localPosition;
					if (virtualTransformParent != null && transform.parent == null){
						value = virtualTransformParent.InverseTransformPoint( value );
					}
					return value;
				}

				if (parameterName == "localEulerAngles"){
					value = transform.GetLocalEulerAngles();
					if (virtualTransformParent != null && transform.parent == null){
						value -= virtualTransformParent.GetLocalEulerAngles();
					}
					return value;
				}

				if (parameterName == "localScale"){
					return transform.localScale;
				}
			}

			return isProperty? property.RTGetGetMethod().Invoke(obj, null) : field.GetValue(obj);			
		}

		///Sets the current value to the object
		public void SetCurrentValue(object value){
			
			if (!isValid){
				return;
			}

			var obj = ResolvedObject();
			if (obj == null || obj.Equals(null)){
				return;
			}

			if (obj is Transform){ //special treat
				var transform = obj as Transform;
				var vector = (Vector3)value;
				if (parameterName == "localPosition"){
					if (virtualTransformParent != null && transform.parent == null){
						vector = virtualTransformParent.TransformPoint( vector );
					}
					transform.localPosition = vector;
					return;
				}

				if (parameterName == "localEulerAngles"){
					if (virtualTransformParent != null && transform.parent == null){
						vector += virtualTransformParent.GetLocalEulerAngles();
					}
					transform.SetLocalEulerAngles( vector );
					return;
				}

				if (parameterName == "localScale"){
					transform.localScale = vector;
					return;
				}
			}


			if (isProperty){
				property.RTGetSetMethod().Invoke(obj, new object[]{value});
			} else {
				field.SetValue(obj, value);
			}
		}

		///Returns the curves evaluated value at time
		public object GetEvalValue(float time){
			if (animatedType == typeof(bool)){
				return curve1.Evaluate(time) >= 1? true : false;
			}

			if (animatedType == typeof(int)){
				return (int)(curve1.Evaluate(time));
			}

			if (animatedType == typeof(float)){
				return curve1.Evaluate(time);
			}

			if (animatedType == typeof(Vector2)){
				return new Vector2( curve1.Evaluate(time), curve2.Evaluate(time) );
			}
				
			if (animatedType == typeof(Vector3)){
				return new Vector3( curve1.Evaluate(time), curve2.Evaluate(time), curve3.Evaluate(time) );
			}

			if (animatedType == typeof(Color)){
				return new Color( curve1.Evaluate(time), curve2.Evaluate(time), curve3.Evaluate(time), curve4.Evaluate(time) );
			}

			return null;
		}


#if UNITY_EDITOR
		////EDITOR EVAL////
		void Internal_Evaluate_Editor(float time, float previousTime, float weight = 1){

			if (!enabled || targetObject == null || targetObject.Equals(null)){
				return;
			}

			if (!HasAnyKey()){
				return;
			}

			#if UNITY_EDITOR 
			if (!Application.isPlaying){
				if (time == previousTime && HasChanged()){
					if (!Prefs.autoKey){ //in case of no Auto-Key, store changed params
						var _value = GetCurrentValue();
						Action restore     = ()=> { SetCurrentValue(_value); };
						Action commit      = ()=> { TryAutoKey(time); };
						var paramCallbacks = new CutsceneUtility.ChangedParameterCallbacks(restore, commit);
						CutsceneUtility.changedParameterCallbacks[this] = paramCallbacks;
					}
					return; //auto-key or not, return if the parameter changed
				}
				if (!Prefs.autoKey){
					CutsceneUtility.changedParameterCallbacks.Remove(this);
				}
			}
			#endif

			currentEval = GetEvalValue(time);

			if (weight < 1){
				if (animatedType == typeof(int)){ currentEval = (int)Mathf.Lerp( (int)snapshot, (int)currentEval, weight); }
				if (animatedType == typeof(float)){	currentEval = (float)Mathf.Lerp( (float)snapshot, (float)currentEval, weight); }
				if (animatedType == typeof(Vector2)){ currentEval = (Vector2)Vector2.Lerp( (Vector2)snapshot, (Vector2)currentEval, weight); }
				if (animatedType == typeof(Vector3)){ currentEval = (Vector3)Vector3.Lerp( (Vector3)snapshot, (Vector3)currentEval, weight); }
				if (animatedType == typeof(Color)){ currentEval = (Color)Color.Lerp( (Color)snapshot, (Color)currentEval, weight); }
			}

			SetCurrentValue(currentEval);
		}
#endif


		////RUNTIME EVAL////
		//The only thing this actually does vs editor evaluation is to save allocations for animated properties (not fields).
		//Unfortunately there is some duplicate code here. TODO.
		[NonSerialized] Action<bool> setterBool;
		[NonSerialized] Action<int> setterInt;
		[NonSerialized] Action<float> setterFloat;
		[NonSerialized] Action<Vector2> setterVector2;
		[NonSerialized] Action<Vector3> setterVector3;
		[NonSerialized] Action<Color> setterColor;
		[NonSerialized] object lastResolvedObject;
		void Internal_Evaluate_Runtime(float time, float previousTime, float weight = 1){

			if (!enabled || !isValid){
				return;
			}

			if (!HasAnyKey()){
				return;
			}

			var obj = ResolvedObject();
			var forceCreateDelegates = lastResolvedObject != obj;
			lastResolvedObject = obj;
			if (obj == null || obj.Equals(null)){
				return;
			}

			if (animatedType == typeof(bool)){
				var value = curve1.Evaluate(time) >= 1? true : false;
				if (isProperty){
					if (setterBool == null || forceCreateDelegates){ setterBool = property.RTGetSetMethod().RTCreateDelegate<Action<bool>>(obj); }
					setterBool(value);
				} else { field.SetValue(obj, value); }
				return;
			}

			if (animatedType == typeof(int)){
				var value = (int)curve1.Evaluate(time);
				if (weight < 1){ value = (int)Mathf.Lerp( (int)snapshot, value, weight ); }
				if (isProperty){
					if (setterInt == null || forceCreateDelegates){ setterInt = property.RTGetSetMethod().RTCreateDelegate<Action<int>>(obj); }
					setterInt(value);
				} else { field.SetValue(obj, value); }
				return;
			}

			if (animatedType == typeof(float)){
				var value = curve1.Evaluate(time);
				if (weight < 1){ value = Mathf.Lerp( (float)snapshot, value, weight ); }
				if (isProperty){
					if (setterFloat == null || forceCreateDelegates){ setterFloat = property.RTGetSetMethod().RTCreateDelegate<Action<float>>(obj); }
					setterFloat(value);
				} else { field.SetValue(obj, value); }
				return;
			}

			if (animatedType == typeof(Vector2)){
				var value = new Vector2( curve1.Evaluate(time), curve2.Evaluate(time) );
				if (weight < 1){ value = Vector2.Lerp( (Vector2)snapshot, value, weight ); }
				if (isProperty){
					if (setterVector2 == null || forceCreateDelegates){ setterVector2 = property.RTGetSetMethod().RTCreateDelegate<Action<Vector2>>(obj); }
					setterVector2(value);
				} else { field.SetValue(obj, value); }
				return;
			}

			if (animatedType == typeof(Vector3)){
				var value = new Vector3( curve1.Evaluate(time), curve2.Evaluate(time), curve3.Evaluate(time) );
				if (weight < 1){ value = Vector3.Lerp( (Vector3)snapshot, value, weight ); }
				if (obj is Transform){
					var transform = (Transform)obj;
					if (parameterName == "localPosition"){
						if (virtualTransformParent != null && transform.parent == null){
							value = virtualTransformParent.TransformPoint( value );
						}
						transform.localPosition = value;
						return;
					}

					if (parameterName == "localEulerAngles"){
						if (virtualTransformParent != null && transform.parent == null){
							value += virtualTransformParent.GetLocalEulerAngles();
						}
						transform.SetLocalEulerAngles( value );
						return;
					}

					if (parameterName == "localScale"){
						transform.localScale = value;
						return;
					}
				}
				if (isProperty){
					if (setterVector3 == null || forceCreateDelegates){ setterVector3 = property.RTGetSetMethod().RTCreateDelegate<Action<Vector3>>(obj); }
					setterVector3(value);
				} else { field.SetValue(obj, value); }
				return;
			}

			if (animatedType == typeof(Color)){
				var value = new Color( curve1.Evaluate(time), curve2.Evaluate(time), curve3.Evaluate(time), curve4.Evaluate(time) );
				if (weight < 1){ value = Color.Lerp( (Color)snapshot, value, weight ); }
				if (isProperty){
					if (setterColor == null || forceCreateDelegates){ setterColor = property.RTGetSetMethod().RTCreateDelegate<Action<Color>>(obj); }
					setterColor(value);
				} else { field.SetValue(obj, value); }
				return;
			}
		}
		////////




		///Try add key at time, with identity value either from existing curves or in case of no curves, from current property value.
		public bool TryKeyIdentity(float time){

			if (!HasAnyKey()){
				SetKeyCurrent(time);
				return true;
			}

			var keyAdded = false;
			foreach(var curve in curves){
				if (AddKey(curve, time, curve.Evaluate(time))){
					keyAdded = true;
				}
			}
			return keyAdded;
		}

		///Has the property on target changed since the last evaluation?
		public bool HasChanged(){
			var a = currentEval;
			if (a == null){
				return false;
			}
			var b = GetCurrentValue();
			if (b == null){
				return false;
			}

			if (animatedType == typeof(bool)){
				return (bool)a != (bool)b;
			}	
			if (animatedType == typeof(int)){
				return (int)a != (int)b;
			}			
			if (animatedType == typeof(float)){
				return Mathf.Abs( (float)a - (float)b ) > COMPARE_THRESHOLD;
			}
			if (animatedType == typeof(Vector2)){
				return Mathf.Abs( ((Vector2)a - (Vector2)b).magnitude) > COMPARE_THRESHOLD;
			}
			if (animatedType == typeof(Vector3)){
				return Mathf.Abs( ((Vector3)a - (Vector3)b).magnitude) > COMPARE_THRESHOLD;
			}
			if (animatedType == typeof(Color)){
				return Mathf.Abs( ((Vector4)(Color)a - (Vector4)(Color)b).magnitude) > COMPARE_THRESHOLD;
			}
			
			return false;
		}


		///Sets a key on target at time with it's current property value
		public void SetKeyCurrent(float time){
			RecordUndo();
			var val = GetCurrentValue();
			SetKey(time, val);
			currentEval = val;
			NotifyChange();
		}

		///Set a key at time - value
		void SetKey(float time, object value){

			if (!enabled || value == null){
				return;
			}

			if (animatedType == typeof(bool)){
				AddKey(curve1, time, (bool)value? 1 : 0);
				return;
			}

			if (animatedType == typeof(int)){
				AddKey(curve1, time, (int)value);
				return;
			}

			if (animatedType == typeof(float)){
				AddKey(curve1, time, (float)value);
				return;
			}

			if (animatedType == typeof(Vector2)){
				AddKey(curve1, time, ((Vector2)value).x);
				AddKey(curve2, time, ((Vector2)value).y);
				return;
			}

			if (animatedType == typeof(Vector3)){
				AddKey(curve1, time, ((Vector3)value).x);
				AddKey(curve2, time, ((Vector3)value).y);
				AddKey(curve3, time, ((Vector3)value).z);
				return;
			}

			if (animatedType == typeof(Color)){
				AddKey(curve1, time, ((Color)value).r);
				AddKey(curve2, time, ((Color)value).g);
				AddKey(curve3, time, ((Color)value).b);
				AddKey(curve4, time, ((Color)value).a);
				return;
			}
		}


		///Add key at time - value
		bool AddKey(AnimationCurve curve, float time, float value){

			RecordUndo();

			#if UNITY_EDITOR

			time = Mathf.Max(time, 0);

			var keys = curve.keys;
			for (var i = 0; i < keys.Length; i++){
				if ( Mathf.Abs( keys[i].time - time) < PROXIMITY_TOLERANCE ){
					var key = keys[i];
					key.time = time;
					key.value = value;
					curve.MoveKey(i, key);
					curve.UpdateTangentsFromMode();
					return false;
				}
			}

			var index = curve.AddKey(time, value);
			if (animatedType == typeof(bool) || animatedType == typeof(int)){
				curve.SetKeyTangentMode(index, TangentMode.Constant);
			} else {
				//if it's the first key added and preference is set to specific mode
				if (curve.length == 1 && Prefs.defaultTangentMode != TangentMode.Editable){
					curve.SetKeyTangentMode(index, Prefs.defaultTangentMode);
				//else set mode from neighbors
				} else {
					var nextIndex = index + 1;
					if (nextIndex < curve.length){
						var nextTangent = CurveUtility.GetKeyLeftTangentMode( curve[nextIndex] );
						CurveUtility.SetKeyTangentMode(curve, index, nextTangent);
					}
					
					var previousIndex = index - 1;
					if (previousIndex >= 0){
						var previousTangent = CurveUtility.GetKeyRightTangentMode( curve[previousIndex] );
						CurveUtility.SetKeyTangentMode(curve, index, previousTangent);
					}
				}
			}

			curve.UpdateTangentsFromMode();

			#else

			curve.AddKey(time, value);

			#endif

			NotifyChange();
			return true;
		}

		///Remove keys at time
		public void RemoveKey(float time){
			RecordUndo();
			foreach(var curve in curves){
				var keys = curve.keys;
				for (var i = 0; i < keys.Length; i++){
					var key = keys[i];
					if ( Mathf.Abs(key.time - time) < PROXIMITY_TOLERANCE ){
						curve.RemoveKey(i);
						break;
					}
				}

				#if UNITY_EDITOR
				curve.UpdateTangentsFromMode();
				#endif
			}

			NotifyChange();
		}

		///Set curves PreWrap
		public void SetPreWrapMode(WrapMode mode){
			RecordUndo();
			foreach(var curve in curves){
				curve.preWrapMode = mode;
			}

			NotifyChange();
		}
	
		///Set curves PostWrap
		public void SetPostWrapMode(WrapMode mode){
			RecordUndo();
			foreach(var curve in curves){
				curve.postWrapMode = mode;
			}

			NotifyChange();
		}

		///Are there any keys at all?
		public bool HasAnyKey(){
			for (var i = 0; i < curves.Length; i++){
				if (curves[i].length > 0){
					return true;
				}
			}
			return false;
		}

		///Has any key at time?
		public bool HasKey(float time){
			if (time >= 0){
				for (var i = 0; i < curves.Length; i++){
					if (curves[i].keys.Any( k => Mathf.Abs(k.time - time) < PROXIMITY_TOLERANCE )){
						return true;
					}
				}
			}
			return false;
		}

		///Returns the key time after time, or first key if time is last key time.
		public float GetKeyNext(float time){
			var keys = new List<Keyframe>();
			foreach(var curve in curves){
				keys.AddRange(curve.keys);
			}
			keys = keys.OrderBy(k => k.time).ToList();
			var key = keys.FirstOrDefault(k => k.time > time + PROXIMITY_TOLERANCE);
			return key.time == 0 && !HasKey(0)? keys.FirstOrDefault().time : key.time;
		}

		///Returns the key time before time, or last key if time is first key time.
		public float GetKeyPrevious(float time){
			var keys = new List<Keyframe>();
			foreach(var curve in curves){
				keys.AddRange(curve.keys);
			}
			keys = keys.OrderBy(k => k.time).ToList();
			if (time == 0){ return keys.LastOrDefault().time; }
			var key = keys.LastOrDefault(k => k.time < time - PROXIMITY_TOLERANCE);
			return key.time == 0 && !HasKey(0)? keys.LastOrDefault().time : key.time;
		}


		///Offset all curves by value.
		public void OffsetValue(object deltaValue){
			RecordUndo();

			if (animatedType == typeof(int)){
				OffsetCurveValues(curve1, (int)deltaValue);
			}
			
			if (animatedType == typeof(float)){
				OffsetCurveValues(curve1, (float)deltaValue);
			}

			if (animatedType == typeof(Vector2)){
				OffsetCurveValues(curve1, ((Vector2)deltaValue).x);
				OffsetCurveValues(curve2, ((Vector2)deltaValue).y);
			}

			if (animatedType == typeof(Vector3)){
				OffsetCurveValues(curve1, ((Vector3)deltaValue).x);
				OffsetCurveValues(curve2, ((Vector3)deltaValue).y);
				OffsetCurveValues(curve3, ((Vector3)deltaValue).z);
			}

			if (animatedType == typeof(Color)){
				OffsetCurveValues(curve1, ((Color)deltaValue).r);
				OffsetCurveValues(curve2, ((Color)deltaValue).g);
				OffsetCurveValues(curve3, ((Color)deltaValue).b);
				OffsetCurveValues(curve4, ((Color)deltaValue).a);
			}

			NotifyChange();
		}

		void OffsetCurveValues(AnimationCurve curve, float deltaValue){
			var keys = curve.keys;
			for (var i = 0; i < keys.Length; i++){
				var key = keys[i];
				key.value += deltaValue;
				curve.MoveKey(i, key);
			}
		}



		///Reset curves
		public void Reset(){
			RecordUndo();
			scriptExpression = null;
			foreach(var curve in curves){
				curve.keys = new Keyframe[0];
				curve.preWrapMode = WrapMode.ClampForever;
				curve.postWrapMode = WrapMode.ClampForever;
			}

			NotifyChange();
		}

		///Changes the type of the parameter (field/property) while keeping the data
		public void ChangeMemberType(ParameterType newType){
			if (newType != this.parameterType){
				data.parameterType = newType;
				serializedData = JsonUtility.ToJson(data);
			}
		}


		///A friendly label included all info
		public override string ToString(){
			
			if (string.IsNullOrEmpty(serializedData)){
				return "NOT SET!";
			}

			if ( !isValid ){
				return string.Format("*{0}*", data.parameterName);
			}
			
			var name = parameterName;
			if (name == "localPosition") name = "Position";
			if (name == "localEulerAngles") name = "Rotation";
			if (name == "localScale") name = "Scale";
			if (isExternal){
				name = string.Format("{0} <i>({1})</i>", name, declaringType.Name);
			}
			if (!enabled){
				name += " <i>(Disabled)</i>";
			}
			return string.IsNullOrEmpty(transformHierarchyPath)? name.SplitCamelCase() : transformHierarchyPath + "/" + name.SplitCamelCase();
		}

		///Returns formated text of value at time
		public string GetKeyLabel(float time){
			
			var label = string.Empty;

			if (animatedType == typeof(bool)){
				label = curve1.Evaluate(time) >= 1? "true" : "false";
			}

			if (animatedType == typeof(int)){
				label = curve1.Evaluate(time).ToString("0");
			}

			if (animatedType == typeof(float)){
				label = curve1.Evaluate(time).ToString("0.0");
			}

			if (animatedType == typeof(Vector2) || animatedType == typeof(Vector3)){
				for (var i = 0; i < curves.Length; i++){
					label += curves[i].Evaluate(time).ToString("0");
					if (i < curves.Length-1){ label += ","; }
				}								
			}

			if (animatedType == typeof(Color)){
				Color32 color = new Color(curve1.Evaluate(time), curve2.Evaluate(time), curve3.Evaluate(time), curve4.Evaluate(time));
				var hexColor = ("#" + color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2")).ToLower();
				return string.Format("<color={0}><size=14>●</size></color>", hexColor);
			}

			return string.Format("({0})", label);
		}


		//Helper function
		void RecordUndo(){
			#if UNITY_EDITOR
			UnityEngine.Object obj = null;
			obj = keyable as UnityEngine.Object;
			if (obj != null){ UnityEditor.Undo.RecordObject(obj, "Parameter Change"); }
			obj = ResolvedObject() as UnityEngine.Object;
			if (obj != null){ UnityEditor.Undo.RecordObject(obj, "Parameter Change"); }
			#endif
		}

		///Raise the change event
		void NotifyChange(){
			if (onParameterChanged != null){
				onParameterChanged(this);
			}
		}
	}
}