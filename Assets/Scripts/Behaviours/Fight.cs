using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    public static int NB_ELEMENTS = 5;
    public static float BUFF = 2.0f;

    public Hero Hero;
    public Player Player;

    public void RunFight(out float remainingLife, out List<PotPart> potParts)
    {
        remainingLife = Hero.CurrentHealth;
        potParts = Player.SelectedParts;
        foreach (PotPart part in potParts)
        {
            if (((int)part.Element + 1) % NB_ELEMENTS == (int)Hero.Element)
            {
                remainingLife -= part.Quality * BUFF;
                part.DamageState = Damages.INTACT;
            }
            else if (((int)part.Element - 1) % NB_ELEMENTS == (int)Hero.Element)
            {
                remainingLife -= part.Quality * 1 / BUFF;
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
