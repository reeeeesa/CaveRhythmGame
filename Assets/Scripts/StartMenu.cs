using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


//Purpose: 
public class StartMenu : MonoBehaviour
{
    public Button startButton, quitButton, scoreboardButton;

    // Start is called before the first frame update
    void Start()
    {
        //Store all buttons in an array
        Component[] buttonComponents = GetComponentsInChildren<Button>();
        startButton = buttonComponents[0].GetComponent<Button>();
        quitButton = buttonComponents[1].GetComponent<Button>();
        scoreboardButton = buttonComponents[2].GetComponent<Button>();

        //Listen for button clicks and run respective code when they are
        startButton.onClick.AddListener(delegate { StartGame(); });
        quitButton.onClick.AddListener(delegate { QuitGame(); });
        scoreboardButton.onClick.AddListener(delegate { OpenScoreboard(); });
    }

    //Loads LevelSelectScene
    private void StartGame()
    {
        SceneManager.LoadScene("2LevelSelectScene", LoadSceneMode.Single);
    }

    //Quits app
    private void QuitGame()
    {
        Application.Quit();
    }

    //Loads ScoreboardScene
    private void OpenScoreboard()
    {
        SceneManager.LoadScene("1ScoreboardScene", LoadSceneMode.Single);
    }
}