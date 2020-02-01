using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "GameState/Testimony")]
public class TestimonyState : GameState
{
    [Header("Lines")]
    public List<TestimonyPotPartLine> PotPartLines;

    public List<TestimonyHeroLine> HeroLines;

    public List<TestimonyBonusLine> BonusLines;

    public TestimonyBonusLine IntroductionLine;

    StringBuilder m_TestimonyBuilder = new StringBuilder();

    /// <inheritdoc />
    public override void Enter()
    {
        //Reset testimony.
        m_TestimonyBuilder.Clear();

        if (Flow.CurrentLevel == 1)
        {
            m_TestimonyBuilder.Append(IntroductionLine.Text);

            return;
        }

        HeroTestify();

        PotPartsTestify();

        BonusTestify();
    }

    /// <inheritdoc />
    public override void Apply() { }

    public string GetTestimony() => m_TestimonyBuilder.ToString();

    void HeroTestify()
    {
        var currentHeroHealthRatio = (float)Hero.CurrentHealth / Hero.MaxHealth;
        TestimonyHeroLine selectedHeroLine = null;
        foreach (var heroLine in HeroLines)
        {
            if (currentHeroHealthRatio <= heroLine.RemainingHealthRatio
                && (selectedHeroLine == null
                    || heroLine.RemainingHealthRatio > selectedHeroLine.RemainingHealthRatio))
            {
                selectedHeroLine = heroLine;
            }
        }

        if (selectedHeroLine != null)
        {
            m_TestimonyBuilder.AppendLine(selectedHeroLine.Text);
        }
    }

    void PotPartsTestify()
    {
        for (var i = 0; i < Player.SelectedParts.Count; i++)
        {
            var playerPart = Player.SelectedParts[i];

            foreach (var potPartLine in PotPartLines)
            {
                if (potPartLine.HandledSlots != 0
                    && potPartLine.HandledSlots.HasFlag(playerPart.Slot))
                {
                    m_TestimonyBuilder.AppendLine();
                    m_TestimonyBuilder.AppendFormat(potPartLine.Text, playerPart.name);

                    break;
                }
            }
        }
    }

    void BonusTestify()
    {
        foreach (var bonusLine in BonusLines)
        {
            if (bonusLine.Condition)
            {
                m_TestimonyBuilder.AppendLine(bonusLine.Text);
            }
        }
    }
}
