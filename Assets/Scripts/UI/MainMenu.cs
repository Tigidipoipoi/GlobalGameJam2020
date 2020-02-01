using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuPanel;

    public GameObject CreditsPanel;

    public void ClickPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void ClickCredits()
    {
        CreditsPanel.SetActive(true);

        MenuPanel.SetActive(false);
    }

    public void ToggleSound()
    {
        //TBD
    }
}
