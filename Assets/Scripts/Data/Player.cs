using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Player : ScriptableObject
{
    public List<GameResource> Resources;

    public List<PotPart> SelectedParts;

    public GameResource this[Elements element]
    {
        get
        {
            foreach (var resource in Resources)
            {
                if (resource.Type == element)
                {
                    return resource;
                }
            }

            return null;
        }
    }
}