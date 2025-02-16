﻿using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Slate{

	[AddComponentMenu("SLATE/Play Cutscene On Trigger")]
	public class PlayCutsceneOnTrigger : MonoBehaviour {

		public Cutscene cutscene;
		public bool checkSpecificTagOnly = true;
		public string tagName = "Player";
		public bool once;
		public UnityEvent onFinish;

		void OnTriggerEnter(Collider other){

			if (cutscene == null){
				Debug.LogError("Cutscene is not provided", gameObject);
				return;
			}

			if (checkSpecificTagOnly && !string.IsNullOrEmpty(tagName)){
				if (other.gameObject.tag != tagName){
					return;
				}
			}

			enabled = false;
			cutscene.Play( ()=>
			{
				onFinish.Invoke();
				if (once){ DeepCore.Unity3D.UnityHelper.Destroy(this.gameObject); }
				else { enabled = true; }
			});
		}

		void Reset(){
			var collider = gameObject.GetAddComponent<BoxCollider>();
			collider.isTrigger = true;
		}

		public static GameObject Create(){
			return new GameObject("Cutscene Trigger").AddComponent<PlayCutsceneOnTrigger>().gameObject;
		}
	}
}