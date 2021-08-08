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
        Component[] buttonComponents = GetComponentsInChildren<Button>();
        startButton = buttonComponents[0].GetComponent<Button>();
        quitButton = buttonComponents[1].GetComponent<Button>();
        scoreboardButton = buttonComponents[2].GetComponent<Button>();



        startButton.onClick.AddListener(delegate { StartGame(); });
        quitButton.onClick.AddListener(delegate { QuitGame(); });
        scoreboardButton.onClick.AddListener(delegate { OpenScoreboard(); });
    }



    private void StartGame()
    {
        Debug.Log("Load Game Scene");
        SceneManager.LoadScene("2LevelSelectScene", LoadSceneMode.Single);
    }



    private void QuitGame()
    {
        Debug.Log("Quit App");
        Application.Quit();
    }

    private void OpenScoreboard()
    {
        Debug.Log("Load Scoreboard Scene");
        SceneManager.LoadScene("1ScoreboardScene", LoadSceneMode.Single);
    }


    // Update is called once per frame
    void Update()
    {

    }
}