﻿using System;
using System.Collections.Generic;


// sdk发送的事件类型
public enum SDKEventType
{

/**error*/
	EVENT_ERROR					=0,
/**成功登陆 消息 发送 TypeOCLoginData 类型数据*/
	EVENT_LOGIN_SUCCESS 		=1 ,
/**获得 支付结果消息 发送 TypeOCPayResultData 类型数据*/
	EVENT_PAY_RESULT 		    =2,
	/**用户登出消息 */
	EVENT_LOGOUT          		=3,
/**平台更新检测完毕*/
	EVENT_UPDATE_FINISH   		=4,
	/***SDK的init函数执行完毕后消息*/
	EVENT_INIT_FINISH			=5,
	/**SDK重新登录成功后，需要重新格式化游戏消息*/
	EVENT_RELOGIN				=6,
	/**取消退出游戏行为返回游戏界面*/
	EVENT_CANCEL_EXIT_GAME		=7,
	/**收到本地推送通知*/
	EVENT_RECEIVE_LOCAL_PUSH	=8,
	/**收到分享的结果*/
	EVENT_SHARE_RESULT			=9,
	/**收到好友列表的结果*/
	EVENT_GET_FRIEND_RESULT 	=10,
	/*额外功能通知 */
	Event_EXTRA_FUNCTION = 11

}

//用作被继承的基本数据类型
public class SDKBaseData
{
    private static int ins_key_count = 0;
    private Dictionary<string, object> _attMap = null;

    public SDKBaseData()
    {
        if (null == _attMap) _attMap = new Dictionary<string, object>();
        SetData("data_ins_key", ins_key_count.ToString());
        ins_key_count++;
    }

    public SDKBaseData(Dictionary<string, object> dict)
    {
        _attMap = dict;
        SetData("data_ins_key", ins_key_count.ToString());
        ins_key_count++;
    }

    public Dictionary<string,object> attMap()
    {
        return _attMap;
    }
    public void SetData(string attName, SDKPushRepeatIntervalType enumValue)
    {
        this.SetData(attName, (int)enumValue);
    }
    /**设置一个boolean值*/
    public void SetData(string attName, Boolean boolValue)
    {
        if (boolValue)
            this.SetData(attName, "1");
        else
            this.SetData(attName, "0");
    }
    /**设置一个int值*/
    public void SetData(string attName, int intValue)
    {
        this.SetData(attName, intValue + "");
    }

    /// <summary>
    /// 设置一个string值
    /// </summary>
    public void SetData(string attName, string attValue)
    {
        if (null == _attMap) _attMap = new Dictionary<string, object>();

        if (_attMap.ContainsKey(attName))
            _attMap[attName] = attValue;
        else
            _attMap.Add(attName, attValue);

    }

    /**
     * GET String Data 
     * 
     */
    public string GetData(string attName)
    {
        if (null == _attMap) _attMap = new Dictionary<string, object>();
        string outStr = "";

        if (_attMap.ContainsKey(attName))
            outStr = _attMap[attName].ToString();

        return outStr;

    }
    /***
	 * Get int data
	 * 
	 */
    public int GetInt(string attName)
    {
        string value = GetData(attName);
        int i = 0;
        int.TryParse(value, out i);
        return i;
    }
    /***
	 * get bool data ; 0 is false else is true
	 */
    public bool GetBool(string attName)
    {
        int value = GetInt(attName);
        if (1 == value)
			return true;
        else
			return false;
    }
    public string DataToString()
    {
        if (null == _attMap) _attMap = new Dictionary<string, object>();

        string outStr = MiniJSON.Json.Serialize(_attMap);
        return outStr;
    }

    public void StringToData(string _in_data)
    {
        if (null == _attMap) _attMap = new Dictionary<string, object>();
        _attMap.Clear();
        if (null == _in_data || "" == _in_data)
            _in_data = "{}";


        _attMap = MiniJSON.Json.Deserialize(_in_data) as Dictionary<string, object>;

//        System.Console.Write(_attMap.ToString());
    }
    public void copyData(SDKBaseData _in_data)
    {
        StringToData(_in_data.DataToString());
    }
    public void freshSign()
    {
        string cacheStr = "";
        foreach (string key in _attMap.Keys)
        {
            if ("data_ins_key" == key)
                continue;

            cacheStr += _attMap[key].ToString()+"|";
        }
		cacheStr = OneGameSDKTool.StringTool.MD5StringByString (cacheStr);
        this.SetData("sign", cacheStr);
    }
}

