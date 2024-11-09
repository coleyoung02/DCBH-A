using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* NOTE to UI people if you want to animate the pause menu
remember to add the animator to the paseMenuUI object and change
the 'Update Mode' to 'Unscaled Time' or else animations will not work
*/
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private KeyCode pauseKey;
    [SerializeField] private GameObject pauseMenuUI; 
    private static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pauseKey) && !isPaused)
        {
            PauseGame();
        }
        else if (Input.GetKeyDown(pauseKey) && isPaused)
        {
            ResumeGame();
        }
    }
    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("To main menu");
        // TODO use SceneManager to load main menu scene
    }

    public static bool GetIsPaused()
    {
        return isPaused;
    }
}
