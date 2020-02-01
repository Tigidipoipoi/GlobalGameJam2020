using UnityEngine;

public class TestimonyUI : MonoBehaviour
{
    public TestimonyState Data;

    void Start()
    {
        GameFlow.StateStarted += OnStateStarted;
        GameFlow.StateEnded += OnStateEnded;
    }

    void OnDestroy()
    {
        GameFlow.StateEnded -= OnStateEnded;
        GameFlow.StateStarted -= OnStateStarted;
    }

    void OnStateStarted(GameState state)
    {
        if (state == Data)
        {
            gameObject.SetActive(true);
        }
    }

    void OnStateEnded(GameState state)
    {
        if (state == Data)
        {
            gameObject.SetActive(false);
        }
    }
}
