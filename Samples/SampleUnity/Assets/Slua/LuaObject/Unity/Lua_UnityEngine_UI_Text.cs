﻿using System;
using SLua;
using System.Collections.Generic;
using DG.Tweening;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_Text : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int FontTextureChanged(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			self.FontTextureChanged();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetGenerationSettings(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			UnityEngine.Vector2 a1;
			checkType(l,2,out a1);
			var ret=self.GetGenerationSettings(a1);
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
	static public int CalculateLayoutInputHorizontal(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
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
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
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
	static public int DOColor(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			UnityEngine.Color a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=self.DOColor(a2,a3);
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
	static public int DOFade(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			System.Single a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=self.DOFade(a2,a3);
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
	static public int DOText(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			System.String a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			System.Boolean a4;
			checkType(l,4,out a4);
			DG.Tweening.ScrambleMode a5;
			checkEnum(l,5,out a5);
			System.String a6;
			checkType(l,6,out a6);
			var ret=self.DOText(a2,a3,a4,a5,a6);
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
	static public int DOBlendableColor(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			UnityEngine.Color a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=self.DOBlendableColor(a2,a3);
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
	static public int GetTextAnchorPivot_s(IntPtr l) {
		try {
			UnityEngine.TextAnchor a1;
			checkEnum(l,1,out a1);
			var ret=UnityEngine.UI.Text.GetTextAnchorPivot(a1);
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
	static public int get_cachedTextGenerator(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.cachedTextGenerator);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_cachedTextGeneratorForLayout(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.cachedTextGeneratorForLayout);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_mainTexture(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.mainTexture);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_font(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.font);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_font(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			UnityEngine.Font v;
			checkType(l,2,out v);
			self.font=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_text(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
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
	static public int set_text(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.text=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportRichText(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.supportRichText);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_supportRichText(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.supportRichText=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_resizeTextForBestFit(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.resizeTextForBestFit);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_resizeTextForBestFit(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.resizeTextForBestFit=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_resizeTextMinSize(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.resizeTextMinSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_resizeTextMinSize(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.resizeTextMinSize=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_resizeTextMaxSize(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.resizeTextMaxSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_resizeTextMaxSize(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.resizeTextMaxSize=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_alignment(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.alignment);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_alignment(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			UnityEngine.TextAnchor v;
			checkEnum(l,2,out v);
			self.alignment=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_alignByGeometry(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.alignByGeometry);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_alignByGeometry(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.alignByGeometry=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_fontSize(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.fontSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_fontSize(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.fontSize=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_horizontalOverflow(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.horizontalOverflow);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_horizontalOverflow(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			UnityEngine.HorizontalWrapMode v;
			checkEnum(l,2,out v);
			self.horizontalOverflow=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_verticalOverflow(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.verticalOverflow);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_verticalOverflow(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			UnityEngine.VerticalWrapMode v;
			checkEnum(l,2,out v);
			self.verticalOverflow=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_lineSpacing(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.lineSpacing);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_lineSpacing(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.lineSpacing=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_fontStyle(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.fontStyle);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_fontStyle(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			UnityEngine.FontStyle v;
			checkEnum(l,2,out v);
			self.fontStyle=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_pixelsPerUnit(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pixelsPerUnit);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_minWidth(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.minWidth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_preferredWidth(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.preferredWidth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_flexibleWidth(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.flexibleWidth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_minHeight(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.minHeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_preferredHeight(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.preferredHeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_flexibleHeight(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.flexibleHeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_layoutPriority(IntPtr l) {
		try {
			UnityEngine.UI.Text self=(UnityEngine.UI.Text)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.layoutPriority);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Text");
		addMember(l,FontTextureChanged);
		addMember(l,GetGenerationSettings);
		addMember(l,CalculateLayoutInputHorizontal);
		addMember(l,CalculateLayoutInputVertical);
		addMember(l,DOColor);
		addMember(l,DOFade);
		addMember(l,DOText);
		addMember(l,DOBlendableColor);
		addMember(l,GetTextAnchorPivot_s);
		addMember(l,"cachedTextGenerator",get_cachedTextGenerator,null,true);
		addMember(l,"cachedTextGeneratorForLayout",get_cachedTextGeneratorForLayout,null,true);
		addMember(l,"mainTexture",get_mainTexture,null,true);
		addMember(l,"font",get_font,set_font,true);
		addMember(l,"text",get_text,set_text,true);
		addMember(l,"supportRichText",get_supportRichText,set_supportRichText,true);
		addMember(l,"resizeTextForBestFit",get_resizeTextForBestFit,set_resizeTextForBestFit,true);
		addMember(l,"resizeTextMinSize",get_resizeTextMinSize,set_resizeTextMinSize,true);
		addMember(l,"resizeTextMaxSize",get_resizeTextMaxSize,set_resizeTextMaxSize,true);
		addMember(l,"alignment",get_alignment,set_alignment,true);
		addMember(l,"alignByGeometry",get_alignByGeometry,set_alignByGeometry,true);
		addMember(l,"fontSize",get_fontSize,set_fontSize,true);
		addMember(l,"horizontalOverflow",get_horizontalOverflow,set_horizontalOverflow,true);
		addMember(l,"verticalOverflow",get_verticalOverflow,set_verticalOverflow,true);
		addMember(l,"lineSpacing",get_lineSpacing,set_lineSpacing,true);
		addMember(l,"fontStyle",get_fontStyle,set_fontStyle,true);
		addMember(l,"pixelsPerUnit",get_pixelsPerUnit,null,true);
		addMember(l,"minWidth",get_minWidth,null,true);
		addMember(l,"preferredWidth",get_preferredWidth,null,true);
		addMember(l,"flexibleWidth",get_flexibleWidth,null,true);
		addMember(l,"minHeight",get_minHeight,null,true);
		addMember(l,"preferredHeight",get_preferredHeight,null,true);
		addMember(l,"flexibleHeight",get_flexibleHeight,null,true);
		addMember(l,"layoutPriority",get_layoutPriority,null,true);
		addMember(l,op_Equality);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Text),typeof(UnityEngine.UI.MaskableGraphic));
	}
}
