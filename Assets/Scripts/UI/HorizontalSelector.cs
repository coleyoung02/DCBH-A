using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class HorizontalSelector : MonoBehaviour
{
    [SerializeField] TMP_Text optionText;
    public int value { get; set; }
    public UnityEvent<Int32> onValueChanged;

    private List<string> options = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        value = -1;
    }


    public void AddOptions(List<string> options)
    {
        this.options.AddRange(options);
    }

    public void ClearOptions()
    {
        options.Clear();
        value = -1;
    }

    public void RefreshShownValue()
    {
        if (value < 0)
        {
            return;
        }

        optionText.text = options[value];
    }

    public void NextOption()
    {
        value = ((value + 1) % options.Count + options.Count) % options.Count;
        RefreshShownValue();
        onValueChanged.Invoke(value);
    }

    public void PreviousOption()
    {
        value = ((value - 1) % options.Count + options.Count) % options.Count;
        RefreshShownValue();
        onValueChanged.Invoke(value);
    }
}
