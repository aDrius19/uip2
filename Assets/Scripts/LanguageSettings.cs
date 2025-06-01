using UnityEngine;

public class LanguageSettings : MonoBehaviour
{
    public GameObject languagePanel;

    public void ToggleLanguagePanel()
    {
        languagePanel.SetActive(!languagePanel.activeSelf);
    }
}
