using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BagPanel : BasePanel<BagPanel>
{
    public GameObject obj0;
    public GameObject obj1;
    public GameObject obj2;

    public UILabel lab0;
    public UILabel lab1;
    public UILabel lab2;
    public override void Init()
    {
        HideMe();
    }

    public override void ShowMe()  //显示背包中物品
    {
        base.ShowMe();
        List<int> list = DataMgr.Instance.itemData.itemList;

        if(list.Count != 0)
        {
            if (list[0] != null)
            {
                lab0.text = DataMgr.Instance.itemDic[list[0]].name ;
                GameObject o1 = Instantiate(Resources.Load<GameObject>("UI/" + DataMgr.Instance.itemDic[list[0]].name));
                o1.transform.SetParent(obj0.transform, false);
                o1.transform.localPosition = Vector3.zero;
            }

            if (list[1] != null)
            {
                lab0.text = DataMgr.Instance.itemDic[list[1]].name;
                GameObject o2 = Instantiate(Resources.Load<GameObject>("UI/" + DataMgr.Instance.itemDic[list[1]].name));
                o2.transform.SetParent(obj1.transform, false);
                o2.transform.localPosition = Vector3.zero;
            }

            if (list[2] != null)
            {
                lab0.text = DataMgr.Instance.itemDic[list[2]].name;
                GameObject o3 = Instantiate(Resources.Load<GameObject>("UI/" + DataMgr.Instance.itemDic[list[2]].name));
                o3.transform.SetParent(obj2.transform, false);
                o3.transform.localPosition = Vector3.zero;
            }
        }
        
        UpdateBag();
    }

    public void UpdateBag()
    {
        if(DataMgr.Instance.currentIndex >= 3)
        {
            DataMgr.Instance.currentIndex = 2;
        }
        if(DataMgr.Instance.currentIndex < 0)
        {
            DataMgr.Instance.currentIndex = 0;
        }

        switch(DataMgr.Instance.currentIndex)
        {
            case 0:
                obj0.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                break;
            case 1:
                obj1.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                break;
            case 2:
                obj2.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                break;
        }
    }

    public void backScale(int index)
    {
        switch(index)
        {
            case 0:
                obj0.transform.localScale = Vector3.one;
                break;
            case 1:
                obj1.transform.localScale = Vector3.one;
                break;
            case 2:
                obj2.transform.localScale = Vector3.one;
                break;
        }
    }

}
