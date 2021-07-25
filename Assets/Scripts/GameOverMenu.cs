using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public Button restartButton;
    public Button mainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        Component[] buttonComponents;
        buttonComponents = GetComponentsInChildren<Button>(); // store all the buttons in an array
        restartButton = buttonComponents[0].GetComponent<Button>(); // Get Second Button
        mainMenuButton = buttonComponents[1].GetComponent<Button>(); // Get Third Button

        // Add a listener for a click event for each button
        restartButton.onClick.AddListener(delegate { Debug.Log("Restart"); RestartGame(); });
        mainMenuButton.onClick.AddListener(delegate { Debug.Log("Load main menu"); LoadMainMenu(); });
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("0StartScene", LoadSceneMode.Single);
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
