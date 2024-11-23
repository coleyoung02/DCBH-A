using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* NOTE to UI people if you want to animate the pause menu
remember to add the animator to the pauseMenuUI object and change
the 'Update Mode' to 'Unscaled Time' or else animations will not work
*/
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private KeyCode pauseKey;
    [SerializeField] private GameObject pauseMenuUI; 
    [SerializeField] private GameObject settingsMenuUI; 
    [SerializeField] private GameObject controlsMenuUI; 
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
        GameManager.EnablePlayerInput = false;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);
        controlsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        GameManager.EnablePlayerInput = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        ResumeGame();
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void SettingsMenu()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
    }

    public void ControlsMenu()
    {
        pauseMenuUI.SetActive(false);
        controlsMenuUI.SetActive(true);
    }

    public static bool GetIsPaused()
    {
        return isPaused;
    }
}
