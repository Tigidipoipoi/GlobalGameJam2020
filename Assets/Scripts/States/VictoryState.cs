using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text;

[CreateAssetMenu(menuName = "GameState/Victory")]
public class VictoryState : GameState
{
    public TestimonyHeroLine VictoryLine;
    public TestimonyLine StoryLine;

    StringBuilder m_TestimonyBuilder = new StringBuilder();
    public override void Apply() { }

    public override void Enter()
    {
        base.Enter();
        AkSoundEngine.PostEvent("Stop_MK_Static", Flow.gameObject);
        AkSoundEngine.PostEvent("Play_FWin", Flow.gameObject);

        VictoryTestify();
    }

    public override void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public string GetVictory() => m_TestimonyBuilder.ToString();

    public void VictoryTestify()
    {
        if (VictoryLine != null)
        {
            m_TestimonyBuilder.AppendLine(VictoryLine.Text);
        }
        if (StoryLine != null)
        {
            m_TestimonyBuilder.AppendLine(StoryLine.Text);
        }
    }
}
