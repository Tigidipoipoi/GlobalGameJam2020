using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameState/Fight")]
public class FightState : GameState
{
    public const int NB_ELEMENTS = 5;

    public float Buff = 2.0f;

    /// <inheritdoc />
    public override void Apply()
    {
        RunFight(ref Hero.CurrentHealth, ref Player.SelectedParts);
    }

    void RunFight(ref int remainingLife, ref List<PotPart> potParts)
    {
        foreach (PotPart part in potParts)
        {
            if (((int)part.Element + 1) % NB_ELEMENTS == (int)Hero.Element)
            {
                remainingLife -= Mathf.RoundToInt(part.Quality * Buff);
                part.DamageState = Damages.INTACT;
            }
            else if (((int)part.Element - 1) % NB_ELEMENTS == (int)Hero.Element)
            {
                remainingLife -= Mathf.RoundToInt(part.Quality * 1 / Buff);
                part.DamageState = Damages.DESTROYED;
            }
            else
            {
                remainingLife -= part.Quality;
                part.DamageState = Damages.DAMAGED;
            }
        }
    }
}
