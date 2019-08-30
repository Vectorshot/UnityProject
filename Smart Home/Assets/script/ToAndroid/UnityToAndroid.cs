using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ��Androidʵ�ֽ���
/// �̳���Unity������
/// </summary>
public class UnityToAndroid : MonoSingleton<UnityToAndroid>
{
    #region �ֶ�����
    // ��ǰ�豸״̬
    private string state;

    // �Ƿ�󶨳ɹ�
    [HideInInspector]
    public string isBindSuccess;

    // �Ƿ��ĳɹ�
    [HideInInspector]
    public string isScbScribe;

    // ���ڴ洢�豸����
    public static string devicesName;
    // ���ڴ洢�豸���б�
    [HideInInspector]
    public static  string[] devicesList;
    // �豸�ĵ�һ������ 
    [HideInInspector]
    public static  List<string> deviceState = new List<string>();

    // ���Բ���ʾ��Inspector����ϣ���ֹ�ⲿ�޸�
    [HideInInspector]
    // ��ǰ�豸�б�
    public string allDeviceList;

    // ��ʱ��
    [HideInInspector]
    public float time = 0f;

    // ����AndroidJavaClass
    [HideInInspector]
    public AndroidJavaClass jc;
    // ����AndroidJavaObject
    [HideInInspector]
    public AndroidJavaObject jo;

    [HideInInspector]
    public string lamp;// �ƹ�
    [HideInInspector]
    public string alertor;// ������
    [HideInInspector]
    public string fan;// ����
    [HideInInspector]
    public string curtain;// ����
    [HideInInspector]
    public string temperature;// �¶�
    [HideInInspector]
    public string humidity;// ʪ��
    [HideInInspector]
    public string pm;// PM2.5
    [HideInInspector]
    public string light_innsity;// ����ǿ��
    [HideInInspector]
    public string gas;// ��ȼ��Ũ��


    [HideInInspector]
    public  int num = 0;
    // �������Ҫ��ȡ״̬���豸
    [HideInInspector]
    public static int deviceNum = 0;
    #endregion

    #region Unity�ص�

    // ��д����Awake������ʵ�ֵ���
    protected override void Awake()
    {
        base.Awake();
        // ��ʼ��jc��jo
        jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
    }

    private void FixedUpdate()
    {
    // ��������ȷ����ť
    if (PlayerPrefs.GetString(MakeSure.instance.linkState).Equals("ȷ��"))
    {
        // ��ȡ���ĵ�״̬
        SubScribe();
        // ������ĳɹ�
        if (isScbScribe == "���ĳɹ�")
        {
        // ��ȡ�豸��״̬
        GetDeviceState(deviceNum);
        // ��ȡ���豸��״̬
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

    #region Android����
    /// <summary>
    /// �󶨷���
    /// </summary>
    public void InitBindService()
    {
        jo.Call("initBindService");
    }
    /// <summary>
    /// �жϰ��Ƿ�ɹ�
    /// </summary>
    public void BindState()
    {
        isBindSuccess = jo.Call<string>("getState", 110);
    }
    /// <summary>
    /// ��ȡ�豸�б�
    /// </summary>
    public  void GetStates()
    {
        // ��÷��ص��豸�б�����ֵΪ�ַ���
         allDeviceList = jo.Call<string>("getState", 3);
        PlayerPrefs.SetString(devicesName, allDeviceList);
        // ���ַ����ָ�����õ��豸�б����洢��devicesList������
        devicesList = allDeviceList.Split(';');
        for (num = 0; num < devicesList.Length - 1; num++)
        {
            // ��Android���ع������豸�ַ������зָ�
            string deviceName = devicesList[num].ToString().Split(',')[0].ToString();
            // ���豸�洢��deviceState�б���
            deviceState.Add(deviceName);
        }
    }
    /// <summary>
    /// �����豸
    /// </summary>
    public void SetDeviceList(string device_Name)
    {
        jo.Call("sendCommand", 4, device_Name);
    }
    /// <summary>
    /// ���ĸ��豸
    /// </summary>
    public void SubScribeDevice()
    {
        jo.Call("sendCommand", 5, "true");
        // �ӳ�3���ж϶����Ƿ�ִ�гɹ�
        Invoke("SubScribe", 3f);
    }
    /// <summary>
    /// �ж��Ƿ��ĳɹ�
    /// </summary>
    public void SubScribe()
    {
        // ���ĳɹ��Ļ��᷵��"���ĳɹ�"
        isScbScribe = jo.Call<string>("getState", 5);
    }
    /// <summary>
    /// ��ȡ�豸��״̬
    /// </summary>
    public void GetDeviceState(int num)
    {
        jo.Call("sendCommand", 6, deviceState[num]);
    }
    ///<summary>
    /// ���豸��������
    ///</summary>
    public void SendCommand(int key, string value)
    {
        jo.Call("sendCommand", key, value);
    }
    ///<summary>
    /// ȡ������
    ///</summary>
    public void Cancle()
    {
        jo.Call("sendCommand", 5, "false");
    }

    #endregion

}