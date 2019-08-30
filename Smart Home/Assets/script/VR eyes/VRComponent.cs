using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// ͨ��VRResponse���ݹ����Ĳ��������ж���ʲô���壬ʵ��ʲô����
/// </summary>
/// ǿ��ʹ�ô˽ű�����Ϸ���������Collider
[RequireComponent(typeof(Collider))]
public class VRComponent : MonoBehaviour
{
    #region ����
    /// <summary>
    /// ������Ҫ�ȴ���ʱ��
    /// </summary>
	public float waitingTime = 1.5f;

    /// <summary>
    /// ��Inspector���������
    /// �Ƿ�ȴ���
    /// </summary>
    [HideInInspector]
    public bool isWaitted = false;

    /// <summary>
    /// �ŵĶ������ŵ�ʱ��
    /// </summary>
    public float time = 3.5f;

    /// <summary>
    /// ��������
    /// </summary>
    public static VRComponent instance;

    /// <summary>
    /// ���ڼ�¼�Ƿ�ִ�м������Ĳ���
    /// </summary>
    public bool isBind = false;
    #endregion

    #region ����

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// ���߼��֮����Ӧ�ķ���
    /// </summary>
    /// <param name="name">���߼�⵽����������</param>
    /// <param name="trans">���߼�⵽�������Transform</param>
    public void ResponEvent(string name, Transform trans)
    {
        switch (name)
        {
            /*
            // �����ʼ�����OK
            case "OK":
                {
                    MakeSure.instance.SubStart();
                    break;
                }
            // �����ʼ�����Cancel
            case "Cancel":
                {
                    MakeSure.instance.Cancle();
                    break;
                }
            // ���UI�����ϵĿ��İ�ť
            case "OpenImage":
                {
                    UIController._instance.RespondOnUIEvent(trans.parent.name);
                    break;
                }
            // ���UI����صİ�ť
            case "CloseImage":
                {
                    UIController._instance.RespondOffUIEvent(trans.parent.name);
                    break;
                }
            // �����ң����
            case "Romote":
                {
                    UICanvasShow.instance.IsShow();
                    break;
                }
            // ���UI����ϵ��˳���ť
            case "BackImage":
                {
                    UIController._instance.IsShow(false);
                    break;
                }
            // ���UI����ϵ����Ű�ť
            case "FoldImage":
                {
                    UIAnimation.instance.FoldOff();
                    break;
                }
            // �������ʱ��ָ�ƻ�
            case "LivingRoom":
                {
                    // �������ŵĿ���
                    LivingDoorMove.instance.ControllDoor();
                    break;
                }
            // �����������Ŀ���
            case "DinnerRoom":
                {
                    CameraMoveNav.instance.Move
                        (CameraMoveNav.instance.targetGameObjectPosition["����"]);
                    break;
                }
            // �������������Ŀ���
            case "WashRoom":
                {
                    WashRoomDoorMove.instance.ControllDoor();
                    break;
                }
            // ����������ԵĿ���
            case "MainBedRoom":
                {
                    MainBedRoomMove.instance.ControllDoor();
                    break;
                }
            // ���������ԵĿ���
            case "MinorRoom":
                {
                    MinorBedRoomMove.instance.ControllDoor();
                    break;
                }
            // ��������鷿�Ŀ���
            case "StudyRoom":
                {
                    StudyRoomDoorMove.instance.ControllDoor();
                    break;
                }
            // ������������ȥ�Ŀ���
            case "WashRoomBack":
                {
                    // �ƶ�������
                    WashRoomDoorMove.instance.MoveLiving();
                    break;
                }
            // ������鷿��ȥ�Ŀ���
            case "StudyRoomBack":
                {
                    // �ƶ�������
                    StudyRoomDoorMove.instance.MoveLiving();
                    break;
                }
            // ��������Գ�ȥ�Ŀ���
            case "MainBedRoomBack":
                {
                    // �ƶ�������
                    MainBedRoomMove.instance.MoveLiving();
                    break;
                }
            // ����˴��Գ�ȥ�Ŀ���
            case "MinorRoomBack":
                {
                    // �ƶ�������
                    MinorBedRoomMove.instance.MoveLiving();
                    break;
                }
            // ���������ȥ�Ŀ���
            case "DinnerRoomBack":
                {
                    // �ƶ�������
                    CameraMoveNav.instance.MoveLiving();
                    break;
                }
            // ����˵�һ���豸 
            case "0(Clone)":
                {
                    // ����UnityToAndroid�еķ�������Android��ȡ�豸�б�
                    UnityToAndroid.instance.GetStates();
                    ListChoiceDevice.instance.isClickButton = true;
                    // ������Ҫ��ȡ�豸0��״̬�ı��
                    UnityToAndroid.deviceNum = 0;
                    //  ����UnityToAndroid�еķ�������Android�����豸�����¼�
                    UnityToAndroid.instance.SetDeviceList(UnityToAndroid.deviceState[0]);
                    // ����UnityToAndroid�еķ�������android�����豸�����¼�
                    UnityToAndroid.instance.SubScribeDevice();
                    // �л�������������س�������
                    ChangeScene();
                    break;
                }
            // ����˵ڶ����豸
            case "1(Clone)":
                {
                    // ����UnityToAndroid�еķ�������Android��ȡ�豸�б�
                    UnityToAndroid.instance.GetStates();
                    // ��������ѡ��Ϊtrue
                    ListChoiceDevice.instance.isClickButton = true;
                    // ������Ҫ��ȡ�豸1��״̬�ı��
                    UnityToAndroid.deviceNum = 1;
                    //  ����UnityToAndroid�еķ�������Android�����豸�����¼�
                    UnityToAndroid.instance.SetDeviceList(UnityToAndroid.deviceState[1]);
                    // ����UnityToAndroid�еķ�������android�����豸�����¼�
                    UnityToAndroid.instance.SubScribeDevice();
                    // �л�������������س�������
                    ChangeScene();
                    break;
                }
            // ����˵������豸
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
            // ����˵��ĸ��豸
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
            // ����˵�����豸
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
            // ����˵������豸
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
            // ����˵��߸��豸
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
            // ����˵ڰ˸��豸
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
    /// �л�����
    /// </summary>
    void ChangeScene()
    {
        SceneManager.LoadScene("Loading");
    }
    #endregion
}