using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UGPanelManager
{
    public static UGPanelManager Instance=>instance;
    private static UGPanelManager instance = new UGPanelManager();

    private Dictionary<string, UGPanelBase> strPanelDic = new Dictionary<string, UGPanelBase>();
    
    public T ShowPanel<T>() where T : UGPanelBase
    {
        string panelName = typeof(T).Name;
        Debug.Log(strPanelDic.ContainsKey(panelName));   
        if (strPanelDic.ContainsKey(panelName))
        {
            return strPanelDic[panelName] as T;
        }
        Debug.Log(Resources.Load<GameObject>("Prafabs/UI/" + panelName) == null);
        GameObject panelObj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prafabs/UI/" + panelName));
        Transform canvas = GameObject.Find("Canvas").transform;
        panelObj.transform.SetParent(canvas, false);
        T Panel = panelObj.GetComponent<T>();
        strPanelDic.Add(panelName, Panel);
        strPanelDic[panelName].ShowMe();
        return strPanelDic[panelName] as T;
    }

    public void HidePale<T>()
    {
        string panelName = typeof(T).Name;
        if (!strPanelDic.ContainsKey(panelName)) return;
        strPanelDic[panelName].HideMe();
        GameObject.Destroy(strPanelDic[panelName]);
        strPanelDic.Remove(panelName);
    }
}
