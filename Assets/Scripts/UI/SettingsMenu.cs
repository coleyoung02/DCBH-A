using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private HorizontalSelector displaySelector;
    [SerializeField] private HorizontalSelector resolutionSelector;
    [SerializeField] private AudioMixer audioMixer;
    private Resolution[] resolutions;
    
    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        UpdateResolutionOptions();
        UpdateDisplayOptions();
    }

    public void SetVolume(float value)
    {
        audioMixer.SetFloat("Volume", value);
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
        Debug.Log(index);
        if (index == 0)
        {
            Screen.fullScreen = false;
        }
        else
        {
            Screen.fullScreen = true;
        }

        Debug.Log(Screen.fullScreen);
    }
}
