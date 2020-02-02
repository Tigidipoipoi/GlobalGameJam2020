using UnityEngine;

[CreateAssetMenu]
public class Quality : ScriptableObject
{
    public Qualities quality;
    public Material material;

    public int Strength;

    [Header("UI")]
    public Sprite Icon;
}
