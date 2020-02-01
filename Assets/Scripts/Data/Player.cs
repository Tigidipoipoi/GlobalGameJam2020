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

    public void Copy(Player playerToCopy)
    {
        //Deep copy resources
        for (int i = 0; i < playerToCopy.Resources.Count; i++)
        {
            Resources[i].Copy(playerToCopy.Resources[i]);
        }

        //Shallow copy parts
        SelectedParts.Clear();
        foreach (var selectedPart in playerToCopy.SelectedParts)
        {
            SelectedParts.Add(selectedPart);
        }
    }
}
