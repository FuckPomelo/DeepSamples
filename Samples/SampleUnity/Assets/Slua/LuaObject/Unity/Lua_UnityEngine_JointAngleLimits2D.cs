﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_JointAngleLimits2D : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.JointAngleLimits2D o;
			o=new UnityEngine.JointAngleLimits2D();
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
	static public int get_min(IntPtr l) {
		try {
			UnityEngine.JointAngleLimits2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.min);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_min(IntPtr l) {
		try {
			UnityEngine.JointAngleLimits2D self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.min=v;
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
	static public int get_max(IntPtr l) {
		try {
			UnityEngine.JointAngleLimits2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.max);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_max(IntPtr l) {
		try {
			UnityEngine.JointAngleLimits2D self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.max=v;
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
		getTypeTable(l,"UnityEngine.JointAngleLimits2D");
		addMember(l,"min",get_min,set_min,true);
		addMember(l,"max",get_max,set_max,true);
		addMember(l,op_Equality);
		createTypeMetatable(l,constructor, typeof(UnityEngine.JointAngleLimits2D),typeof(System.ValueType));
	}
}
