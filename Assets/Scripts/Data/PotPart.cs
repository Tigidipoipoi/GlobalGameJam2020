using UnityEngine;

[CreateAssetMenu]
public class PotPart : ScriptableObject
{
    public Elements Element;

    public int Cost;

    public Mesh Model;

    public Damages DamageState;

    public Quality Quality;

    [BitMask]
    public Slots Slot;
}
