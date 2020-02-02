using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class BluePrints : ScriptableObject
{
    public List<PotPart> OwnedParts;

    [BitMask]
    public Slots AllowedSlots;

    public List<PotPart> GetPartsForLevel(GameFlow flow)
    {
        List<PotPart> parts = new List<PotPart>();
        if(flow.CurrentLevel >= 1)
        {
            foreach(PotPart part in OwnedParts)
            {
                parts.Add(part);
            }
        }
        if (flow.CurrentLevel >= 2)
        {
            foreach (PotPart part in MakeNewParts(Qualities.TERRACOTTA, flow))
            {
                parts.Add(part);
            }
        }
        if (flow.CurrentLevel >= 3)
        {
            foreach (PotPart part in MakeNewParts(Qualities.IRON, flow))
            {
                parts.Add(part);
            }
        }
        if (flow.CurrentLevel >= 4)
        {
            foreach (PotPart part in MakeNewParts(Qualities.GOLD, flow))
            {
                parts.Add(part);
            }
        }

        return parts;
    }

    private List<PotPart> MakeNewParts(Qualities quality, GameFlow flow)
    {
        List<PotPart> parts = new List<PotPart>();
        foreach (PotPart part in OwnedParts)
        {
            PotPart newPart = Instantiate(part);
            newPart.Copy(part);
            newPart.Quality= flow.AllQualities.FirstOrDefault(q => q.quality == quality);
            parts.Add(newPart);
        }
        return parts;
    }
}
