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

    [Header("UI")]
    public Sprite Icon;

    public string Tooltip;

    public void Copy(PotPart potPart)
    {
        Element = potPart.Element;
        Cost = potPart.Cost;
        Model = potPart.Model;
        DamageState = potPart.DamageState;
        Quality = potPart.Quality;
        Slot = potPart.Slot;
        Icon = potPart.Icon;
        Tooltip = potPart.Tooltip;
    }
}
