﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_DefaultControls : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CreatePanel_s(IntPtr l) {
		try {
			UnityEngine.UI.DefaultControls.Resources a1;
			checkValueType(l,1,out a1);
			var ret=UnityEngine.UI.DefaultControls.CreatePanel(a1);
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
	static public int CreateButton_s(IntPtr l) {
		try {
			UnityEngine.UI.DefaultControls.Resources a1;
			checkValueType(l,1,out a1);
			var ret=UnityEngine.UI.DefaultControls.CreateButton(a1);
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
	static public int CreateText_s(IntPtr l) {
		try {
			UnityEngine.UI.DefaultControls.Resources a1;
			checkValueType(l,1,out a1);
			var ret=UnityEngine.UI.DefaultControls.CreateText(a1);
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
	static public int CreateImage_s(IntPtr l) {
		try {
			UnityEngine.UI.DefaultControls.Resources a1;
			checkValueType(l,1,out a1);
			var ret=UnityEngine.UI.DefaultControls.CreateImage(a1);
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
	static public int CreateRawImage_s(IntPtr l) {
		try {
			UnityEngine.UI.DefaultControls.Resources a1;
			checkValueType(l,1,out a1);
			var ret=UnityEngine.UI.DefaultControls.CreateRawImage(a1);
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
	static public int CreateSlider_s(IntPtr l) {
		try {
			UnityEngine.UI.DefaultControls.Resources a1;
			checkValueType(l,1,out a1);
			var ret=UnityEngine.UI.DefaultControls.CreateSlider(a1);
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
	static public int CreateScrollbar_s(IntPtr l) {
		try {
			UnityEngine.UI.DefaultControls.Resources a1;
			checkValueType(l,1,out a1);
			var ret=UnityEngine.UI.DefaultControls.CreateScrollbar(a1);
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
	static public int CreateToggle_s(IntPtr l) {
		try {
			UnityEngine.UI.DefaultControls.Resources a1;
			checkValueType(l,1,out a1);
			var ret=UnityEngine.UI.DefaultControls.CreateToggle(a1);
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
	static public int CreateInputField_s(IntPtr l) {
		try {
			UnityEngine.UI.DefaultControls.Resources a1;
			checkValueType(l,1,out a1);
			var ret=UnityEngine.UI.DefaultControls.CreateInputField(a1);
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
	static public int CreateDropdown_s(IntPtr l) {
		try {
			UnityEngine.UI.DefaultControls.Resources a1;
			checkValueType(l,1,out a1);
			var ret=UnityEngine.UI.DefaultControls.CreateDropdown(a1);
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
	static public int CreateScrollView_s(IntPtr l) {
		try {
			UnityEngine.UI.DefaultControls.Resources a1;
			checkValueType(l,1,out a1);
			var ret=UnityEngine.UI.DefaultControls.CreateScrollView(a1);
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
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.DefaultControls");
		addMember(l,CreatePanel_s);
		addMember(l,CreateButton_s);
		addMember(l,CreateText_s);
		addMember(l,CreateImage_s);
		addMember(l,CreateRawImage_s);
		addMember(l,CreateSlider_s);
		addMember(l,CreateScrollbar_s);
		addMember(l,CreateToggle_s);
		addMember(l,CreateInputField_s);
		addMember(l,CreateDropdown_s);
		addMember(l,CreateScrollView_s);
		addMember(l,op_Equality);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.DefaultControls));
	}
}
