﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_OcclusionPortal : LuaObject {
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
	static public int get_open(IntPtr l) {
		try {
			UnityEngine.OcclusionPortal self=(UnityEngine.OcclusionPortal)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.open);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_open(IntPtr l) {
		try {
			UnityEngine.OcclusionPortal self=(UnityEngine.OcclusionPortal)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.open=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.OcclusionPortal");
		addMember(l,"open",get_open,set_open,true);
		addMember(l,op_Equality);
		createTypeMetatable(l,null, typeof(UnityEngine.OcclusionPortal),typeof(UnityEngine.Component));
	}
}
