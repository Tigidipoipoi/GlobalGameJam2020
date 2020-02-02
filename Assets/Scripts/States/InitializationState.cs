using UnityEngine;

[CreateAssetMenu(menuName = "GameState/Initialization")]
public class InitializationState : GameState
{
    public Hero HeroInit;
    public Player PlayerInit;

    public override void Apply()
    {
        Initialize();

        IsDone = true;
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

        Hero.Element = (Elements)Random.Range(0, GameFlow.NB_ELEMENTS);
    }
}
