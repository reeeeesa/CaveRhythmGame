using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public Button resumeButton;
    public Button restartButton;
    public Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        Component[] buttonComponents;
        buttonComponents = GetComponentsInChildren<Button>(); // store all the buttons in an array
        resumeButton = buttonComponents[0].GetComponent<Button>(); // Get First Button
        restartButton = buttonComponents[1].GetComponent<Button>(); // Get Second Button
        quitButton = buttonComponents[2].GetComponent<Button>(); // Get Third Button

        // Add a listener for a click event for each button
        resumeButton.onClick.AddListener(delegate { Debug.Log("Resume"); ResumeGame(); });
        restartButton.onClick.AddListener(delegate { Debug.Log("Restart"); RestartGame(); });
        quitButton.onClick.AddListener(delegate { Debug.Log("Quit"); Application.Quit(); });
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; // Start time when pause menu active is false
        gameObject.SetActive(false);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        // close pause menu using 'esc' key press
        if (gameObject.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1; // Start time when pause menu active is false
            gameObject.SetActive(false);

        }
    }
}
