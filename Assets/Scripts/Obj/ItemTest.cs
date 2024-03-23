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
        Player.Instance.Talk(this.gameObject);
    }
    private void Update()
    {
        //»¥¶¯¼ü°´ÏÂ
        if (SprTip.enabled&&Input.GetKeyDown(KeyCode.E))
        {
            if(CanTalk) Talk();
            if(CanPack) IntpPackage();
        }
    }
}
