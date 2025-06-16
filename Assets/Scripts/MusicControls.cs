using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public Button muteButton;
    public Sprite muteIcon;
    public Sprite unmuteIcon;

    private bool isMuted = false;
    private Image buttonImage;

    void Start()
    {
        buttonImage = muteButton.GetComponent<Image>();
        muteButton.onClick.AddListener(ToggleMute);
        ApplyMute();
        UpdateIcon();
    }

    void ToggleMute()
    {
        isMuted = !isMuted;
        ApplyMute();
        UpdateIcon();
    }

    void ApplyMute()
    {
        backgroundMusic.mute = isMuted;
        AudioListener.volume = isMuted ? 0f : 1f;
    }

    void UpdateIcon()
    {
        if (buttonImage != null)
        {
            buttonImage.sprite = isMuted ? muteIcon : unmuteIcon;
        }
    }
}

