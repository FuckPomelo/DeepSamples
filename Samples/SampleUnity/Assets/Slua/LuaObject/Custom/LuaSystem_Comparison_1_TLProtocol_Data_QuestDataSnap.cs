﻿
using System;
using System.Collections.Generic;
namespace SLua
{
    public partial class LuaDelegation : LuaObject
    {

        static internal int Lua_System_Comparison_1_TLProtocol_Data_QuestDataSnap(LuaFunction ld ,TLProtocol.Data.QuestDataSnap a1,TLProtocol.Data.QuestDataSnap a2) {
            IntPtr l = ld.L;
            int error = pushTry(l);

			pushValue(l,a1);
			pushValue(l,a2);
			ld.pcall(2, error);
			int ret;
			checkType(l,error+1,out ret);
			LuaDLL.lua_settop(l, error-1);
			return ret;
		}
	}
}
