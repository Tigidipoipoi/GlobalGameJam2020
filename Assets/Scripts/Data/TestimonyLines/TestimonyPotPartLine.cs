using UnityEngine;

[CreateAssetMenu(menuName = "Testimony/PotPart")]
public class TestimonyPotPartLine : ScriptableObject
{
    public Damages Damage;

    [BitMask]
    public Slots HandledSlots;

    [Multiline]
    public string Text;
}
