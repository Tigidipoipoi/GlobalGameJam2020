using UnityEngine;

[CreateAssetMenu(menuName = "Testimony/PotPart")]
public class TestimonyPotPartLine : TestimonyLine
{
    public Damages Damage;

    [BitMask]
    public Slots HandledSlots;
}
