using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlsMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text subtext;
    private bool checkNextKey;
    private GameManager.Controls controlToChange;
    private TMP_Text buttonLabel;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        checkNextKey = false;
        controlToChange = GameManager.Controls.MoveUp;
    }
    void Update()
    {
        if (!checkNextKey)
        {
            return;
        }

        // Only continue when user entered any key within the last frame
        if (Input.inputString.Length <= 0)
        {
            return;
        }

        KeyCode k = (KeyCode) Input.inputString[0];
        GameManager.Keybinds[controlToChange] = k;
        buttonLabel.text = k.ToString();

        button.interactable = true;
        button = null;
        buttonLabel = null;

        subtext.text = "click a key to change bindings";

        checkNextKey = false;
    }
    public void ChangeKeybind(Keybind obj)
    {
        if (button != null) {
            return;
        }

        checkNextKey = true;

        controlToChange = obj.Control;

        buttonLabel = obj.ButtonLabel;
        buttonLabel.text = "";

        subtext.text = string.Format("Press a key to bind \"{0}\"", obj.ControlLabel.text);

        button = obj.Button;
        button.interactable = false;
    }
}
