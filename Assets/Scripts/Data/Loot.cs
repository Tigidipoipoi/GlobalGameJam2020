using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Drop
{
    public Elements Type;

    public int Amount;
}

[System.Serializable]
public class Loot
{
    public List<Drop> DropList;
}

