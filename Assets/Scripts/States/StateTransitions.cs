using System;
using UnityEngine;

[Serializable]
public struct Transition
{
    public string Condition;

    public GameState Previous;

    public GameState Next;
}
