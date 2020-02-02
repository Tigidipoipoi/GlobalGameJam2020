using UnityEngine;
using UnityEngine.Events;

public class EnableOnStartState : MonoBehaviour
{
    public GameFlow Flow;

    public GameState State;

    public UnityEvent OnStateStartAction;

    void Start()
    {
        GameFlow.StateStarted += OnStateStarted;
        GameFlow.StateEnded += OnStateEnded;

        if (Flow.CurrentState != State)
        {
            gameObject.SetActive(false);
        }
        else
        {
            OnStateStartAction?.Invoke();
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

            OnStateStartAction?.Invoke();
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
