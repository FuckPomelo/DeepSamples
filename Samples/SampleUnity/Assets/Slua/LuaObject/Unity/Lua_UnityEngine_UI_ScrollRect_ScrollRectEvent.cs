﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_ScrollRect_ScrollRectEvent : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect.ScrollRectEvent o;
			o=new UnityEngine.UI.ScrollRect.ScrollRectEvent();
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
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		LuaUnityEvent_UnityEngine_Vector2.reg(l);
		getTypeTable(l,"UnityEngine.UI.ScrollRect.ScrollRectEvent");
		addMember(l,op_Equality);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.ScrollRect.ScrollRectEvent),typeof(LuaUnityEvent_UnityEngine_Vector2));
	}
}
