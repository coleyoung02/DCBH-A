using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Single);
        SceneManager.LoadSceneAsync("PersistentObjects", LoadSceneMode.Additive);
    }
}
