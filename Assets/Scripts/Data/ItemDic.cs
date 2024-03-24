using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "创建物品字典", fileName = "itemDic")]
public class ItemDic : ScriptableObject
{
    public SerizlizerDictionaryInspector<int, itemInfo> ItemDIc;
}
