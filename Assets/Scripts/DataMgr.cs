using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMgr
{
    private static DataMgr instance = new DataMgr();
    public static DataMgr Instance => instance;

    public int currentIndex = 0;//当前道具

    public ItemData itemData;
    private DataMgr() {
        itemData = XmlDataMgr.Instance.LoadData(typeof(ItemData),"ItemData") as ItemData;
    }

    public SerizlizerDictionaryInspector<int,itemInfo> itemDic = Resources.Load<ItemDic>("itemDic").ItemDIc;

    //添加道具
    public void AddItemData(int Id)
    {       
        if(itemData.itemList.Count<3)
        {
            itemData.itemList.Add(Id);
            XmlDataMgr.Instance.SaveData(itemData, "ItemData");
        }
        else
        {
            Debug.Log("物品栏已满");
        }
       
    }

    //减少道具
    public void DeleteItemData(int Id)
    {
        for(int i = 0;i<itemData.itemList.Count; i++)
        {
            if (itemData.itemList[i] == Id)
            {
                //若数量小于0了删去物品                
                    itemData.itemList.RemoveAt(i);               
            }
        }
        XmlDataMgr.Instance.SaveData(itemData, "ItemData");
    }

    //获取道具数据
    public itemInfo  GetItemInfo(int Id)
    {
        if (itemDic.ContainsKey(Id)) return itemDic[Id];
        return null;
    }
}
