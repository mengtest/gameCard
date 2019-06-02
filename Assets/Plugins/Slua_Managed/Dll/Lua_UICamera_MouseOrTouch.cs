﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UICamera_MouseOrTouch : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UICamera.MouseOrTouch o;
			o=new UICamera.MouseOrTouch();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_key(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.key);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_key(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			UnityEngine.KeyCode v;
			checkEnum(l,2,out v);
			self.key=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_pos(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pos);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_pos(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.pos=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lastPos(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.lastPos);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lastPos(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.lastPos=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_delta(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.delta);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_delta(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.delta=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_totalDelta(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.totalDelta);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_totalDelta(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.totalDelta=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_pressedCam(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pressedCam);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_pressedCam(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			UnityEngine.Camera v;
			checkType(l,2,out v);
			self.pressedCam=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_last(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.last);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_last(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.last=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_current(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.current);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_current(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.current=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_pressed(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pressed);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_pressed(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.pressed=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_dragged(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.dragged);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_dragged(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.dragged=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_pressTime(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pressTime);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_pressTime(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.pressTime=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_clickTime(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.clickTime);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_clickTime(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.clickTime=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_clickNotification(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.clickNotification);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_clickNotification(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			UICamera.ClickNotification v;
			checkEnum(l,2,out v);
			self.clickNotification=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_touchBegan(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.touchBegan);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_touchBegan(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.touchBegan=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_pressStarted(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pressStarted);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_pressStarted(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.pressStarted=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_dragStarted(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.dragStarted);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_dragStarted(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.dragStarted=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ignoreDelta(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.ignoreDelta);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ignoreDelta(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.ignoreDelta=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_deltaTime(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.deltaTime);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isOverUI(IntPtr l) {
		try {
			UICamera.MouseOrTouch self=(UICamera.MouseOrTouch)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isOverUI);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UICamera.MouseOrTouch");
		addMember(l,"key",get_key,set_key,true);
		addMember(l,"pos",get_pos,set_pos,true);
		addMember(l,"lastPos",get_lastPos,set_lastPos,true);
		addMember(l,"delta",get_delta,set_delta,true);
		addMember(l,"totalDelta",get_totalDelta,set_totalDelta,true);
		addMember(l,"pressedCam",get_pressedCam,set_pressedCam,true);
		addMember(l,"last",get_last,set_last,true);
		addMember(l,"current",get_current,set_current,true);
		addMember(l,"pressed",get_pressed,set_pressed,true);
		addMember(l,"dragged",get_dragged,set_dragged,true);
		addMember(l,"pressTime",get_pressTime,set_pressTime,true);
		addMember(l,"clickTime",get_clickTime,set_clickTime,true);
		addMember(l,"clickNotification",get_clickNotification,set_clickNotification,true);
		addMember(l,"touchBegan",get_touchBegan,set_touchBegan,true);
		addMember(l,"pressStarted",get_pressStarted,set_pressStarted,true);
		addMember(l,"dragStarted",get_dragStarted,set_dragStarted,true);
		addMember(l,"ignoreDelta",get_ignoreDelta,set_ignoreDelta,true);
		addMember(l,"deltaTime",get_deltaTime,null,true);
		addMember(l,"isOverUI",get_isOverUI,null,true);
		createTypeMetatable(l,constructor, typeof(UICamera.MouseOrTouch));
	}
}
