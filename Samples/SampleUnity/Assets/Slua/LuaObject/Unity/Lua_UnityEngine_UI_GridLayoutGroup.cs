﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_GridLayoutGroup : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CalculateLayoutInputHorizontal(IntPtr l) {
		try {
			UnityEngine.UI.GridLayoutGroup self=(UnityEngine.UI.GridLayoutGroup)checkSelf(l);
			self.CalculateLayoutInputHorizontal();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CalculateLayoutInputVertical(IntPtr l) {
		try {
			UnityEngine.UI.GridLayoutGroup self=(UnityEngine.UI.GridLayoutGroup)checkSelf(l);
			self.CalculateLayoutInputVertical();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetLayoutHorizontal(IntPtr l) {
		try {
			UnityEngine.UI.GridLayoutGroup self=(UnityEngine.UI.GridLayoutGroup)checkSelf(l);
			self.SetLayoutHorizontal();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetLayoutVertical(IntPtr l) {
		try {
			UnityEngine.UI.GridLayoutGroup self=(UnityEngine.UI.GridLayoutGroup)checkSelf(l);
			self.SetLayoutVertical();
			pushValue(l,true);
			return 1;
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
	static public int get_startCorner(IntPtr l) {
		try {
			UnityEngine.UI.GridLayoutGroup self=(UnityEngine.UI.GridLayoutGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.startCorner);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startCorner(IntPtr l) {
		try {
			UnityEngine.UI.GridLayoutGroup self=(UnityEngine.UI.GridLayoutGroup)checkSelf(l);
			UnityEngine.UI.GridLayoutGroup.Corner v;
			checkEnum(l,2,out v);
			self.startCorner=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_startAxis(IntPtr l) {
		try {
			UnityEngine.UI.GridLayoutGroup self=(UnityEngine.UI.GridLayoutGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.startAxis);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startAxis(IntPtr l) {
		try {
			UnityEngine.UI.GridLayoutGroup self=(UnityEngine.UI.GridLayoutGroup)checkSelf(l);
			UnityEngine.UI.GridLayoutGroup.Axis v;
			checkEnum(l,2,out v);
			self.startAxis=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_cellSize(IntPtr l) {
		try {
			UnityEngine.UI.GridLayoutGroup self=(UnityEngine.UI.GridLayoutGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.cellSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_cellSize(IntPtr l) {
		try {
			UnityEngine.UI.GridLayoutGroup self=(UnityEngine.UI.GridLayoutGroup)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.cellSize=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_spacing(IntPtr l) {
		try {
			UnityEngine.UI.GridLayoutGroup self=(UnityEngine.UI.GridLayoutGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.spacing);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_spacing(IntPtr l) {
		try {
			UnityEngine.UI.GridLayoutGroup self=(UnityEngine.UI.GridLayoutGroup)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.spacing=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_constraint(IntPtr l) {
		try {
			UnityEngine.UI.GridLayoutGroup self=(UnityEngine.UI.GridLayoutGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.constraint);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_constraint(IntPtr l) {
		try {
			UnityEngine.UI.GridLayoutGroup self=(UnityEngine.UI.GridLayoutGroup)checkSelf(l);
			UnityEngine.UI.GridLayoutGroup.Constraint v;
			checkEnum(l,2,out v);
			self.constraint=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_constraintCount(IntPtr l) {
		try {
			UnityEngine.UI.GridLayoutGroup self=(UnityEngine.UI.GridLayoutGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.constraintCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_constraintCount(IntPtr l) {
		try {
			UnityEngine.UI.GridLayoutGroup self=(UnityEngine.UI.GridLayoutGroup)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.constraintCount=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.GridLayoutGroup");
		addMember(l,CalculateLayoutInputHorizontal);
		addMember(l,CalculateLayoutInputVertical);
		addMember(l,SetLayoutHorizontal);
		addMember(l,SetLayoutVertical);
		addMember(l,"startCorner",get_startCorner,set_startCorner,true);
		addMember(l,"startAxis",get_startAxis,set_startAxis,true);
		addMember(l,"cellSize",get_cellSize,set_cellSize,true);
		addMember(l,"spacing",get_spacing,set_spacing,true);
		addMember(l,"constraint",get_constraint,set_constraint,true);
		addMember(l,"constraintCount",get_constraintCount,set_constraintCount,true);
		addMember(l,op_Equality);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.GridLayoutGroup),typeof(UnityEngine.UI.LayoutGroup));
	}
}
