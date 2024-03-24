using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemData
{
    public List<int> itemList = new List<int>();

}
[CreateAssetMenu(menuName = "创建物品字典", fileName = "itemDic")]
public class ItemDic : ScriptableObject
{
    public SerizlizerDictionaryInspector<int, itemInfo> ItemDIc;
}
[Serializable]
public class itemInfo
{
    public int id;
    public string name;
    public UISprite sprite;
}

