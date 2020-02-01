using System;
using UnityEngine;

public abstract class GameState : ScriptableObject
{
    [Header("Input data")]
    public Hero Hero;

    public Player Player;

    public abstract void Apply();
}
