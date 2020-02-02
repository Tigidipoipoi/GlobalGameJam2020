using System;
using UnityEngine;

[CreateAssetMenu(menuName = "GameState/Recovery")]
public class RecoveryState : GameState
{
    [Header("Recovery ratio")]
    public float IntactRecoveryRatio = 1.0f;

    public float DamagedRecoveryRatio = 0.8f;

    public float DestroyedRecoveryRatio = 0.0f;

    public override void Enter()
    {
        base.Enter();
        AkSoundEngine.PostEvent("Play_FLoose", Flow.gameObject);
    }

    /// <inheritdoc />
    public override void Apply()
    {
        foreach (var playerPart in Player.SelectedParts)
        {
            if (playerPart == null)
            {
                continue;
            }

            float recoveryRatio;
            switch (playerPart.DamageState)
            {
                case Damages.INTACT:
                    {
                        recoveryRatio = IntactRecoveryRatio;
                        break;
                    }

                case Damages.DAMAGED:
                    {
                        recoveryRatio = DamagedRecoveryRatio;
                        break;
                    }

                case Damages.DESTROYED:
                    {
                        recoveryRatio = DestroyedRecoveryRatio;
                        break;
                    }

                default:
                    throw new ArgumentOutOfRangeException();
            }

            Player[playerPart.Element].Amount += Mathf.RoundToInt(playerPart.Cost * recoveryRatio);
        }
    }
}
