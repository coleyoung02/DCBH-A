using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI timer;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Your Score: " + GameManager.score;
        timer.text = "Your Time: " + Math.Round(GameManager.timer, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
        SceneManager.LoadScene("PersistentObjects", LoadSceneMode.Additive);
        
    }

    public void Menu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
