using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// ��������������ص���һ����Ϸ�������ϣ�
/// �ͻ�ִ��Awake��������instance��ֵ
/// ���ڵ��ø�������ⷽ�������ÿ��ǳ������Ƿ�ӵ�и����
public class MonoSingleton<T> :
	 MonoBehaviour where T : MonoBehaviour
{
    #region ����

    private static T _instance;

    public static T instance
    {
    get
    {
        if (_instance == null)
        {
        // ���������û���κζ�������˸������
        // �ͻᴴ��һ������Ȼ�����������ص�����Ϸ������
        GameObject obj = new GameObject(typeof(T).Name);
        _instance = obj.AddComponent<T>();
        }
        return _instance;
    }
    }

    #endregion

    #region Unity�ص�

    protected virtual void Awake()
    {
        _instance = this as T;
    }

    #endregion
}