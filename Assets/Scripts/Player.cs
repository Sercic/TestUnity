using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool bagIsOpen;

    private void Start()
    {
        bagIsOpen = false;
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
}
