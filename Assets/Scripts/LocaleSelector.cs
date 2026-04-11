using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;

public class LocaleSelector : MonoBehaviour
{
    private TMP_Dropdown dropdown;

    void Start()
    {
        StartCoroutine(Init());
    }

    private IEnumerator Init()
    {
        yield return LocalizationSettings.InitializationOperation;

        dropdown = GetComponent<TMP_Dropdown>();
        dropdown.ClearOptions();
        dropdown.AddOptions(LocalizationOptions());
        SelectCurrentLocale();
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    private List<string> LocalizationOptions()
    {
        List<string> options = new List<string>();
        List<Locale> locales= LocalizationSettings.AvailableLocales.Locales;
        foreach (Locale locale in locales)
        {
            options.Add(locale.LocaleName);
        }
        return options;
    }

    private void SelectCurrentLocale()
    {
        List<Locale> locales = LocalizationSettings.AvailableLocales.Locales;
        Locale currentLocale = LocalizationSettings.SelectedLocale;
        int index = locales.IndexOf(currentLocale);
        dropdown.SetValueWithoutNotify(index);
    }

    private void OnDropdownValueChanged(int index)
    {
        List<Locale> locales = LocalizationSettings.AvailableLocales.Locales;
        LocalizationSettings.SelectedLocale = locales[index];
    }

}
