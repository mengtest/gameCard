﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UITable : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UITable o;
			o=new UITable();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetChildList(IntPtr l) {
		try {
			UITable self=(UITable)checkSelf(l);
			var ret=self.GetChildList();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Reposition(IntPtr l) {
		try {
			UITable self=(UITable)checkSelf(l);
			self.Reposition();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_columns(IntPtr l) {
		try {
			UITable self=(UITable)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.columns);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_columns(IntPtr l) {
		try {
			UITable self=(UITable)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.columns=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_direction(IntPtr l) {
		try {
			UITable self=(UITable)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.direction);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_direction(IntPtr l) {
		try {
			UITable self=(UITable)checkSelf(l);
			UITable.Direction v;
			checkEnum(l,2,out v);
			self.direction=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sorting(IntPtr l) {
		try {
			UITable self=(UITable)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.sorting);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sorting(IntPtr l) {
		try {
			UITable self=(UITable)checkSelf(l);
			UITable.Sorting v;
			checkEnum(l,2,out v);
			self.sorting=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_pivot(IntPtr l) {
		try {
			UITable self=(UITable)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.pivot);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_pivot(IntPtr l) {
		try {
			UITable self=(UITable)checkSelf(l);
			UIWidget.Pivot v;
			checkEnum(l,2,out v);
			self.pivot=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cellAlignment(IntPtr l) {
		try {
			UITable self=(UITable)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.cellAlignment);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cellAlignment(IntPtr l) {
		try {
			UITable self=(UITable)checkSelf(l);
			UIWidget.Pivot v;
			checkEnum(l,2,out v);
			self.cellAlignment=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_hideInactive(IntPtr l) {
		try {
			UITable self=(UITable)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.hideInactive);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_hideInactive(IntPtr l) {
		try {
			UITable self=(UITable)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.hideInactive=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_keepWithinPanel(IntPtr l) {
		try {
			UITable self=(UITable)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.keepWithinPanel);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_keepWithinPanel(IntPtr l) {
		try {
			UITable self=(UITable)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.keepWithinPanel=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_padding(IntPtr l) {
		try {
			UITable self=(UITable)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.padding);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_padding(IntPtr l) {
		try {
			UITable self=(UITable)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.padding=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onReposition(IntPtr l) {
		try {
			UITable self=(UITable)checkSelf(l);
			UITable.OnReposition v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.onReposition=v;
			else if(op==1) self.onReposition+=v;
			else if(op==2) self.onReposition-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onCustomSort(IntPtr l) {
		try {
			UITable self=(UITable)checkSelf(l);
			System.Comparison<UnityEngine.Transform> v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.onCustomSort=v;
			else if(op==1) self.onCustomSort+=v;
			else if(op==2) self.onCustomSort-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_repositionNow(IntPtr l) {
		try {
			UITable self=(UITable)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.repositionNow=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UITable");
		addMember(l,GetChildList);
		addMember(l,Reposition);
		addMember(l,"columns",get_columns,set_columns,true);
		addMember(l,"direction",get_direction,set_direction,true);
		addMember(l,"sorting",get_sorting,set_sorting,true);
		addMember(l,"pivot",get_pivot,set_pivot,true);
		addMember(l,"cellAlignment",get_cellAlignment,set_cellAlignment,true);
		addMember(l,"hideInactive",get_hideInactive,set_hideInactive,true);
		addMember(l,"keepWithinPanel",get_keepWithinPanel,set_keepWithinPanel,true);
		addMember(l,"padding",get_padding,set_padding,true);
		addMember(l,"onReposition",null,set_onReposition,true);
		addMember(l,"onCustomSort",null,set_onCustomSort,true);
		addMember(l,"repositionNow",null,set_repositionNow,true);
		createTypeMetatable(l,constructor, typeof(UITable),typeof(UIWidgetContainer));
	}
}
