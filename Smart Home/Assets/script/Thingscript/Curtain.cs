using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 窗帘实现的方法，动画等
/// </summary>
public class Curtain : MonoBehaviour
{
    #region 定义的方法字段

    // 创建单例
    public static Curtain _instance;

    // 窗帘动画
    private Animator ant;
    #endregion

    #region Unity回调

    void Awake()
    {
        _instance = this;
        // 初始化动画组件
        ant = this.GetComponent<Animator>();
    }

    void Start()
    {
       
        if (PlayerPrefs.GetString(MakeSure.instance.linkState).Equals("确定"))
        {
            string state = UnityToAndroid.instance.curtain;
            // 初始化的时候判断外部传入的数据，根据数据决定当前窗帘的状态
            if (UnityToAndroid.instance.curtain.Equals("0"))
            {
                OpenCurtain();
            }
            else if (UnityToAndroid.instance.curtain.Equals("1"))
            {
                CloseCurtain();
            }
            else
            {
                // ant.Stop();
            }
        }

    }

    private void FixedUpdate()
    {
        if (PlayerPrefs.GetString(MakeSure.instance.linkState).Equals("确定"))
        {
            string state = UnityToAndroid.instance.curtain;
            // 初始化的时候判断外部传入的数据，根据数据决定当前窗帘的状态
            if (UnityToAndroid.instance.curtain.Equals("0"))
            {
                // 如果传回来的字符串是0，就打开窗帘
                OpenCurtain();
            }
            else if (UnityToAndroid.instance.curtain.Equals("1"))
            {
                // 如果是1，就关闭窗帘
                CloseCurtain();
            }
            else
            {
                // 如果是其他，就停止
               //  ant.Stop();
            }
        }
    }

    #endregion

    #region 方法

    /// <summary>
    /// 播放窗帘拉开的动画
    /// </summary>
    public void OpenCurtain()
    {
        ant.SetBool("Open",true);
    }

    /// <summary>
    /// 播放窗帘关闭的动画
    /// </summary>
    public void CloseCurtain()
    {
        ant.SetBool("Open", false);
    }

    /// <summary>
    /// 向窗帘发送命令，然后延迟0.5秒获取当前窗帘的状态进行判断
    /// </summary>
    /// <param name="key">发送命令是开还是关</param>
    public void Link_Curtain(string key)
    {
        UnityToAndroid.instance.SendCommand(16, key);
    }
    #endregion
}
