﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_CombineInstance : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.CombineInstance o;
			o=new UnityEngine.CombineInstance();
			pushValue(l,true);
			pushValue(l,o);
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
	static public int get_mesh(IntPtr l) {
		try {
			UnityEngine.CombineInstance self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.mesh);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_mesh(IntPtr l) {
		try {
			UnityEngine.CombineInstance self;
			checkValueType(l,1,out self);
			UnityEngine.Mesh v;
			checkType(l,2,out v);
			self.mesh=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_subMeshIndex(IntPtr l) {
		try {
			UnityEngine.CombineInstance self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.subMeshIndex);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_subMeshIndex(IntPtr l) {
		try {
			UnityEngine.CombineInstance self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.subMeshIndex=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_transform(IntPtr l) {
		try {
			UnityEngine.CombineInstance self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.transform);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_transform(IntPtr l) {
		try {
			UnityEngine.CombineInstance self;
			checkValueType(l,1,out self);
			UnityEngine.Matrix4x4 v;
			checkValueType(l,2,out v);
			self.transform=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_lightmapScaleOffset(IntPtr l) {
		try {
			UnityEngine.CombineInstance self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.lightmapScaleOffset);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_lightmapScaleOffset(IntPtr l) {
		try {
			UnityEngine.CombineInstance self;
			checkValueType(l,1,out self);
			UnityEngine.Vector4 v;
			checkType(l,2,out v);
			self.lightmapScaleOffset=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_realtimeLightmapScaleOffset(IntPtr l) {
		try {
			UnityEngine.CombineInstance self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.realtimeLightmapScaleOffset);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_realtimeLightmapScaleOffset(IntPtr l) {
		try {
			UnityEngine.CombineInstance self;
			checkValueType(l,1,out self);
			UnityEngine.Vector4 v;
			checkType(l,2,out v);
			self.realtimeLightmapScaleOffset=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.CombineInstance");
		addMember(l,"mesh",get_mesh,set_mesh,true);
		addMember(l,"subMeshIndex",get_subMeshIndex,set_subMeshIndex,true);
		addMember(l,"transform",get_transform,set_transform,true);
		addMember(l,"lightmapScaleOffset",get_lightmapScaleOffset,set_lightmapScaleOffset,true);
		addMember(l,"realtimeLightmapScaleOffset",get_realtimeLightmapScaleOffset,set_realtimeLightmapScaleOffset,true);
		addMember(l,op_Equality);
		createTypeMetatable(l,constructor, typeof(UnityEngine.CombineInstance),typeof(System.ValueType));
	}
}
