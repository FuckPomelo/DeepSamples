﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_LOD : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.LOD o;
			System.Single a1;
			checkType(l,2,out a1);
			UnityEngine.Renderer[] a2;
			checkArray(l,3,out a2);
			o=new UnityEngine.LOD(a1,a2);
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
	static public int get_screenRelativeTransitionHeight(IntPtr l) {
		try {
			UnityEngine.LOD self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.screenRelativeTransitionHeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_screenRelativeTransitionHeight(IntPtr l) {
		try {
			UnityEngine.LOD self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.screenRelativeTransitionHeight=v;
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
	static public int get_fadeTransitionWidth(IntPtr l) {
		try {
			UnityEngine.LOD self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.fadeTransitionWidth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_fadeTransitionWidth(IntPtr l) {
		try {
			UnityEngine.LOD self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.fadeTransitionWidth=v;
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
	static public int get_renderers(IntPtr l) {
		try {
			UnityEngine.LOD self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.renderers);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_renderers(IntPtr l) {
		try {
			UnityEngine.LOD self;
			checkValueType(l,1,out self);
			UnityEngine.Renderer[] v;
			checkArray(l,2,out v);
			self.renderers=v;
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
		getTypeTable(l,"UnityEngine.LOD");
		addMember(l,"screenRelativeTransitionHeight",get_screenRelativeTransitionHeight,set_screenRelativeTransitionHeight,true);
		addMember(l,"fadeTransitionWidth",get_fadeTransitionWidth,set_fadeTransitionWidth,true);
		addMember(l,"renderers",get_renderers,set_renderers,true);
		addMember(l,op_Equality);
		createTypeMetatable(l,constructor, typeof(UnityEngine.LOD),typeof(System.ValueType));
	}
}
