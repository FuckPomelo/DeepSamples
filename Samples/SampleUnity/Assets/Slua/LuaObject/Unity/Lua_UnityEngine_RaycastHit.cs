﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_RaycastHit : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.RaycastHit o;
			o=new UnityEngine.RaycastHit();
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
	static public int get_point(IntPtr l) {
		try {
			UnityEngine.RaycastHit self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.point);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_point(IntPtr l) {
		try {
			UnityEngine.RaycastHit self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.point=v;
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
	static public int get_normal(IntPtr l) {
		try {
			UnityEngine.RaycastHit self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.normal);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_normal(IntPtr l) {
		try {
			UnityEngine.RaycastHit self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.normal=v;
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
	static public int get_barycentricCoordinate(IntPtr l) {
		try {
			UnityEngine.RaycastHit self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.barycentricCoordinate);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_barycentricCoordinate(IntPtr l) {
		try {
			UnityEngine.RaycastHit self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.barycentricCoordinate=v;
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
	static public int get_distance(IntPtr l) {
		try {
			UnityEngine.RaycastHit self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.distance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_distance(IntPtr l) {
		try {
			UnityEngine.RaycastHit self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.distance=v;
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
	static public int get_triangleIndex(IntPtr l) {
		try {
			UnityEngine.RaycastHit self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.triangleIndex);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_textureCoord(IntPtr l) {
		try {
			UnityEngine.RaycastHit self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.textureCoord);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_textureCoord2(IntPtr l) {
		try {
			UnityEngine.RaycastHit self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.textureCoord2);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_lightmapCoord(IntPtr l) {
		try {
			UnityEngine.RaycastHit self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.lightmapCoord);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_collider(IntPtr l) {
		try {
			UnityEngine.RaycastHit self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.collider);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_rigidbody(IntPtr l) {
		try {
			UnityEngine.RaycastHit self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.rigidbody);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_transform(IntPtr l) {
		try {
			UnityEngine.RaycastHit self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.transform);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.RaycastHit");
		addMember(l,"point",get_point,set_point,true);
		addMember(l,"normal",get_normal,set_normal,true);
		addMember(l,"barycentricCoordinate",get_barycentricCoordinate,set_barycentricCoordinate,true);
		addMember(l,"distance",get_distance,set_distance,true);
		addMember(l,"triangleIndex",get_triangleIndex,null,true);
		addMember(l,"textureCoord",get_textureCoord,null,true);
		addMember(l,"textureCoord2",get_textureCoord2,null,true);
		addMember(l,"lightmapCoord",get_lightmapCoord,null,true);
		addMember(l,"collider",get_collider,null,true);
		addMember(l,"rigidbody",get_rigidbody,null,true);
		addMember(l,"transform",get_transform,null,true);
		addMember(l,op_Equality);
		createTypeMetatable(l,constructor, typeof(UnityEngine.RaycastHit),typeof(System.ValueType));
	}
}
