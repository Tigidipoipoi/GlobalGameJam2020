using UnityEngine;
using TMPro;

public class TestimonyUI : MonoBehaviour
{
    public TestimonyState Data;

    public TextMeshProUGUI Text;

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

    void OnEnable()
    {
        Text.text = Data.GetTestimony();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Data.IsDone = true;
        }
    }
}
