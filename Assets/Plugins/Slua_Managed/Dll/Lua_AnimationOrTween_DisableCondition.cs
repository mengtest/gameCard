﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_AnimationOrTween_DisableCondition : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"AnimationOrTween.DisableCondition");
		addMember(l,0,"DoNotDisable");
		addMember(l,1,"DisableAfterForward");
		addMember(l,-1,"DisableAfterReverse");
		LuaDLL.lua_pop(l, 1);
	}
}
