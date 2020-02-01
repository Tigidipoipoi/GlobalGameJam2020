using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializationState : GameState
{
    public Hero HeroInit;
    public Player PlayerInit;

    public override void Apply()
    {
        Initialize();
    }

    public void Initialize()
    {
        InitializeHero();
        InitializePlayer();
    }

    public void InitializePlayer()
    {
        Player.Copy(PlayerInit);
    }

    public void InitializeHero()
    {
        Hero.Copy(HeroInit);
    }
}