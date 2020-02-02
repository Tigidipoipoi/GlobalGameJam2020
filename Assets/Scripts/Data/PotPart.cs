using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu]
public class PotPart : ScriptableObject
{
    public Elements Element;

    public int Cost;

    public GameObject Model;

    public Damages DamageState;

    public Quality Quality;

    [FormerlySerializedAs("Slot")]
    [BitMask]
    public Slots AllowedSlots;

    public Slots EquippedSlot;

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
        AllowedSlots = potPart.AllowedSlots;
        Icon = potPart.Icon;
        Tooltip = potPart.Tooltip;
    }
}