//
//Event Arguments类
public class SDKTypeEvent:EventArgs
{
	/// <summary>
	/// The type of the evt.
	/// </summary>
	public SDKEventType evtType;
	/// <summary>
	/// The evt data.
	/// </summary>
	public SDKBaseData evtData;
	/// <summary>
	/// Initializes a new instance of the <see cref="U3DTypeEvent"/> class.
	/// </summary>
	/// <param name="_in_type">_in_type.</param>
	/// <param name="_in_data">_in_data.</param>
	public SDKTypeEvent(SDKEventType _in_type,SDKBaseData _in_data)
	{
		evtType = _in_type;
		evtData = _in_data;
	}
	public SDKTypeEvent(SDKEventType _in_type)
	{
		evtType = _in_type;
		evtData = null;
	}
}

/// 委托（delegate）的方法签名（method signature
public delegate void U3DTypeEventDelegate( SDKTypeEvent evt);

//各个平台自己的信息数据 用在init中
//public class U3DTypePlatformData :SDKBaseData
//{
//	/// The app ID.
//	public string 	appID;
//	/// The app key.
//	public string  	appKey;
//	/// The redirect UR.
//	public string 	redirectURI;                    //默认值@""
//
//	public string	secretKey;
//	/// The channel I.
//	public string  	channelID;					//qu dao sdk id
//	/// The indentf.
//	public string  	indentf;
//
//
//	/// The is orientation landscape game.
//	public bool IsOrientationLandscapeGame;            //是否横向游戏 默认值 false
//	/// The is device orientation landscape left.
//	public bool IsDeviceOrientationLandscapeLeft;      //是否支持 home键在 左 侧 默认值 true
//	/// The is device orientation landscape right
//	public bool IsDeviceOrientationLandscapeRight;     //是否支持 home键在 右 侧 默认值 true
//	/// The is device orientation portrait upside.
//	public bool IsDeviceOrientationPortraitUpside;     //是否支持 home键在 上 侧 默认值 true
//	/// The is device orientation portrait down.
//	public bool IsDeviceOrientationPortraitDown;       //是否支持 home键在 下 侧 默认值 true
//	
//	/// <summary>
//	/// The is N slog data.
//	/// </summary>
//	public bool IsNSlogData;                           //是否输出log信息 默认值 false
//	/// <summary>
//	/// The is long comet.
//	/// </summary>
//	public bool IsLongComet;                        //是否是长链接   默认值 false
//
//	/// <summary>
//	/// The is open recharge.
//	/// </summary>
//	public bool IsOpenRecharge;                        //是否开启充值    默认值 true
//	/// <summary>
//	/// The is log out push login view.
//	/// </summary>
//	public bool IsLogOutPushLoginView;              //当登出时 是否弹出登录界面 默认值 false
//	/// <summary>
//	/// The close recharge alert message.
//	/// </summary>
//	public string closeRechargeAlertMessage;     //充值未开放时的提示信息  默认值 @"充值为开启"
//
//	/// <summary>
//	/// The name of the android package.
//	/// </summary>
//	public string AndroidPackageName;			//main activi name for android 
//
//	public string 	SDKName;
//	public string	platform;
//	public string 	version;
//	public string	payCallBackUrl;
//	public string 	bundleIdentifier;
//
//	/// <summary>
//	/// The base recharge amount.
//	/// </summary>
//	public int  baseRechargeAmount;

	/// <summary>
	/// The evt delegate.
	/// </summary>
//	public U3DTypeEventDelegate evtDelegate ;

	/// <summary>
	/// Initializes a new instance of the <see cref="U3DTypePlatformData"/> class.
	/// </summary>
//	public U3DTypePlatformData()
//	{
//
//		appID = "";
//		appKey = "";
//		secretKey="";
//		redirectURI = "";
//		channelID="";
//		indentf = "";
//
//
//		IsOrientationLandscapeGame = false;
//		IsDeviceOrientationLandscapeLeft = true;
//		IsDeviceOrientationLandscapeRight = true;
//		IsDeviceOrientationPortraitUpside = true;
//		IsDeviceOrientationPortraitDown = true;
//		
//		IsNSlogData = false;
//		IsLongComet = false;
//		
//		IsOpenRecharge = true;
//		IsLogOutPushLoginView = false;
//		
//		closeRechargeAlertMessage="充值为开启";
//
//		AndroidPackageName = "com.unity3d.player.UnityPlayer";
//		baseRechargeAmount = 10;
//
//		evtDelegate = null;
//
//
//	}
//}

