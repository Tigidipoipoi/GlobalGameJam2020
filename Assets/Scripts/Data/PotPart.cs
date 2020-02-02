using UnityEngine;

[CreateAssetMenu]
public class PotPart : ScriptableObject
{
    public Elements Element;

    public int Cost;

    public GameObject Model;

    public Damages DamageState;

    public Quality Quality;

    [BitMask]
    public Slots Slot;

    public void Copy(PotPart potPart)
    {
        Element = potPart.Element;
        Cost = potPart.Cost;
        Model = potPart.Model;
        DamageState = potPart.DamageState;
        Quality = potPart.Quality;
        Slot = potPart.Slot;
    }
}