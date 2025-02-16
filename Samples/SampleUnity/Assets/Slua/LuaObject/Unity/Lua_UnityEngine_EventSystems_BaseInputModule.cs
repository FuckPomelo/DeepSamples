﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_EventSystems_BaseInputModule : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Process(IntPtr l) {
		try {
			UnityEngine.EventSystems.BaseInputModule self=(UnityEngine.EventSystems.BaseInputModule)checkSelf(l);
			self.Process();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int IsPointerOverGameObject(IntPtr l) {
		try {
			UnityEngine.EventSystems.BaseInputModule self=(UnityEngine.EventSystems.BaseInputModule)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.IsPointerOverGameObject(a1);
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
	static public int ShouldActivateModule(IntPtr l) {
		try {
			UnityEngine.EventSystems.BaseInputModule self=(UnityEngine.EventSystems.BaseInputModule)checkSelf(l);
			var ret=self.ShouldActivateModule();
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
	static public int DeactivateModule(IntPtr l) {
		try {
			UnityEngine.EventSystems.BaseInputModule self=(UnityEngine.EventSystems.BaseInputModule)checkSelf(l);
			self.DeactivateModule();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ActivateModule(IntPtr l) {
		try {
			UnityEngine.EventSystems.BaseInputModule self=(UnityEngine.EventSystems.BaseInputModule)checkSelf(l);
			self.ActivateModule();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int UpdateModule(IntPtr l) {
		try {
			UnityEngine.EventSystems.BaseInputModule self=(UnityEngine.EventSystems.BaseInputModule)checkSelf(l);
			self.UpdateModule();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int IsModuleSupported(IntPtr l) {
		try {
			UnityEngine.EventSystems.BaseInputModule self=(UnityEngine.EventSystems.BaseInputModule)checkSelf(l);
			var ret=self.IsModuleSupported();
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
	static public int get_input(IntPtr l) {
		try {
			UnityEngine.EventSystems.BaseInputModule self=(UnityEngine.EventSystems.BaseInputModule)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.input);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.EventSystems.BaseInputModule");
		addMember(l,Process);
		addMember(l,IsPointerOverGameObject);
		addMember(l,ShouldActivateModule);
		addMember(l,DeactivateModule);
		addMember(l,ActivateModule);
		addMember(l,UpdateModule);
		addMember(l,IsModuleSupported);
		addMember(l,"input",get_input,null,true);
		addMember(l,op_Equality);
		createTypeMetatable(l,null, typeof(UnityEngine.EventSystems.BaseInputModule),typeof(UnityEngine.EventSystems.UIBehaviour));
	}
}
