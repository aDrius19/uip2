/* LocaleSelector.cs
 * This file contains the LocaleSelector class which allows users to control the language of the game.
 */
using System.Collections;
using UnityEngine;

using UnityEngine.Localization.Settings;

// credits to this video: https://www.youtube.com/watch?v=qcXuvd7qSxg&ab_channel=RootGames
// for showing us a simple script to work with using Localization for changing different languages using static text
public class LocaleSelector : MonoBehaviour
{
    private bool onceActive = false; // not to call the coroutine more than once

    /// <summary>
    /// Start is called once before the first execution of Update after the MonoBehaviour is created.
    /// This method initializes the language based on the users' choice.
    /// </summary>
    private void Start()
    {
        int localesID = PlayerPrefs.GetInt("LocaleKey");
        ChangeLocale(localesID);
    }

    /// <summary>
    /// This method checks that the language is not already set.
    /// </summary>
    public void ChangeLocale(int localeID)
    {
        if (onceActive) return;
        StartCoroutine(SetLocale(localeID));
    }
    
    /// <summary>
    /// This method waits for the initialization of the localization settings.
    /// It changes the language based on the users choice.
    /// </summary>
    IEnumerator SetLocale(int _localeID)
    {
        onceActive = true;
        yield return LocalizationSettings.InitializationOperation; //localization loaded and ready to use

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];

        PlayerPrefs.SetInt("LocaleKey", _localeID);

        onceActive = false;
    }
}
