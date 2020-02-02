using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BluePrints : ScriptableObject
{
    public List<PotPart> OwnedParts;

    [BitMask]
    public Slots AllowedSlots;
}
