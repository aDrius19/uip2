/* LanguageSettings.cs
 * This file contains the LanguageSettinfs class which controls the visibility of the language settings panel.
 */
using UnityEngine;

public class LanguageSettings : MonoBehaviour
{
    public GameObject languagePanel;

    /// <summary>
    /// This method controls whether the language panel is visible or not.
    /// </summary>
    public void ToggleLanguagePanel()
    {
        languagePanel.SetActive(!languagePanel.activeSelf);
    }
}
