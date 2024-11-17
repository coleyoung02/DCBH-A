using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool enablePlayerInput = true;

    public static bool EnablePlayerInput
    {
        get => enablePlayerInput;
        set
        {
            enablePlayerInput = value;
        }
    }
}
