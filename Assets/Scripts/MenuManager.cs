using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//Purpose:  Hide and display menus that appear during gameplay
public class MenuManager : MonoBehaviour
{
    //Declare game objects
    public GameObject pauseMenu;
    public GameObject scoreEntryUI;
    public GameObject gameOverMenu;

    void Awake()
    {
        // Find and assign object then hide the menu
        pauseMenu = GameObject.Find("PauseMenu");
        pauseMenu.SetActive(false);
        scoreEntryUI = GameObject.Find("ScoreEntryUI");
        scoreEntryUI.SetActive(false);
        gameOverMenu = GameObject.Find("GameOverMenu");
        gameOverMenu.SetActive(false);

    }

    private void Update()
    {
        // Open pause menu using 'esc' key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DisplayPauseMenu();
        }
    }

    //Stop time and display the pause menu
    public void DisplayPauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    //Stop time and display the score entry UI
    public void DisplayScoreEntryUI()
    {
        scoreEntryUI.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    //Stop time and display the game over menu
    public void DisplayGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
    }
}
