using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//Purpose:  Load scenes appropriate to buttons pressed
public class PauseMenu : MonoBehaviour
{
    public Button resumeButton;
    public Button restartButton;
    public Button mainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        Component[] buttonComponents;
        buttonComponents = GetComponentsInChildren<Button>(); // store all the buttons in an array
        resumeButton = buttonComponents[0].GetComponent<Button>(); // Get First Button
        restartButton = buttonComponents[1].GetComponent<Button>(); // Get Second Button
        mainMenuButton = buttonComponents[2].GetComponent<Button>(); // Get Third Button

        // Add a listener for a click event for each button
        resumeButton.onClick.AddListener(delegate { Debug.Log("Resume"); ResumeGame(); });
        restartButton.onClick.AddListener(delegate { Debug.Log("Restart"); RestartGame(); });
        mainMenuButton.onClick.AddListener(delegate { Debug.Log("MainMenu"); LoadMainMenu(); });
    }

    //Start time and hide pause menu
    private void ResumeGame()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        gameObject.SetActive(false);
    }

    //Start time and reload scene
    private void RestartGame()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    //Start time and load StartScene
    private void LoadMainMenu()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene("0StartScene", LoadSceneMode.Single);
    }


    // Update is called once per frame
    void Update()
    {
        // close pause menu using 'esc' key press
        if (gameObject.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeGame();
        }
    }
}
