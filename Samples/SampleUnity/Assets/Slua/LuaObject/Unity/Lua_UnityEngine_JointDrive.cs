﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_JointDrive : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.JointDrive o;
			o=new UnityEngine.JointDrive();
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
	static public int get_positionSpring(IntPtr l) {
		try {
			UnityEngine.JointDrive self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.positionSpring);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_positionSpring(IntPtr l) {
		try {
			UnityEngine.JointDrive self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.positionSpring=v;
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
	static public int get_positionDamper(IntPtr l) {
		try {
			UnityEngine.JointDrive self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.positionDamper);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_positionDamper(IntPtr l) {
		try {
			UnityEngine.JointDrive self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.positionDamper=v;
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
	static public int get_maximumForce(IntPtr l) {
		try {
			UnityEngine.JointDrive self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.maximumForce);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_maximumForce(IntPtr l) {
		try {
			UnityEngine.JointDrive self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.maximumForce=v;
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
		getTypeTable(l,"UnityEngine.JointDrive");
		addMember(l,"positionSpring",get_positionSpring,set_positionSpring,true);
		addMember(l,"positionDamper",get_positionDamper,set_positionDamper,true);
		addMember(l,"maximumForce",get_maximumForce,set_maximumForce,true);
		addMember(l,op_Equality);
		createTypeMetatable(l,constructor, typeof(UnityEngine.JointDrive),typeof(System.ValueType));
	}
}
