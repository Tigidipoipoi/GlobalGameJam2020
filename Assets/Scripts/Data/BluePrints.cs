using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BluePrints : ScriptableObject
{
    public List<PotPart> OwnedParts;

    public List<Quality> OwnedQualities;

    [BitMask]
    public Slots AllowedSlots;
}
