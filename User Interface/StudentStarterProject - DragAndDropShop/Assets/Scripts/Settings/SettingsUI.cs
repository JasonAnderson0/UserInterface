using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public FloatEditor musicVolume;
    public FloatEditor fxVolume;
    Settings settings;

    private void Start()
    {
        settings = GetComponent<Settings>();
        if (musicVolume)
        {
            musicVolume.floatValue = settings.musicVolume;
            musicVolume.onValueChanged.AddListener((float value) => { settings.musicVolume = value; });
        }
    }

    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        musicVolume.floatValue = settings.musicVolume;
        fxVolume.floatValue = settings.fxVolume;
    }

    public void OnMusicVolumeChanged(float volume)
    {
        settings.musicVolume = volume;
    }
}
