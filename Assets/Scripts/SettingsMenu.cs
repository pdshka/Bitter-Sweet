using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown dropDown;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }

    public void ChangeResolution()
    {
        if(dropDown.value==0)
        {
            Screen.SetResolution(1920,1080,true);
        }
        else if(dropDown.value == 1)
        {
            Screen.SetResolution(1366,768, true);
        }
        else if(dropDown.value == 2)
        {
            Screen.SetResolution(1024,768, true);
        }
        else if (dropDown.value == 3)
        {
            Screen.SetResolution(1280, 720, true);
        }
    }
}
