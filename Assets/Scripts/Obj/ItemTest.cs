 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTest : ItemBase{
    protected override int IntpPackage()
    {
        throw new System.NotImplementedException();
    }

    protected override void Talk()
    {
        Player.Instance.TalkStart(dia);
    }
    
    private void Update()
    {
        //����������
        if (SprTip.enabled&&Input.GetKeyDown(KeyCode.E)&&!Player.Instance.InTalk)
        {
            if(CanTalk) Talk();
            if(CanPack) IntpPackage();
        }
    }
}
