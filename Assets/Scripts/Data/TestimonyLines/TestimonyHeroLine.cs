using UnityEngine;

[CreateAssetMenu(menuName = "Testimony/Hero")]
public class TestimonyHeroLine : TestimonyLine
{
    [Range(0.0f, 1.0f)]
    public float RemainingHealthRatio;
}
