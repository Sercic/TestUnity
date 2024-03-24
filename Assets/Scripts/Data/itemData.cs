using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{
    public List<itemInfo> itemList = new List<itemInfo>();
}

public class itemInfo
{
    public int id;
    public string name;
    public UISprite sprite;
}
