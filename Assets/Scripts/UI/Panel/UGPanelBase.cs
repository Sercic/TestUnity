using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UGPanelBase : MonoBehaviour  
{
    public void ShowMe()
    {
        this.gameObject.SetActive(true);
    }
    public void HideMe()
    {
        this.gameObject.SetActive(false);
    }
    public void Awake()
    {
        Init();
    }
    public abstract void Init();
}
