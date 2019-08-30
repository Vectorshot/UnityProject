using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
// 注意：切换场景要引入UnityEngine.SceneManagement命名空间
using UnityEngine.SceneManagement;

///<summary>
/// 选择是否连接设备
///</summary>
public class MakeSure : MonoBehaviour
{
    #region 定义的变量字段和属性

    /// <summary>
    /// 单例
    /// </summary>
    public static MakeSure instance;

    [HideInInspector]
    public string linkState = "连接设备";

    // 切换场景不删除的物体
    public GameObject gameObj;

    #endregion

    #region Unity回调方法

    void Awake()
    {
        instance = this;
    }
    #endregion

    #region 方法

    /// <summary>
    /// 如果点击了确定，调用该方法
    /// </summary>
    public void SubStart()
    {
        // 先将连接状态改为连接
        PlayerPrefs.SetString(linkState, "确定");
        // 进入场景的时候就开始绑定服务
        UnityToAndroid.instance.InitBindService();
        Invoke("Waitting",2f);
    }

    void Waitting()
    {
        // 调用UnityToAndroid的绑定服务方法
        UnityToAndroid.instance.BindState();
        // 绑定成功之后
        if (UnityToAndroid.instance.isBindSuccess == "BindSuccess")
        {
            // 切换到设备选择场景中
            ChangeScene();
        }
        
    }

    // 等待一段时间，然后切换场景
    public void ChangeScene()
    {
        // 切换到设备选择场景
        SceneManager.LoadScene("DevicesChoice", LoadSceneMode.Single);
        // 切换场景不删除物体
        DontDestroyOnLoad(gameObj);
    }

    /// <summary>
    /// 点击取消的时候，调用该方法
    /// </summary>
    public void Cancle()
    {
        // 先将状态切换成为未连接
        PlayerPrefs.SetString(linkState, "取消");
        // 如果点击取消，不进行下一步操作，直接跳转场景
        // 切换场景
        SceneManager.LoadScene("Loading", LoadSceneMode.Single);
        // 切换场景不删除
        DontDestroyOnLoad(gameObj);
    }

    #endregion
}