using UnityEngine;

[CreateAssetMenu]
public class PotPart : ScriptableObject
{
    public Elements Element;
    public int Value;
    public Damages DamageState;
    public int Quality;

    [BitMask]
    public Slots Slot;
}
