using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
// ע�⣺�л�����Ҫ����UnityEngine.SceneManagement�����ռ�
using UnityEngine.SceneManagement;

///<summary>
/// ѡ���Ƿ������豸
///</summary>
public class MakeSure : MonoBehaviour
{
    #region ����ı����ֶκ�����

    /// <summary>
    /// ����
    /// </summary>
    public static MakeSure instance;

    [HideInInspector]
    public string linkState = "�����豸";

    // �л�������ɾ��������
    public GameObject gameObj;

    #endregion

    #region Unity�ص�����

    void Awake()
    {
        instance = this;
    }
    #endregion

    #region ����

    /// <summary>
    /// ��������ȷ�������ø÷���
    /// </summary>
    public void SubStart()
    {
        // �Ƚ�����״̬��Ϊ����
        PlayerPrefs.SetString(linkState, "ȷ��");
        // ���볡����ʱ��Ϳ�ʼ�󶨷���
        UnityToAndroid.instance.InitBindService();
        Invoke("Waitting",2f);
    }

    void Waitting()
    {
        // ����UnityToAndroid�İ󶨷��񷽷�
        UnityToAndroid.instance.BindState();
        // �󶨳ɹ�֮��
        if (UnityToAndroid.instance.isBindSuccess == "BindSuccess")
        {
            // �л����豸ѡ�񳡾���
            ChangeScene();
        }
        
    }

    // �ȴ�һ��ʱ�䣬Ȼ���л�����
    public void ChangeScene()
    {
        // �л����豸ѡ�񳡾�
        SceneManager.LoadScene("DevicesChoice", LoadSceneMode.Single);
        // �л�������ɾ������
        DontDestroyOnLoad(gameObj);
    }

    /// <summary>
    /// ���ȡ����ʱ�򣬵��ø÷���
    /// </summary>
    public void Cancle()
    {
        // �Ƚ�״̬�л���Ϊδ����
        PlayerPrefs.SetString(linkState, "ȡ��");
        // ������ȡ������������һ��������ֱ����ת����
        // �л�����
        SceneManager.LoadScene("Loading", LoadSceneMode.Single);
        // �л�������ɾ��
        DontDestroyOnLoad(gameObj);
    }

    #endregion
}