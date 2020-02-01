using UnityEngine;

[CreateAssetMenu]
public class GameResource : ScriptableObject
{
    public Elements Type;

    public int Amount;

    public void Copy(GameResource gameResource)
    {
        Type = gameResource.Type;
        Amount = gameResource.Amount;
    }
}
