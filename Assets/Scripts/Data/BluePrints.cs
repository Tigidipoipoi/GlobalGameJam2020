using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BluePrints : ScriptableObject
{
    public List<PotPart> OwnedParts;

    [BitMask]
    public Slots AllowedSlots;

    public List<PotPart> GetPartsForLevel(int level)
    {
        List<PotPart> parts = new List<PotPart>();
        if(level == 1)
        {
            foreach(PotPart part in OwnedParts)
            {
                parts.Add(part);
            }
        }
        if (level == 2)
        {
            MakeNewParts(Qualities.TERRACOTTA, parts);
        }
        if (level == 3)
        {
            MakeNewParts(Qualities.IRON, parts);
        }
        if (level == 4)
        {
            MakeNewParts(Qualities.GOLD, parts);
        }

        return parts;
    }

    private void MakeNewParts(Qualities quality, List<PotPart> parts)
    {
        foreach (PotPart part in OwnedParts)
        {
            PotPart newPart = new PotPart();
            newPart.Copy(part);
            newPart.Quality.quality = quality;
            parts.Add(newPart);
        }
    }
}
