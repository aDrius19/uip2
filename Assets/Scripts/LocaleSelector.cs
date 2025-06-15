using System.Collections;
using UnityEngine;

using UnityEngine.Localization.Settings;

// credits to this video: https://www.youtube.com/watch?v=qcXuvd7qSxg&ab_channel=RootGames
// for showing us a simple script to work with using Localization for changing different languages using static text
public class LocaleSelector : MonoBehaviour
{
    private bool onceActive = false; // not to call the coroutine more than once

    private void Start()
    {
        int localesID = PlayerPrefs.GetInt("LocaleKey");
        ChangeLocale(localesID);
    }

    public void ChangeLocale(int localeID)
    {
        if (onceActive) return;
        StartCoroutine(SetLocale(localeID));
    }
    
    IEnumerator SetLocale(int _localeID)
    {
        onceActive = true;
        yield return LocalizationSettings.InitializationOperation; //localization loaded and ready to use

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];

        PlayerPrefs.SetInt("LocaleKey", _localeID);

        onceActive = false;
    }
}
