﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_EventSystems_PointerInputModule_MouseButtonEventData : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerInputModule.MouseButtonEventData o;
			o=new UnityEngine.EventSystems.PointerInputModule.MouseButtonEventData();
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
	static public int PressedThisFrame(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerInputModule.MouseButtonEventData self=(UnityEngine.EventSystems.PointerInputModule.MouseButtonEventData)checkSelf(l);
			var ret=self.PressedThisFrame();
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
	static public int ReleasedThisFrame(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerInputModule.MouseButtonEventData self=(UnityEngine.EventSystems.PointerInputModule.MouseButtonEventData)checkSelf(l);
			var ret=self.ReleasedThisFrame();
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
	static public int get_buttonState(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerInputModule.MouseButtonEventData self=(UnityEngine.EventSystems.PointerInputModule.MouseButtonEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.buttonState);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_buttonState(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerInputModule.MouseButtonEventData self=(UnityEngine.EventSystems.PointerInputModule.MouseButtonEventData)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData.FramePressState v;
			checkEnum(l,2,out v);
			self.buttonState=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_buttonData(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerInputModule.MouseButtonEventData self=(UnityEngine.EventSystems.PointerInputModule.MouseButtonEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.buttonData);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_buttonData(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerInputModule.MouseButtonEventData self=(UnityEngine.EventSystems.PointerInputModule.MouseButtonEventData)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData v;
			checkType(l,2,out v);
			self.buttonData=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.EventSystems.PointerInputModule.MouseButtonEventData");
		addMember(l,PressedThisFrame);
		addMember(l,ReleasedThisFrame);
		addMember(l,"buttonState",get_buttonState,set_buttonState,true);
		addMember(l,"buttonData",get_buttonData,set_buttonData,true);
		addMember(l,op_Equality);
		createTypeMetatable(l,constructor, typeof(UnityEngine.EventSystems.PointerInputModule.MouseButtonEventData));
	}
}
