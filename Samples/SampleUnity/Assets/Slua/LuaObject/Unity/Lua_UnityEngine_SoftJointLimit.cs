﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_SoftJointLimit : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.SoftJointLimit o;
			o=new UnityEngine.SoftJointLimit();
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
	static public int get_limit(IntPtr l) {
		try {
			UnityEngine.SoftJointLimit self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.limit);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_limit(IntPtr l) {
		try {
			UnityEngine.SoftJointLimit self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.limit=v;
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
	static public int get_bounciness(IntPtr l) {
		try {
			UnityEngine.SoftJointLimit self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.bounciness);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_bounciness(IntPtr l) {
		try {
			UnityEngine.SoftJointLimit self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.bounciness=v;
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
	static public int get_contactDistance(IntPtr l) {
		try {
			UnityEngine.SoftJointLimit self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.contactDistance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_contactDistance(IntPtr l) {
		try {
			UnityEngine.SoftJointLimit self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.contactDistance=v;
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
		getTypeTable(l,"UnityEngine.SoftJointLimit");
		addMember(l,"limit",get_limit,set_limit,true);
		addMember(l,"bounciness",get_bounciness,set_bounciness,true);
		addMember(l,"contactDistance",get_contactDistance,set_contactDistance,true);
		addMember(l,op_Equality);
		createTypeMetatable(l,constructor, typeof(UnityEngine.SoftJointLimit),typeof(System.ValueType));
	}
}
