using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameState/Fight")]
public class FightState : GameState
{
    public override void Enter()
    {
        //Reset Hero's life
        Hero.CurrentHealth = Hero.MaxHealth;

        //Reset parts' damage state
        foreach (var selectedPart in Player.SelectedParts)
        {
            selectedPart.DamageState = Damages.INTACT;
        }
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
}
