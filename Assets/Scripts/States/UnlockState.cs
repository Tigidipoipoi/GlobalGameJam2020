using UnityEngine;

[CreateAssetMenu(menuName = "GameState/Unlock")]
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

    public bool NeedsUnlock(GameFlow flow)
    {
        return flow.CurrentLevel > 0 && flow.CurrentLevel < 6;
    }
}
