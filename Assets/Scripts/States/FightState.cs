using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameState/Fight")]
public class FightState : GameState
{
    public override void Enter()
    {
        AkSoundEngine.PostEvent("Stop_MK_Static", Flow.gameObject);
        AkSoundEngine.PostEvent("Play_MK_Combat_A", Flow.gameObject);

        //Reset Hero's life
        Hero.CurrentHealth = Hero.MaxHealth;

        //Reset parts' damage state
        foreach (var selectedPart in Player.SelectedParts)
        {
            if (selectedPart == null)
            {
                continue;
            }

            selectedPart.DamageState = Damages.INTACT;
        }
    }

    public override void Exit()
    {
        base.Exit();
        AkSoundEngine.PostEvent("Stop_MK_Combat_A", Flow.gameObject);
    }

    /// <inheritdoc />
    public override void Apply()
    {
        RunFight(ref Hero.CurrentHealth, ref Player.SelectedParts);
    }

    void RunFight(ref int remainingLife, ref List<PotPart> potParts)
    {
        foreach (PotPart part in potParts)
        {
            if (part == null)
            {
                continue;
            }

            if (((int)part.Element + 1) % GameFlow.NB_ELEMENTS == (int)Hero.Element)
            {
                remainingLife -= Mathf.RoundToInt(part.Quality.Strength * GameFlow.ELEMENT_BUFF);
                part.DamageState = Damages.INTACT;
            }
            else if (((int)part.Element - 1) % GameFlow.NB_ELEMENTS == (int)Hero.Element)
            {
                remainingLife -= Mathf.RoundToInt(part.Quality.Strength * 1 / GameFlow.ELEMENT_BUFF);
                part.DamageState = Damages.DESTROYED;
            }
            else
            {
                remainingLife -= part.Quality.Strength;
                part.DamageState = Damages.DAMAGED;
            }
        }
    }

    public override void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IsDone = true;
            AkSoundEngine.PostEvent("Play_click", Flow.gameObject);
        }
    }
}
