using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// 如果该类的子类挂载到了一个游戏对象身上，
/// 就会执行Awake方法，将instance赋值
/// 对于调用该类的任意方法，不用考虑场景中是否拥有该组件
public class MonoSingleton<T> :
	 MonoBehaviour where T : MonoBehaviour
{
    #region 单例

    private static T _instance;

    public static T instance
    {
    get
    {
        if (_instance == null)
        {
        // 如果场景中没有任何对象挂载了该组件，
        // 就会创建一个对象，然后将这个组件挂载到该游戏对象上
        GameObject obj = new GameObject(typeof(T).Name);
        _instance = obj.AddComponent<T>();
        }
        return _instance;
    }
    }

    #endregion

    #region Unity回调

    protected virtual void Awake()
    {
        _instance = this as T;
    }

    #endregion
}