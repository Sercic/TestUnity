using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EDoorLockedType
{
    ��Կ��ֱ�ӽ�,
    ����Կ�׺���Loced�仯

}
public class DoorItem : ItemBase
{
    public void Update()
    {
        //����������
        if (SprTip.enabled && Input.GetKeyDown(KeyCode.E) && !Player.Instance.InTalk)
        {
            if (CanTalk) Talk();
            DoorTrans();
        }
    }
    protected override void IntoPackage()
    {
        if(!CanPack&&ID != -1)
        {
            DataMgr.Instance.AddItemData(ID);
        }
    }

    protected override void Talk()
    {
        if (dia == null) return;
        Player.Instance.TalkStart(dia);
    }

    private void Talk(DiaLogue dia)
    {
        if (dia == null) return;
        Player.Instance.TalkStart(dia);
    }

    public bool IsLocked;
    public int Key;
    [SerializeField]
    private DiaLogue DiaifNoKey;

    public string SceneName;
    [SerializeField]
    private EDoorLockedType etype;

    public void DoorTrans()
    {
        print(DataMgr.Instance.itemData.itemList.Contains(Key));
        if (IsLocked && DataMgr.Instance.itemData.itemList.Contains(Key))
        {
            switch (etype)
            {
                case EDoorLockedType.��Կ��ֱ�ӽ�:
                    this.IsLocked = false;
                    break;
                case EDoorLockedType.����Կ�׺���Loced�仯:
                    DataMgr.Instance.DeleteItemData(ID);
                    this.IsLocked = false;
                    return;
            }
        }
        else if (IsLocked && !DataMgr.Instance.itemData.itemList.Contains(Key))
        {
            Talk(DiaifNoKey);
            return;
        }
        SceneManager.LoadScene(SceneName);
    }
}
