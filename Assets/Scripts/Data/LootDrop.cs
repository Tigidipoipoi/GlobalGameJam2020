using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu]
public class LootDrop : ScriptableObject
{
    public List<Loot> LootLevels;
    public Player Player;
    public bool RandomLoot;

    public void GiveLoot(int level)
    {
        if (level > LootLevels.Count)
        {
            level = LootLevels.Count - 1;
        }

        var fixedLoot = LootLevels[level % LootLevels.Count];
        if (fixedLoot != null)
        {
            foreach (Drop resourceAdded in fixedLoot.DropList)
            {
                GameResource resource = Player.Resources.Where(r => r.Type == resourceAdded.Type).FirstOrDefault();
                if (resource != null)
                {
                    resource.Amount += (RandomLoot ? Random.Range(0, resourceAdded.Amount) : resourceAdded.Amount);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }
    }
}
