using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int score;
    public static float timer;

    private void Start()
    {
        score = 0;
        timer = 0;
    }

    public enum Controls
    {
        MoveUp,
        MoveLeft,
        MoveRight,
        MoveDown,
        Dash,
        Attack,
        Spell1,
        Spell2,
        Parry
    }
    private static bool enablePlayerInput = true;
    #region Keybinds
    public static Dictionary<Controls, KeyCode> Keybinds = new Dictionary<Controls, KeyCode>
    {
        {Controls.MoveUp, KeyCode.W},
        {Controls.MoveLeft, KeyCode.A},
        {Controls.MoveRight, KeyCode.D},
        {Controls.MoveDown, KeyCode.S},
        {Controls.Dash, KeyCode.LeftShift},
        {Controls.Attack, KeyCode.Mouse0},
        {Controls.Spell1, KeyCode.Q},
        {Controls.Spell2, KeyCode.E},
        {Controls.Parry, KeyCode.Mouse1},
    };
    #endregion

    public static bool EnablePlayerInput
    {
        get => enablePlayerInput;
        set
        {
            enablePlayerInput = value;
        }
    }
}
