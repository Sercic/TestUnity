using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player Instance => instance;   

    private bool bagIsOpen;
    public GameObject Panel;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        bagIsOpen = false;
        Panel.SetActive(false);
    }


    void Update()
    {
        #region �򿪱�������
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

        #region ����cx�л�����
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

    public void Talk(GameObject talkTarget)
    {
        Panel.SetActive(true);
    }
    public void TalkOver()
    {
        Panel.SetActive(false);
    }
}
