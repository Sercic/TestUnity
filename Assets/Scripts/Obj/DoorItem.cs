using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorItem : ItemBase
{
    public void Update()
    {
        //»¥¶¯¼ü°´ÏÂ
        if (SprTip.enabled && Input.GetKeyDown(KeyCode.E) && !Player.Instance.InTalk)
        {
            if (CanTalk) Talk();
            if (!IsLocked) DoorTrans();
        }
    }
    protected override int IntpPackage()
    {
        throw new System.NotImplementedException();
    }

    protected override void Talk()
    {
        if (dia == null) return;
        Player.Instance.TalkStart(dia);
    }

    public bool IsLocked;
    public int Key;

    public string SceneName;

    public void DoorTrans()
    {
        SceneManager.LoadScene(SceneName);
    }
}
