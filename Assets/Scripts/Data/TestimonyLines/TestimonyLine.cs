using UnityEngine;

[CreateAssetMenu(menuName = "Testimony/BasicLine")]
public class TestimonyLine : ScriptableObject
{
    [Multiline]
    public string Text;
}
