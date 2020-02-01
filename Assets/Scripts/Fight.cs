using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ2020.Variables;

public class Fight : MonoBehaviour
{
    public static int NB_ELEMENTS = 5;
    public static float BUFF = 2.0f;

    public Hero Hero;
    public Player Player;

    public void RunFight(out float remainingLife, out List<PotPart> potParts)
    {
        remainingLife = Hero.Health.Value;
        potParts = Player.SelectedParts;
        foreach (PotPart part in potParts)
        {
            if (((int)part.Element + 1) % NB_ELEMENTS == (int)Hero.Element)
            {
                remainingLife -= part.Quality * BUFF;
                part.DamageState = Damage.INTACT;
            }
            else if (((int)part.Element - 1) % NB_ELEMENTS == (int)Hero.Element)
            {
                remainingLife -= part.Quality * 1 / BUFF;
                part.DamageState = Damage.DESTROYED;
            }
            else
            {
                remainingLife -= part.Quality;
                part.DamageState = Damage.DAMAGED;
            }
        }
    }
}
