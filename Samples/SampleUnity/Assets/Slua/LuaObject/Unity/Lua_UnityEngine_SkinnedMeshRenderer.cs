﻿using System;
using SLua;
using System.Collections.Generic;
using Slate;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_SkinnedMeshRenderer : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetBlendShapeWeight(IntPtr l) {
		try {
			UnityEngine.SkinnedMeshRenderer self=(UnityEngine.SkinnedMeshRenderer)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetBlendShapeWeight(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetBlendShapeWeight(IntPtr l) {
		try {
			UnityEngine.SkinnedMeshRenderer self=(UnityEngine.SkinnedMeshRenderer)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			self.SetBlendShapeWeight(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int BakeMesh(IntPtr l) {
		try {
			UnityEngine.SkinnedMeshRenderer self=(UnityEngine.SkinnedMeshRenderer)checkSelf(l);
			UnityEngine.Mesh a1;
			checkType(l,2,out a1);
			self.BakeMesh(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetBlendShapeNames(IntPtr l) {
		try {
			UnityEngine.SkinnedMeshRenderer self=(UnityEngine.SkinnedMeshRenderer)checkSelf(l);
			var ret=self.GetBlendShapeNames();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetBlendShapeIndex(IntPtr l) {
		try {
			UnityEngine.SkinnedMeshRenderer self=(UnityEngine.SkinnedMeshRenderer)checkSelf(l);
			System.String a2;
			checkType(l,2,out a2);
			var ret=self.GetBlendShapeIndex(a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int op_Equality(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			System.Object a2;
			checkType(l,2,out a2);
			var ret = System.Object.Equals(a1, a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_bones(IntPtr l) {
		try {
			UnityEngine.SkinnedMeshRenderer self=(UnityEngine.SkinnedMeshRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.bones);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_bones(IntPtr l) {
		try {
			UnityEngine.SkinnedMeshRenderer self=(UnityEngine.SkinnedMeshRenderer)checkSelf(l);
			UnityEngine.Transform[] v;
			checkArray(l,2,out v);
			self.bones=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_quality(IntPtr l) {
		try {
			UnityEngine.SkinnedMeshRenderer self=(UnityEngine.SkinnedMeshRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.quality);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_quality(IntPtr l) {
		try {
			UnityEngine.SkinnedMeshRenderer self=(UnityEngine.SkinnedMeshRenderer)checkSelf(l);
			UnityEngine.SkinQuality v;
			checkEnum(l,2,out v);
			self.quality=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_updateWhenOffscreen(IntPtr l) {
		try {
			UnityEngine.SkinnedMeshRenderer self=(UnityEngine.SkinnedMeshRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.updateWhenOffscreen);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_updateWhenOffscreen(IntPtr l) {
		try {
			UnityEngine.SkinnedMeshRenderer self=(UnityEngine.SkinnedMeshRenderer)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.updateWhenOffscreen=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_rootBone(IntPtr l) {
		try {
			UnityEngine.SkinnedMeshRenderer self=(UnityEngine.SkinnedMeshRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.rootBone);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_rootBone(IntPtr l) {
		try {
			UnityEngine.SkinnedMeshRenderer self=(UnityEngine.SkinnedMeshRenderer)checkSelf(l);
			UnityEngine.Transform v;
			checkType(l,2,out v);
			self.rootBone=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_sharedMesh(IntPtr l) {
		try {
			UnityEngine.SkinnedMeshRenderer self=(UnityEngine.SkinnedMeshRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.sharedMesh);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_sharedMesh(IntPtr l) {
		try {
			UnityEngine.SkinnedMeshRenderer self=(UnityEngine.SkinnedMeshRenderer)checkSelf(l);
			UnityEngine.Mesh v;
			checkType(l,2,out v);
			self.sharedMesh=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_skinnedMotionVectors(IntPtr l) {
		try {
			UnityEngine.SkinnedMeshRenderer self=(UnityEngine.SkinnedMeshRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.skinnedMotionVectors);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_skinnedMotionVectors(IntPtr l) {
		try {
			UnityEngine.SkinnedMeshRenderer self=(UnityEngine.SkinnedMeshRenderer)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.skinnedMotionVectors=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_localBounds(IntPtr l) {
		try {
			UnityEngine.SkinnedMeshRenderer self=(UnityEngine.SkinnedMeshRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.localBounds);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_localBounds(IntPtr l) {
		try {
			UnityEngine.SkinnedMeshRenderer self=(UnityEngine.SkinnedMeshRenderer)checkSelf(l);
			UnityEngine.Bounds v;
			checkValueType(l,2,out v);
			self.localBounds=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.SkinnedMeshRenderer");
		addMember(l,GetBlendShapeWeight);
		addMember(l,SetBlendShapeWeight);
		addMember(l,BakeMesh);
		addMember(l,GetBlendShapeNames);
		addMember(l,GetBlendShapeIndex);
		addMember(l,"bones",get_bones,set_bones,true);
		addMember(l,"quality",get_quality,set_quality,true);
		addMember(l,"updateWhenOffscreen",get_updateWhenOffscreen,set_updateWhenOffscreen,true);
		addMember(l,"rootBone",get_rootBone,set_rootBone,true);
		addMember(l,"sharedMesh",get_sharedMesh,set_sharedMesh,true);
		addMember(l,"skinnedMotionVectors",get_skinnedMotionVectors,set_skinnedMotionVectors,true);
		addMember(l,"localBounds",get_localBounds,set_localBounds,true);
		addMember(l,op_Equality);
		createTypeMetatable(l,null, typeof(UnityEngine.SkinnedMeshRenderer),typeof(UnityEngine.Renderer));
	}
}
