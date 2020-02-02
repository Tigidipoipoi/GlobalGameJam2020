using UnityEngine;

public class FightUI : MonoBehaviour
{
    public GameFlow Flow;

    public FightState State;

    void Start()
    {
        GameFlow.StateStarted += OnStateStarted;
        GameFlow.StateEnded += OnStateEnded;

        if (Flow.CurrentState != State)
        {
            gameObject.SetActive(false);
        }
    }

    void OnDestroy()
    {
        GameFlow.StateEnded -= OnStateEnded;
        GameFlow.StateStarted -= OnStateStarted;
    }

    void OnStateStarted(GameState state)
    {
        if (state == State)
        {
            gameObject.SetActive(true);
        }
    }

    void OnStateEnded(GameState state)
    {
        if (state == State)
        {
            gameObject.SetActive(false);
        }
    }
}
