 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTest : ItemBase{
    protected override void IntoPackage()
    {
        DataMgr.Instance.AddItemData(this.ID);
        print("获取了物品" + DataMgr.Instance.itemDic[ID].name);
    }

    protected override void Talk()
    {
        Player.Instance.TalkStart(dia);
    }
    
    private void Update()
    {
        //互动键按下
        if (SprTip.enabled&&Input.GetKeyDown(KeyCode.E)&&!Player.Instance.InTalk)
        {
            if(CanTalk) Talk();
            if(CanPack) IntoPackage();
        }
    }
}
