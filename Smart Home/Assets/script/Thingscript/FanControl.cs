using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 排风扇动画控制
/// </summary>
public class FanControl : MonoSingleton<FanControl>
{
    #region 定义的字段属性方法

    /// <summary>
    /// 定义动画组件
    /// </summary>
    private Animator ani;
    public bool State=true;
    #endregion

    #region Unity回调方法

    /// <summary>
    /// 重写父类的单例方法
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        // 初始化动画组件
        ani = this.GetComponent<Animator>();
    }
    
    /*
    void Start()
    {
        
        if (PlayerPrefs.GetString(MakeSure.instance.linkState).Equals("确定"))
        {
            // 初始化的时候判断外部传入的数据，根据传入的数据初始化当前排风扇的额状态
            if (UnityToAndroid.instance.fan.Equals("true"))
            {
                OpenFan();
            }
            else if (UnityToAndroid.instance.fan.Equals("false"))
            {
                CloseFan();
            }
        }
    }

    private void FixedUpdate()
    {
        if (PlayerPrefs.GetString(MakeSure.instance.linkState).Equals("确定"))
        {
            // 初始化的时候判断外部传入的数据，根据传入的数据初始化当前排风扇的额状态
            if (UnityToAndroid.instance.fan.Equals("true"))
            {
                OpenFan();
            }
            else if (UnityToAndroid.instance.fan.Equals("false"))
            {
                CloseFan();
            }
        }
    }
    */

    #endregion

    #region 方法

    /// <summary>
    /// 排风扇的动画开启的方法
    /// </summary>
    public void OpenFan()
    {
        ani.SetBool("Open", true);
    }

    /// <summary>
    /// 排风扇的动画关闭的方法
    /// </summary>
    public void CloseFan()
    {
        ani.SetBool("Open", false);
    }

    /// <summary>
    /// 如果和外部链接，根据外部传入的数据决定风扇的开关
    /// </summary>
    /// <param name="key">开关</param>
    public void Link_Fan(string key)
    {
        // 先想外部发送命令
        UnityToAndroid.instance.SendCommand(13, key);
    }
    #endregion
}
