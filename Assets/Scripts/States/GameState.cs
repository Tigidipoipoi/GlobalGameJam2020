using System;
using UnityEngine;

public abstract class GameState : ScriptableObject
{
    [Header("Input data")]
    public Hero Hero;

    public Player Player;

    public GameFlow Flow;

    /// <summary>
    /// Called when the game enters this state.
    /// </summary>
    public virtual void Enter() { }

    /// <summary>
    /// Called when the game leaves this state.
    /// </summary>
    public virtual void Exit() { }

    /// <summary>
    /// Change game's data based on the state's intelligence and/or player's input.
    /// </summary>
    public abstract void Apply();

    /// <summary>
    /// Play animation, ask for inputs, process stuff ...
    /// </summary>
    public virtual void Update() { }

    /// <summary>
    /// Is the state ready to change game's data ?
    /// </summary>
    public virtual bool CanApply() => true;

    /// <summary>
    /// Is the state's animation over and ready to go to the next step ?
    /// </summary>
    public virtual bool IsDone() => true;
}
