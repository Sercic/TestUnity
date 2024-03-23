using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePanel<T> : MonoBehaviour where T :class
{
    private static T instance;
    public static T Instance => instance;

    public abstract void Init();
    private void Start()
    {
        Init();
    }
    private void Awake()
    {
        instance = this as T;
    }
    
    public virtual void ShowMe()
    {
        this.gameObject.SetActive(true);
    }

    public void HideMe()
    {
        gameObject.SetActive(false);
    }
}
