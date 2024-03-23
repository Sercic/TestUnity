using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UGPanelManager
{
    public static UGPanelManager Instance;
    private static UGPanelManager instance = new UGPanelManager();

    public Dictionary<string, UGPanelBase> strPanelDic;
    
    public T ShowPanel<T>() where T : UGPanelBase
    {
        string panelName = typeof(T).Name;
        if (strPanelDic.ContainsKey(panelName))
        {
            return strPanelDic[panelName] as T;
        }
        GameObject panelObj =  Resources.Load<GameObject>("Prafabs/UI/" + panelName);
        T Panel = panelObj.GetComponent<T>();
        strPanelDic.Add(panelName, Panel);
        return strPanelDic[panelName] as T;
    }

    public void HidePale<T>()
    {
        string panelName = typeof(T).Name;
        if (!strPanelDic.ContainsKey(panelName)) return;
        GameObject.Destroy(strPanelDic[panelName]);
        strPanelDic.Remove(panelName);
    }
}
