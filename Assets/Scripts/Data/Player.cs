using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Player : ScriptableObject
{
    public List<GameMaterial> Resources;

    public List<PotPart> SelectedParts;
}
