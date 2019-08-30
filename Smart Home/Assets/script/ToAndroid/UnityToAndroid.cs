using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 和Android实现交互
/// 继承自Unity单例类
/// </summary>
public class UnityToAndroid : MonoSingleton<UnityToAndroid>
{
    #region 字段属性
    // 当前设备状态
    private string state;

    // 是否绑定成功
    [HideInInspector]
    public string isBindSuccess;

    // 是否订阅成功
    [HideInInspector]
    public string isScbScribe;

    // 用于存储设备名字
    public static string devicesName;
    // 用于存储设备的列表
    [HideInInspector]
    public static  string[] devicesList;
    // 设备的第一个属性 
    [HideInInspector]
    public static  List<string> deviceState = new List<string>();

    // 可以不显示在Inspector面板上，防止外部修改
    [HideInInspector]
    // 当前设备列表
    public string allDeviceList;

    // 计时器
    [HideInInspector]
    public float time = 0f;

    // 声明AndroidJavaClass
    [HideInInspector]
    public AndroidJavaClass jc;
    // 声明AndroidJavaObject
    [HideInInspector]
    public AndroidJavaObject jo;

    [HideInInspector]
    public string lamp;// 灯光
    [HideInInspector]
    public string alertor;// 警报器
    [HideInInspector]
    public string fan;// 风扇
    [HideInInspector]
    public string curtain;// 窗帘
    [HideInInspector]
    public string temperature;// 温度
    [HideInInspector]
    public string humidity;// 湿度
    [HideInInspector]
    public string pm;// PM2.5
    [HideInInspector]
    public string light_innsity;// 光照强度
    [HideInInspector]
    public string gas;// 可燃气浓度


    [HideInInspector]
    public  int num = 0;
    // 标记所需要获取状态的设备
    [HideInInspector]
    public static int deviceNum = 0;
    #endregion

    #region Unity回调

    // 重写父类Awake方法，实现单例
    protected override void Awake()
    {
        base.Awake();
        // 初始化jc和jo
        jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
    }

    private void FixedUpdate()
    {
    // 如果点击了确定按钮
    if (PlayerPrefs.GetString(MakeSure.instance.linkState).Equals("确定"))
    {
        // 获取订阅的状态
        SubScribe();
        // 如果订阅成功
        if (isScbScribe == "订阅成功")
        {
        // 获取设备的状态
        GetDeviceState(deviceNum);
        // 获取子设备的状态
        lamp = UnityToAndroid.instance.jo.Call<string>("getState", 11);
        alertor = UnityToAndroid.instance.jo.Call<string>("getState", 14);
        fan = UnityToAndroid.instance.jo.Call<string>("getState", 13);
        curtain = UnityToAndroid.instance.jo.Call<string>("getState", 16);
        temperature = UnityToAndroid.instance.jo.Call<string>("getState", 19);
        humidity = UnityToAndroid.instance.jo.Call<string>("getState", 20);
        pm = UnityToAndroid.instance.jo.Call<string>("getState", 21);
        light_innsity = UnityToAndroid.instance.jo.Call<string>("getState", 22);
        gas = UnityToAndroid.instance.jo.Call<string>("getState", 23);
        }
    }        
    }

    #endregion

    #region Android方法
    /// <summary>
    /// 绑定服务
    /// </summary>
    public void InitBindService()
    {
        jo.Call("initBindService");
    }
    /// <summary>
    /// 判断绑定是否成功
    /// </summary>
    public void BindState()
    {
        isBindSuccess = jo.Call<string>("getState", 110);
    }
    /// <summary>
    /// 获取设备列表
    /// </summary>
    public  void GetStates()
    {
        // 获得返回的设备列表，返回值为字符串
         allDeviceList = jo.Call<string>("getState", 3);
        PlayerPrefs.SetString(devicesName, allDeviceList);
        // 将字符串分割开来，得到设备列表，并存储到devicesList数组中
        devicesList = allDeviceList.Split(';');
        for (num = 0; num < devicesList.Length - 1; num++)
        {
            // 将Android返回过来的设备字符串进行分割
            string deviceName = devicesList[num].ToString().Split(',')[0].ToString();
            // 将设备存储在deviceState列表中
            deviceState.Add(deviceName);
        }
    }
    /// <summary>
    /// 监听设备
    /// </summary>
    public void SetDeviceList(string device_Name)
    {
        jo.Call("sendCommand", 4, device_Name);
    }
    /// <summary>
    /// 订阅该设备
    /// </summary>
    public void SubScribeDevice()
    {
        jo.Call("sendCommand", 5, "true");
        // 延迟3秒判断订阅是否执行成功
        Invoke("SubScribe", 3f);
    }
    /// <summary>
    /// 判断是否订阅成功
    /// </summary>
    public void SubScribe()
    {
        // 订阅成功的话会返回"订阅成功"
        isScbScribe = jo.Call<string>("getState", 5);
    }
    /// <summary>
    /// 获取设备的状态
    /// </summary>
    public void GetDeviceState(int num)
    {
        jo.Call("sendCommand", 6, deviceState[num]);
    }
    ///<summary>
    /// 向设备发送命令
    ///</summary>
    public void SendCommand(int key, string value)
    {
        jo.Call("sendCommand", key, value);
    }
    ///<summary>
    /// 取消订阅
    ///</summary>
    public void Cancle()
    {
        jo.Call("sendCommand", 5, "false");
    }

    #endregion

}