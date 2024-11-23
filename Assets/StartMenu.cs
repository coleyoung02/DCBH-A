using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");

        SceneManager.LoadScene("PersistentObjects", LoadSceneMode.Additive);
    }

    // Method for Quit Button
    public void QuitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }

    //not sure if we have a settings menu yet

}
