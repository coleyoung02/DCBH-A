using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private HorizontalSelector displaySelector;
    [SerializeField] private HorizontalSelector resolutionSelector;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private TMP_Text volumePercent;
    private Resolution[] resolutions;
    private float volume;
    
    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        audioMixer.GetFloat("Volume", out volume);
        UpdateResolutionOptions();
        UpdateDisplayOptions();
    }

    public void SetVolume(float value)
    {
        volume = value;
        audioMixer.SetFloat("Volume", value);
        volumePercent.text = ((int) (value * 100)).ToString() + "%";
    }

    public void MuteAudio(bool doMute)
    {
        if (doMute)
        {
            audioMixer.SetFloat("Volume", 0);
        }
        else
        {
            audioMixer.SetFloat("Volume", volume);
        }
    }
    public void UpdateResolutionOptions()
    {
        int selectedResolutionIndex = 0;

        resolutionSelector.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            options.Add(resolutions[i].width + "x" + resolutions[i].height);

            if (resolutions[i].Equals(Screen.currentResolution))
            {
                selectedResolutionIndex = i;
            }
        }

        resolutionSelector.AddOptions(options);
        resolutionSelector.value = selectedResolutionIndex;
        resolutionSelector.RefreshShownValue();
    }

    public void UpdateDisplayOptions()
    {
        displaySelector.ClearOptions();

        List<string> options = new List<string> { "Windowed", "Fullscreen" };

        displaySelector.AddOptions(options);
        displaySelector.value = 1;
        displaySelector.RefreshShownValue();
    }

    public void SetResolution(Int32 index)
    {
        Resolution r = resolutions[index];
        Screen.SetResolution(r.width, r.height, Screen.fullScreen);
    }

    public void setFullscreen(Int32 index)
    {
        if (index == 0)
        {
            Screen.fullScreen = false;
        }
        else
        {
            Screen.fullScreen = true;
        }
    }
}
