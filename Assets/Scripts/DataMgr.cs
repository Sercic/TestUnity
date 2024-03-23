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

    //添加道具
    void AddItemData(string name,int count,UISprite sprite)
    {       
        if(itemData.itemList.Count<3)
        {
            //没同名添加
            itemInfo info = new itemInfo();
            info.name = name;
            info.sprite = sprite;
            itemData.itemList.Add(info);
            XmlDataMgr.Instance.SaveData(itemData, "ItemData");
        }
        else
        {
            Debug.Log("物品栏已满");
        }
       
    }

    //减少道具
    void DeleteItemData(string name)
    {
        for(int i = 0;i<itemData.itemList.Count; i++)
        {
            if (itemData.itemList[i].name == name)
            {
                //若数量小于0了删去物品                
                    itemData.itemList.RemoveAt(i);               
            }
        }
        XmlDataMgr.Instance.SaveData(itemData, "ItemData");
    }
}
