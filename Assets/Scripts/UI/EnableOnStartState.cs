using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnableOnStartState : MonoBehaviour
{
    public GameFlow Flow;

    public List<GameState> States;

    public UnityEvent OnStateStartAction;

    void Start()
    {
        GameFlow.StateStarted += OnStateStarted;
        GameFlow.StateEnded += OnStateEnded;

        if (!States.Contains(Flow.CurrentState))
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
        if (States.Contains(state))
        {
            gameObject.SetActive(true);

            OnStateStartAction?.Invoke();
        }
    }

    void OnStateEnded(GameState state)
    {
        if (States.Contains(state))
        {
            gameObject.SetActive(false);
        }
    }
}
