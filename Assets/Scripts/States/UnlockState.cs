using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockState : GameState
{
    /// <inheritdoc />
    public override void Apply()
    {
        Unlock();
    }

    public void Unlock()
    {
        Player.SelectedParts.Add(null);
    }

    public bool NeedsUnlock()
    {
        return (Flow.CurrentLevel > 0 && Flow.CurrentLevel < 6);
    }
}
