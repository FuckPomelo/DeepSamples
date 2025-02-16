﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_SpringJoint : LuaObject {
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
	static public int get_spring(IntPtr l) {
		try {
			UnityEngine.SpringJoint self=(UnityEngine.SpringJoint)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.spring);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_spring(IntPtr l) {
		try {
			UnityEngine.SpringJoint self=(UnityEngine.SpringJoint)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.spring=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_damper(IntPtr l) {
		try {
			UnityEngine.SpringJoint self=(UnityEngine.SpringJoint)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.damper);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_damper(IntPtr l) {
		try {
			UnityEngine.SpringJoint self=(UnityEngine.SpringJoint)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.damper=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_minDistance(IntPtr l) {
		try {
			UnityEngine.SpringJoint self=(UnityEngine.SpringJoint)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.minDistance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_minDistance(IntPtr l) {
		try {
			UnityEngine.SpringJoint self=(UnityEngine.SpringJoint)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.minDistance=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maxDistance(IntPtr l) {
		try {
			UnityEngine.SpringJoint self=(UnityEngine.SpringJoint)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.maxDistance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_maxDistance(IntPtr l) {
		try {
			UnityEngine.SpringJoint self=(UnityEngine.SpringJoint)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.maxDistance=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_tolerance(IntPtr l) {
		try {
			UnityEngine.SpringJoint self=(UnityEngine.SpringJoint)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.tolerance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_tolerance(IntPtr l) {
		try {
			UnityEngine.SpringJoint self=(UnityEngine.SpringJoint)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.tolerance=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.SpringJoint");
		addMember(l,"spring",get_spring,set_spring,true);
		addMember(l,"damper",get_damper,set_damper,true);
		addMember(l,"minDistance",get_minDistance,set_minDistance,true);
		addMember(l,"maxDistance",get_maxDistance,set_maxDistance,true);
		addMember(l,"tolerance",get_tolerance,set_tolerance,true);
		addMember(l,op_Equality);
		createTypeMetatable(l,null, typeof(UnityEngine.SpringJoint),typeof(UnityEngine.Joint));
	}
}
