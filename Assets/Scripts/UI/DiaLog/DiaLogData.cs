using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaLogData
{
    //代表一个对话节点
    [Serializable]
    public class DiaLogNode
    {
        [TextArea, Header("对话的内容")]
        public string content;
    }

    //表示一段对话
    [CreateAssetMenu(menuName = "创建对话", fileName = "对话")]
    public class DiaLogue: ScriptableObject
    {
        public DiaLogNode[] diaLogNodes;

        public string GetTxt(int index)
        {
            return diaLogNodes[index].content;
        }
    }
}
