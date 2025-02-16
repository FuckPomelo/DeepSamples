﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_SpriteState : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.SpriteState o;
			o=new UnityEngine.UI.SpriteState();
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
	static public int get_highlightedSprite(IntPtr l) {
		try {
			UnityEngine.UI.SpriteState self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.highlightedSprite);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_highlightedSprite(IntPtr l) {
		try {
			UnityEngine.UI.SpriteState self;
			checkValueType(l,1,out self);
			UnityEngine.Sprite v;
			checkType(l,2,out v);
			self.highlightedSprite=v;
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
	static public int get_pressedSprite(IntPtr l) {
		try {
			UnityEngine.UI.SpriteState self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.pressedSprite);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_pressedSprite(IntPtr l) {
		try {
			UnityEngine.UI.SpriteState self;
			checkValueType(l,1,out self);
			UnityEngine.Sprite v;
			checkType(l,2,out v);
			self.pressedSprite=v;
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
	static public int get_disabledSprite(IntPtr l) {
		try {
			UnityEngine.UI.SpriteState self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.disabledSprite);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_disabledSprite(IntPtr l) {
		try {
			UnityEngine.UI.SpriteState self;
			checkValueType(l,1,out self);
			UnityEngine.Sprite v;
			checkType(l,2,out v);
			self.disabledSprite=v;
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
		getTypeTable(l,"UnityEngine.UI.SpriteState");
		addMember(l,"highlightedSprite",get_highlightedSprite,set_highlightedSprite,true);
		addMember(l,"pressedSprite",get_pressedSprite,set_pressedSprite,true);
		addMember(l,"disabledSprite",get_disabledSprite,set_disabledSprite,true);
		addMember(l,op_Equality);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.SpriteState),typeof(System.ValueType));
	}
}
