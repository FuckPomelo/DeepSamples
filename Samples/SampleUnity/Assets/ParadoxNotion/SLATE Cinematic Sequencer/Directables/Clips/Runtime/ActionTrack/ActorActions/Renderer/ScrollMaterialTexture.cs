﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Slate.ActionClips{

	[Category("Renderer")]
	[Description("Scroll/Offset the material texture. Usefull for scrolling backgrounds, screens, or other similar effects.")]
	public class ScrollMaterialTexture : ActorActionClip<Renderer> {

		[SerializeField] [HideInInspector]
		private float _length = 1;

		[ShaderPropertyPopup(typeof(Texture))]
		public string propertyName = "_MainTex";
		public Vector2 speed = new Vector2(1,0);
		public EaseType interpolation = EaseType.QuadraticInOut;

		private Vector2 originalOffset;
		private Material sharedMat;
		private Material instanceMat;

		public override string info{
			get {return string.Format("Scroll Texture / sec\n{0}", speed);}
		}

		public override bool isValid{
			get {return actor != null && actor.sharedMaterial.HasProperty(propertyName);}
		}

		public override float length{
			get {return _length;}
			set {_length = value;}
		}

		public override float blendIn{
			get {return length;}
		}

		protected override void OnEnter(){
			sharedMat = actor.sharedMaterial;
			instanceMat = Instantiate(sharedMat);
			actor.material = instanceMat;
			originalOffset = instanceMat.GetTextureOffset(propertyName);
		}

		protected override void OnUpdate(float deltaTime){
			var newOffset = Easing.Ease(interpolation, originalOffset, originalOffset + (speed * length), GetClipWeight(deltaTime));
			instanceMat.SetTextureOffset(propertyName, newOffset);
		}

		protected override void OnReverse(){
            DeepCore.Unity3D.UnityHelper.DestroyImmediate(instanceMat);
			actor.sharedMaterial = sharedMat;
		}
	}
}