//登录时需要用到 user info 和反馈的数据
//public class U3DTypeUserData :SDKBaseData
//{
//	//////////////////用户信息/////////////
//	//用户id
//	/// <summary>
//	/// The user I.
//	/// </summary>
//	public string userID;
//	//用户名字
//	/// <summary>
//	/// The name of the user.
//	/// </summary>
//	public string userName;
//	//用户密码
//	/// <summary>
//	/// The user pass word.
//	/// </summary>
//	public string userPassWord;
//	//用户验证用的令牌
//	/// <summary>
//	/// The user token.
//	/// </summary>
//	public string userToken;
//
//	public string userSessionID;
//
//	//////////////////角色信息//////////////
//	//用户登录后的角色id
//	/// <summary>
//	/// The role I.
//	/// </summary>
//	public string roleID;
//	//用户登录后的角色名字
//	/// <summary>
//	/// The name of the role.
//	/// </summary>
//	public string roleName;
//
//	/// <summary>
//	/// The zone I.
//	/// </summary>
//	public string zoneID;//如果有分大区 则填写大区id
//	/// <summary>
//	/// The sever I.
//	/// </summary>
//	public string severID;//如果有分服务器 则填写服务器id
//
//	/////////////////额外信息//////////////
//	//平台的额外参数
//	/// <summary>
//	/// The extra arguments.
//	/// </summary>
//	public string extraArgs;
	/// <summary>
	/// Initializes a new instance of the <see cref="U3DTypeLoginData"/> class.
	/// </summary>
//	public U3DTypeUserData()
//	{
//		userID = "";
//		userName = "";
//		userPassWord = "";
//		userSessionID="";
//		userToken = "";
//		roleID = "";
//		roleName = "";
//		zoneID="";
//		severID="";
//		extraArgs = "";
//	}
//}

//支付 类型数据
//public class U3DTypePayData :SDKBaseData
//{
//	/////////////////bill data///////////
//	public float realPrice;//实际购买价格
//	/// <summary>
//	/// The orgin price.
//	/// </summary>
//	public float orginPrice;//原价
//	/// <summary>
//	/// The discount.
//	/// </summary>
//	public float discount;//折扣比例 n％
//	/// <summary>
//	/// The item count.
//	/// </summary>
//	public int   itemCount;// item counter number
//	
//	/// <summary>
//	/// The bill number.
//	/// </summary>
//	public string billNumber;//商品订单号 目前本地生成的订单号使用的是uuuid
//	/// <summary>
//	/// The name of the bill.
//	/// </summary>
//	public string billName;//商品名字
//	/// <summary>
//	/// The bill desc.
//	/// </summary>
//	public string billDesc;//商品描述
//		
//	/////////////////role data////////////
//	public string zoneID;//如果有分大区 则填写大区id
//	/// <summary>
//	/// The sever I.
//	/// </summary>
//	public string severID;//如果有分服务器 则填写服务器id
//	/// <summary>
//	/// The role I.
//	/// </summary>
//	public string roleID;//角色id
//	/// <summary>
//	/// The name of the role.
//	/// </summary>
//	public string roleName;//角色名字
//	
//	/// <summary>
//	/// The extra arguments.
//	/// </summary>
//	public string extraArgs;//如果平台允许
//	/// <summary>
//	/// Initializes a new instance of the <see cref="U3DTypePayData"/> class.
//	/// </summary>
//	public U3DTypePayData()
//	{
//		realPrice=0.0f;
//		orginPrice=0.0f;
//		discount=100.0f;
//		itemCount =1;
//
//		billNumber=System.Guid.NewGuid().ToString();
//
//		billName="";
//		billDesc="";
//		
//		zoneID="0";
//		severID="";
//		roleID="0";
//		roleName="";
//		
//		extraArgs="";
//	}
//}
//支付结果
//public class U3DTypePayResultData :SDKBaseData
//{
//	/// <summary>
//	/// The is success.
//	/// </summary>
//	public bool isSuccess;//是否支付成功
//	
//	/// <summary>
//	/// The reason.
//	/// </summary>
//	public string reason;// 得到该结果的原因
//	
//	/// <summary>
//	/// The extra argument.
//	/// </summary>
//	public string extraArg;//额外参数
//}
//分享类型数据
//public class U3DTypeShareData:SDKBaseData
//{
//	/// <summary>
//	/// The sender.
//	/// </summary>
//	public string sender;		//分享的 发送者
//	/// <summary>
//	/// The receiver.
//	/// </summary>
//	public string receiver;		//分享的 接受者
//	/// <summary>
//	/// The info title.
//	/// </summary>
//	public string infoTitle;	//分享的标题
//	/// <summary>
//	/// The content of the info.
//	/// </summary>
//	public string infoContent;	//分享的文字内容
//	/// <summary>
//	/// The image URL.
//	/// </summary>
//	public string imgUrl;		//分享图片的 url
//
//	/// <summary>
//	/// The type of the share.
//	/// </summary>
//	public string shareType;		//分享的类型

//}

