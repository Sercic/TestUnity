using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaLogData
{
    //����һ���Ի��ڵ�
    [Serializable]
    public class DiaLogNode
    {
        [TextArea, Header("�Ի�������")]
        public string content;
    }

    //��ʾһ�ζԻ�
    [CreateAssetMenu(menuName = "�����Ի�", fileName = "�Ի�")]
    public class DiaLogue: ScriptableObject
    {
        public DiaLogNode[] diaLogNodes;

        public string GetTxt(int index)
        {
            return diaLogNodes[index].content;
        }
    }
}
