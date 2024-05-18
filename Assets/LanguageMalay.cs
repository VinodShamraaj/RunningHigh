
using UnityEngine;
using UnityEngine.UI;

public class LanguageMalay : MonoBehaviour
{
    // Malay
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button settingsButton;
    [SerializeField]
    private Button quitButton;

    [SerializeField]
    private Sprite malayPlaySprite;
    [SerializeField]
    private Sprite malaySettingsSprite;
    [SerializeField]
    private Sprite malayQuitSprite;

    [SerializeField]
    private Sprite englishPlaySprite;
    [SerializeField]
    private Sprite englishSettingsSprite;
    [SerializeField]
    private Sprite englishQuitSprite;

    public void ChangeMalay()
    {
        Settings.currentLanguage = 1;
        
        // Get playImage
        Image playImage = playButton.GetComponent<Image>();
        playImage.sprite = malayPlaySprite;

        // Get settingsImage
        Image settingsImage = settingsButton.GetComponent<Image>();
        settingsImage.sprite = malaySettingsSprite;

        // Get settingsImage
        Image quitImage = quitButton.GetComponent<Image>();
        quitImage.sprite = malayQuitSprite;
    }

    public void ChangeEnglish()
    {
        Settings.currentLanguage = 0;

        // Get playImage
        Image playImage = playButton.GetComponent<Image>();
        playImage.sprite = englishPlaySprite;

        // Get settingsImage
        Image settingsImage = settingsButton.GetComponent<Image>();
        settingsImage.sprite = englishSettingsSprite;

        // Get settingsImage
        Image quitImage = quitButton.GetComponent<Image>();
        quitImage.sprite = englishQuitSprite;
    }
}
