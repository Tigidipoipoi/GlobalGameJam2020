using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "GameState/Victory")]
public class VictoryState : GameState
{
    public override void Apply() { }

    public override void Enter()
    {
        base.Enter();
        AkSoundEngine.PostEvent("Play_FWin", Flow.gameObject);
    }

    public override void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
