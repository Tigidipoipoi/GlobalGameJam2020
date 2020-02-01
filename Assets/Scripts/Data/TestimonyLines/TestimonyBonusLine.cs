using GGJ2020.Variables;
using UnityEngine;

[CreateAssetMenu(menuName = "Testimony/Bonus")]
public class TestimonyBonusLine : ScriptableObject
{
    public BoolReference Condition;

    [Multiline]
    public string Text;
}
