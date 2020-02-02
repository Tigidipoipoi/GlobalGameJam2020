using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "GameState/Testimony")]
public class TestimonyState : GameState
{
    [Header("Lines")]
    public List<TestimonyPotPartLine> PotPartLines;

    public List<TestimonyHeroLine> HeroLines;

    public TestimonyLine IntroductionLine;

    public TestimonyLine LootLine;

    public LootDrop RandomDrop;
    public LootDrop FixedDrop;

    StringBuilder m_TestimonyBuilder = new StringBuilder();

    /// <inheritdoc />
    public override void Enter()
    {
        AkSoundEngine.PostEvent("Play_Village_Ambience", Flow.gameObject);
        AkSoundEngine.PostEvent("Play_Walla_M1", Flow.gameObject);

        //Reset testimony.
        m_TestimonyBuilder.Clear();

        if (Flow.CurrentLevel == 1)
        {
            m_TestimonyBuilder.Append(IntroductionLine.Text);

            return;
        }

        HeroTestify();

        PotPartsTestify();

        LootTestify();
    }

    public override void Exit()
    {
        base.Exit();
        AkSoundEngine.PostEvent("Stop_Walla_M1", Flow.gameObject);
        AkSoundEngine.PostEvent("Stop_Walla_M2", Flow.gameObject);
        AkSoundEngine.PostEvent("Stop_Walla_M3", Flow.gameObject);
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

            if (playerPart == null)
            {
                continue;
            }

            foreach (var potPartLine in PotPartLines)
            {
                if (potPartLine.HandledSlots != 0
                    && potPartLine.HandledSlots.HasFlag(playerPart.AllowedSlots))
                {
                    m_TestimonyBuilder.AppendLine();
                    m_TestimonyBuilder.AppendFormat(potPartLine.Text, playerPart.name);

                    break;
                }
            }
        }
    }

    void LootTestify()
    {
        List<int> oldResources = new List<int>();
        foreach (GameResource resource in Player.Resources)
        {
            oldResources.Add(resource.Amount);
        }

        RandomDrop.GiveLoot(Flow.CurrentLevel);
        FixedDrop.GiveLoot(Flow.CurrentLevel);

        List<int> elementDrops = new List<int>();

        for (int i = 0; i < Player.Resources.Count; i++)
        {
            elementDrops.Add(Player.Resources[i].Amount - oldResources[i]);
        }

        m_TestimonyBuilder.AppendFormat(LootLine.Text, elementDrops[0], elementDrops[1], elementDrops[2], elementDrops[3], elementDrops[4]);
    }
}
