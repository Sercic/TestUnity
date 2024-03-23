using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DiaLogPanel : UGPanelBase
{

    private DiaLogData.DiaLogue dia;

    private int nowDiaIndex;

    public Text TextShow;

    public void SetDia(DiaLogData.DiaLogue Inputdia)
    {
        dia = Inputdia;
        nowDiaIndex = 0;
        ChangeTxt(dia.GetTxt(nowDiaIndex));
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&nowDiaIndex < dia.diaLogNodes.Length)
        {
            TxtUpdate();
        }
    }

    private void TxtUpdate()
    {
        print(nowDiaIndex);
        nowDiaIndex++;
        if (nowDiaIndex == dia.diaLogNodes.Length) Player.Instance.TalkOver();
        else
        {
            ChangeTxt(dia.GetTxt(nowDiaIndex));
        }
    }

    public void ChangeTxt(string txt)
    {
        TextShow.text = txt;
    }

    public override void Init()
    {
    }
}
