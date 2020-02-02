using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuPanel;

    public GameObject CreditsPanel;

    public Image MusicIcon;

    public Sprite MuteMusicSprite;

    public Sprite UnmuteMusicSprite;

    bool m_IsMusicMute;

    public Image SfxIcon;

    public Sprite MuteSfxSprite;

    public Sprite UnmuteSfxSprite;

    bool m_IsSfxMute;

    void Start()
    {
        //Force music on at start.
        m_IsMusicMute = true;
        ToggleMusic();
        AkSoundEngine.PostEvent("Play_MK_Static", gameObject);

        //Force sfx on at start.
        m_IsSfxMute = true;
        ToggleSfx();
    }

    public void ClickPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void ClickCredits()
    {
        CreditsPanel.SetActive(true);

        MenuPanel.SetActive(false);
    }

    public void ToggleMusic()
    {
        string eventName = m_IsMusicMute ? "Reset_Music_Bus_Vol" : "Set_Music_Bus_Vol_to_0";

        AkSoundEngine.PostEvent(eventName, gameObject);

        m_IsMusicMute = !m_IsMusicMute;

        MusicIcon.sprite = m_IsMusicMute ? MuteMusicSprite : UnmuteMusicSprite;
    }

    public void ToggleSfx()
    {
        string eventName = m_IsSfxMute ? "Reset_SFX_Bus_Vol" : "Set_SFX_Bus_Vol_to_0";

        AkSoundEngine.PostEvent(eventName, gameObject);

        m_IsSfxMute = !m_IsSfxMute;

        SfxIcon.sprite = m_IsSfxMute ? MuteSfxSprite : UnmuteSfxSprite;
    }
}
