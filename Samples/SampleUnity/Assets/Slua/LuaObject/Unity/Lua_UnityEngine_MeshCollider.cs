﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_MeshCollider : LuaObject {
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
	static public int get_sharedMesh(IntPtr l) {
		try {
			UnityEngine.MeshCollider self=(UnityEngine.MeshCollider)checkSelf(l);
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
			UnityEngine.MeshCollider self=(UnityEngine.MeshCollider)checkSelf(l);
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
	static public int get_convex(IntPtr l) {
		try {
			UnityEngine.MeshCollider self=(UnityEngine.MeshCollider)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.convex);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_convex(IntPtr l) {
		try {
			UnityEngine.MeshCollider self=(UnityEngine.MeshCollider)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.convex=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_cookingOptions(IntPtr l) {
		try {
			UnityEngine.MeshCollider self=(UnityEngine.MeshCollider)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.cookingOptions);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_cookingOptions(IntPtr l) {
		try {
			UnityEngine.MeshCollider self=(UnityEngine.MeshCollider)checkSelf(l);
			UnityEngine.MeshColliderCookingOptions v;
			checkEnum(l,2,out v);
			self.cookingOptions=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_inflateMesh(IntPtr l) {
		try {
			UnityEngine.MeshCollider self=(UnityEngine.MeshCollider)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.inflateMesh);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_inflateMesh(IntPtr l) {
		try {
			UnityEngine.MeshCollider self=(UnityEngine.MeshCollider)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.inflateMesh=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_skinWidth(IntPtr l) {
		try {
			UnityEngine.MeshCollider self=(UnityEngine.MeshCollider)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.skinWidth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_skinWidth(IntPtr l) {
		try {
			UnityEngine.MeshCollider self=(UnityEngine.MeshCollider)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.skinWidth=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.MeshCollider");
		addMember(l,"sharedMesh",get_sharedMesh,set_sharedMesh,true);
		addMember(l,"convex",get_convex,set_convex,true);
		addMember(l,"cookingOptions",get_cookingOptions,set_cookingOptions,true);
		addMember(l,"inflateMesh",get_inflateMesh,set_inflateMesh,true);
		addMember(l,"skinWidth",get_skinWidth,set_skinWidth,true);
		addMember(l,op_Equality);
		createTypeMetatable(l,null, typeof(UnityEngine.MeshCollider),typeof(UnityEngine.Collider));
	}
}
