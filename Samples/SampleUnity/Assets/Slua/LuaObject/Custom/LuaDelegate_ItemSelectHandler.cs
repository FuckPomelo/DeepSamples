﻿
using System;
using System.Collections.Generic;
namespace SLua
{
    public partial class LuaDelegation : LuaObject
    {

        static internal void Lua_ItemSelectHandler(LuaFunction ld ,ItemShow a1,ItemShow a2) {
            IntPtr l = ld.L;
            int error = pushTry(l);

			pushValue(l,a1);
			pushValue(l,a2);
			ld.pcall(2, error);
			LuaDLL.lua_settop(l, error-1);
		}
	}
}
