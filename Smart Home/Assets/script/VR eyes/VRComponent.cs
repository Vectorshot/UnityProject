using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// 通过VRResponse传递过来的参数，来判断是什么物体，实现什么操作
/// </summary>
/// 强制使用此脚本的游戏物体必须有Collider
[RequireComponent(typeof(Collider))]
public class VRComponent : MonoBehaviour
{
    #region 变量
    /// <summary>
    /// 交互需要等待的时间
    /// </summary>
	public float waitingTime = 1.5f;

    /// <summary>
    /// 在Inspector面板中隐藏
    /// 是否等待过
    /// </summary>
    [HideInInspector]
    public bool isWaitted = false;

    /// <summary>
    /// 门的动画播放的时间
    /// </summary>
    public float time = 3.5f;

    /// <summary>
    /// 创建单例
    /// </summary>
    public static VRComponent instance;

    /// <summary>
    /// 用于记录是否执行监听订阅操作
    /// </summary>
    public bool isBind = false;
    #endregion

    #region 方法

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// 射线检测之后响应的方法
    /// </summary>
    /// <param name="name">射线检测到的物体名字</param>
    /// <param name="trans">射线检测到的物体的Transform</param>
    public void ResponEvent(string name, Transform trans)
    {
        switch (name)
        {
            /*
            // 点击初始界面的OK
            case "OK":
                {
                    MakeSure.instance.SubStart();
                    break;
                }
            // 点击初始界面的Cancel
            case "Cancel":
                {
                    MakeSure.instance.Cancle();
                    break;
                }
            // 点击UI界面上的开的按钮
            case "OpenImage":
                {
                    UIController._instance.RespondOnUIEvent(trans.parent.name);
                    break;
                }
            // 点击UI界面关的按钮
            case "CloseImage":
                {
                    UIController._instance.RespondOffUIEvent(trans.parent.name);
                    break;
                }
            // 点击了遥控器
            case "Romote":
                {
                    UICanvasShow.instance.IsShow();
                    break;
                }
            // 点击UI面板上的退出按钮
            case "BackImage":
                {
                    UIController._instance.IsShow(false);
                    break;
                }
            // 点击UI面板上的缩放按钮
            case "FoldImage":
                {
                    UIAnimation.instance.FoldOff();
                    break;
                }
            // 点击进门时的指纹机
            case "LivingRoom":
                {
                    // 客厅的门的控制
                    LivingDoorMove.instance.ControllDoor();
                    break;
                }
            // 点击进入厨房的开关
            case "DinnerRoom":
                {
                    CameraMoveNav.instance.Move
                        (CameraMoveNav.instance.targetGameObjectPosition["厨房"]);
                    break;
                }
            // 点击进入卫生间的开关
            case "WashRoom":
                {
                    WashRoomDoorMove.instance.ControllDoor();
                    break;
                }
            // 点击进入主卧的开关
            case "MainBedRoom":
                {
                    MainBedRoomMove.instance.ControllDoor();
                    break;
                }
            // 点击进入次卧的开关
            case "MinorRoom":
                {
                    MinorBedRoomMove.instance.ControllDoor();
                    break;
                }
            // 点击进入书房的开关
            case "StudyRoom":
                {
                    StudyRoomDoorMove.instance.ControllDoor();
                    break;
                }
            // 点击了卫生间出去的开关
            case "WashRoomBack":
                {
                    // 移动到客厅
                    WashRoomDoorMove.instance.MoveLiving();
                    break;
                }
            // 点击了书房出去的开关
            case "StudyRoomBack":
                {
                    // 移动到客厅
                    StudyRoomDoorMove.instance.MoveLiving();
                    break;
                }
            // 点击了主卧出去的开关
            case "MainBedRoomBack":
                {
                    // 移动到客厅
                    MainBedRoomMove.instance.MoveLiving();
                    break;
                }
            // 点击了次卧出去的开关
            case "MinorRoomBack":
                {
                    // 移动到客厅
                    MinorBedRoomMove.instance.MoveLiving();
                    break;
                }
            // 点击厨房出去的开关
            case "DinnerRoomBack":
                {
                    // 移动到客厅
                    CameraMoveNav.instance.MoveLiving();
                    break;
                }
            // 点击了第一个设备 
            case "0(Clone)":
                {
                    // 调用UnityToAndroid中的方法，向Android获取设备列表
                    UnityToAndroid.instance.GetStates();
                    ListChoiceDevice.instance.isClickButton = true;
                    // 设置需要获取设备0的状态的标记
                    UnityToAndroid.deviceNum = 0;
                    //  调用UnityToAndroid中的方法，向Android发送设备监听事件
                    UnityToAndroid.instance.SetDeviceList(UnityToAndroid.deviceState[0]);
                    // 调用UnityToAndroid中的方法，向android发送设备订阅事件
                    UnityToAndroid.instance.SubScribeDevice();
                    // 切换场景，进入加载场景界面
                    ChangeScene();
                    break;
                }
            // 点击了第二个设备
            case "1(Clone)":
                {
                    // 调用UnityToAndroid中的方法，向Android获取设备列表
                    UnityToAndroid.instance.GetStates();
                    // 将点击标记选择为true
                    ListChoiceDevice.instance.isClickButton = true;
                    // 设置需要获取设备1的状态的标记
                    UnityToAndroid.deviceNum = 1;
                    //  调用UnityToAndroid中的方法，向Android发送设备监听事件
                    UnityToAndroid.instance.SetDeviceList(UnityToAndroid.deviceState[1]);
                    // 调用UnityToAndroid中的方法，向android发送设备订阅事件
                    UnityToAndroid.instance.SubScribeDevice();
                    // 切换场景，进入加载场景界面
                    ChangeScene();
                    break;
                }
            // 点击了第三个设备
            case "2(Clone)":
                {
                    UnityToAndroid.instance.GetStates();
                    ListChoiceDevice.instance.isClickButton = true;
                    UnityToAndroid.deviceNum = 2;
                    UnityToAndroid.instance.SetDeviceList(UnityToAndroid.deviceState[2]);
                    UnityToAndroid.instance.SubScribeDevice();
                    ChangeScene();
                    break;
                }
            // 点击了第四个设备
            case "3(Clone)":
                {
                    UnityToAndroid.instance.GetStates();
                    ListChoiceDevice.instance.isClickButton = true;
                    UnityToAndroid.deviceNum = 3;
                    UnityToAndroid.instance.SetDeviceList(UnityToAndroid.deviceState[3]);
                    UnityToAndroid.instance.SubScribeDevice();
                    ChangeScene();
                    break;
                }
            // 点击了第五个设备
            case "4(Clone)":
                {
                    UnityToAndroid.instance.GetStates();
                    ListChoiceDevice.instance.isClickButton = true;
                    UnityToAndroid.deviceNum = 4;
                    UnityToAndroid.instance.SetDeviceList(UnityToAndroid.deviceState[4]);
                    UnityToAndroid.instance.SubScribeDevice();
                    ChangeScene();
                    break;
                }
            // 点击了第六个设备
            case "5(Clone)":
                {
                    UnityToAndroid.instance.GetStates();
                    ListChoiceDevice.instance.isClickButton = true;
                    UnityToAndroid.deviceNum = 5;
                    UnityToAndroid.instance.SetDeviceList(UnityToAndroid.deviceState[5]);
                    UnityToAndroid.instance.SubScribeDevice();
                    ChangeScene();
                    break;
                }
            // 点击了第七个设备
            case "6(Clone)":
                {
                    UnityToAndroid.instance.GetStates();
                    ListChoiceDevice.instance.isClickButton = true;
                    UnityToAndroid.deviceNum = 6;
                    UnityToAndroid.instance.SetDeviceList(UnityToAndroid.deviceState[6]);
                    UnityToAndroid.instance.SubScribeDevice();
                    ChangeScene();
                    break;
                }
            // 点击了第八个设备
            case "7(Clone)":
                {
                    UnityToAndroid.instance.GetStates();
                    ListChoiceDevice.instance.isClickButton = true;
                    UnityToAndroid.deviceNum = 7;
                    UnityToAndroid.instance.SetDeviceList(UnityToAndroid.deviceState[7]);
                    UnityToAndroid.instance.SubScribeDevice();
                    ChangeScene();
                    break;
                }
                */
        }
        
    }

    /// <summary>
    /// 切换场景
    /// </summary>
    void ChangeScene()
    {
        SceneManager.LoadScene("Loading");
    }
    #endregion
}