using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMgr
{
    private static DataMgr instance = new DataMgr();
    public static DataMgr Instance => instance;

    public int currentIndex = 0;//��ǰ����

    public ItemData itemData;
    private DataMgr() {
        itemData = XmlDataMgr.Instance.LoadData(typeof(ItemData),"ItemData") as ItemData;
    }

    //��ӵ���
    void AddItemData(string name,int count,UISprite sprite)
    {       
        if(itemData.itemList.Count<3)
        {
            //ûͬ�����
            itemInfo info = new itemInfo();
            info.name = name;
            info.sprite = sprite;
            itemData.itemList.Add(info);
            XmlDataMgr.Instance.SaveData(itemData, "ItemData");
        }
        else
        {
            Debug.Log("��Ʒ������");
        }
       
    }

    //���ٵ���
    void DeleteItemData(string name)
    {
        for(int i = 0;i<itemData.itemList.Count; i++)
        {
            if (itemData.itemList[i].name == name)
            {
                //������С��0��ɾȥ��Ʒ                
                    itemData.itemList.RemoveAt(i);               
            }
        }
        XmlDataMgr.Instance.SaveData(itemData, "ItemData");
    }
}
