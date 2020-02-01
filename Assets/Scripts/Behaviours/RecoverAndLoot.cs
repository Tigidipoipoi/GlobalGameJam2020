using System;
using UnityEngine;

public class RecoverAndLoot : MonoBehaviour
{
    [Header("Input data")]
    public Hero Hero;

    public Player Player;

    [Header("Recovery ratio")]
    public float IntactRecoveryRatio = 1.0f;

    public float DamagedRecoveryRatio = 0.8f;

    public float DestroyedRecoveryRatio = 0.0f;

    public void Recover()
    {
        foreach (var playerPart in Player.SelectedParts)
        {
            float recoveryRatio;
            switch (playerPart.DamageState)
            {
                case Damage.INTACT:
                {
                    recoveryRatio = IntactRecoveryRatio;
                    break;
                }

                case Damage.DAMAGED:
                {
                    recoveryRatio = DamagedRecoveryRatio;
                    break;
                }

                case Damage.DESTROYED:
                {
                    recoveryRatio = DestroyedRecoveryRatio;
                    break;
                }

                default:
                    throw new ArgumentOutOfRangeException();
            }

            Player[playerPart.Element].Value += Mathf.RoundToInt(playerPart.Value * recoveryRatio);
        }
    }

    public void Loot()
    {
        //TBD
    }
}
