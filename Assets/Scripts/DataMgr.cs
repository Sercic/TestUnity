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

    public SerizlizerDictionaryInspector<int,itemInfo> itemDic = Resources.Load<ItemDic>("itemDic").ItemDIc;

    //��ӵ���
    public void AddItemData(int Id)
    {       
        if(itemData.itemList.Count<3)
        {
            itemData.itemList.Add(Id);
            XmlDataMgr.Instance.SaveData(itemData, "ItemData");
        }
        else
        {
            Debug.Log("��Ʒ������");
        }
       
    }

    //���ٵ���
    public void DeleteItemData(int Id)
    {
        for(int i = 0;i<itemData.itemList.Count; i++)
        {
            if (itemData.itemList[i] == Id)
            {
                //������С��0��ɾȥ��Ʒ                
                    itemData.itemList.RemoveAt(i);               
            }
        }
        XmlDataMgr.Instance.SaveData(itemData, "ItemData");
    }

    //��ȡ��������
    public itemInfo  GetItemInfo(int Id)
    {
        if (itemDic.ContainsKey(Id)) return itemDic[Id];
        return null;
    }
}
