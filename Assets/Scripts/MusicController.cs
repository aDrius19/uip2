/* MusicController.cs
 * This file contains the MusicController class which controls the background music, sound effects, and mute functionality.
 */
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

    /// <summary>
    /// Start is called once before the first execution of Update after the MonoBehaviour is created.
    /// This method initializes mute state and button UI / functionality.
    /// </summary>
    void Start()
    {
        buttonImage = muteButton.GetComponent<Image>();
        muteButton.onClick.AddListener(ToggleMute);
        ApplyMute();
        UpdateIcon();
    }

    /// <summary>
    /// This method toggles audio muting when the mute button is clicked.
    /// </summary>
    void ToggleMute()
    {
        isMuted = !isMuted;
        ApplyMute();
        UpdateIcon();
    }

    /// <summary>
    /// This method mutes / unmutes the background music and sound effects based on isMuted.
    /// It changes the AudioListener volume based on the mute state.
    /// </summary>
    void ApplyMute()
    {
        backgroundMusic.mute = isMuted;
        AudioListener.volume = isMuted ? 0f : 1f;
    }

    /// <summary>
    /// This method controls the mute button UI based on the mute state.
    /// </summary>
    void UpdateIcon()
    {
        if (buttonImage != null)
        {
            buttonImage.sprite = isMuted ? muteIcon : unmuteIcon;
        }
    }
}

