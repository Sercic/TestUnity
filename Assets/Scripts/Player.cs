using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player Instance => instance;   

    private bool bagIsOpen;
    private DiaLogPanel DiaPanel;

    public bool InTalk;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        bagIsOpen = false;
        InTalk = false;
    }


    void Update()
    {
        #region 打开背包界面
        if(Input.GetKeyDown(KeyCode.Space))
        {
            bagIsOpen = !bagIsOpen;
            if(bagIsOpen  == true)
            {
                BagPanel.Instance.ShowMe();
            }
            else
            {
                BagPanel.Instance.HideMe();
            }
        }

        #endregion

        #region 按下cx切换道具
        if(bagIsOpen == true)
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                BagPanel.Instance.backScale(DataMgr.Instance.currentIndex);
                DataMgr.Instance.currentIndex++;
                BagPanel.Instance.UpdateBag();
            }
            if(Input.GetKeyDown (KeyCode.X))
            {
                BagPanel.Instance.backScale(DataMgr.Instance.currentIndex);
                DataMgr.Instance.currentIndex--;
                BagPanel.Instance.UpdateBag();
            }
        }
        #endregion

    }

    public void TalkStart(DiaLogData.DiaLogue dia)
    {
        DiaPanel = UGPanelManager.Instance.ShowPanel<DiaLogPanel>();
        DiaPanel.SetDia(dia);
        InTalk = true;
    }
    public void TalkOver()
    {
        UGPanelManager.Instance.HidePale<DiaLogPanel>();
        InTalk = false;
    }
}
