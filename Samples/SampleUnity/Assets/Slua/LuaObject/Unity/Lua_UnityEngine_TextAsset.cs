﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_TextAsset : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.TextAsset o;
			o=new UnityEngine.TextAsset();
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
	static public int get_text(IntPtr l) {
		try {
			UnityEngine.TextAsset self=(UnityEngine.TextAsset)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.text);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_bytes(IntPtr l) {
		try {
			UnityEngine.TextAsset self=(UnityEngine.TextAsset)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.bytes);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.TextAsset");
		addMember(l,"text",get_text,null,true);
		addMember(l,"bytes",get_bytes,null,true);
		addMember(l,op_Equality);
		createTypeMetatable(l,constructor, typeof(UnityEngine.TextAsset),typeof(UnityEngine.Object));
	}
}
