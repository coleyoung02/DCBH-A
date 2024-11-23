using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Keybind : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TMP_Text buttonLabel;
    [SerializeField] private TMP_Text controlLabel;
    [SerializeField] private GameManager.Controls control;

    public Button Button { get => button; }
    public TMP_Text ButtonLabel { get => buttonLabel; }
    public TMP_Text ControlLabel { get => controlLabel; }
    public GameManager.Controls Control { get => control; }
}
