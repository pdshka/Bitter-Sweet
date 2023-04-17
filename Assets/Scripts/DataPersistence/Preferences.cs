using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Preferences : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private Dropdown dropDown;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private GameObject settingsMenu;

    private void Start()
    {
        LoadPrefs();
    }

    private void LoadPrefs()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            LoadResolution();
            LoadSound();
            Debug.Log("Prefs loaded");
        }
        else
        {
            Debug.LogWarning("No prefs to load");
        }
    }

    private void LoadSound()
    {
        float volume = PlayerPrefs.GetFloat("volume");
        slider.value = volume;
        //audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        settingsMenu.GetComponent<SettingsMenu>().SetVolume(volume);
        Debug.Log("Sound loaded");
    }

    public void SaveSound()
    {
        PlayerPrefs.SetFloat("volume", slider.value);
        Debug.Log("Sound saved");
    }

    private void LoadResolution()
    {
        int dropDownValue = PlayerPrefs.GetInt("dropDown");
        dropDown.value = dropDownValue;
        int width = PlayerPrefs.GetInt("resolutionWidth");
        int height = PlayerPrefs.GetInt("resolutionHeight");
        //Screen.SetResolution(width, height, true);
        settingsMenu.GetComponent<SettingsMenu>().ChangeResolution();
        Debug.Log("Resolution loaded");
    }

    public void SaveResolution()
    {
        PlayerPrefs.SetInt("dropDown", dropDown.value);
        PlayerPrefs.SetInt("resolutionWidth", Screen.width);
        PlayerPrefs.SetInt("resolutionHeight", Screen.height);
        Debug.Log("Resolution saved");
    }
}
