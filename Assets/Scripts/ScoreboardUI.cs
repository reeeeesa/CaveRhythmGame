using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

// Purpose: Collects data from the ScoreboardDatamanager and displays it through the UI system. Also takes user input and clears data in the ScoreboardDatamanager
public class ScoreboardUI : MonoBehaviour
{
    //Declare UI elements
    public TextMeshProUGUI rankText, nameText, homeroomText, scoreText;
    public Button mainMenuButton, clearButton, playButton;

    //Declare a referrece to the data manager
    private ScoreboardDataManager sbDataManager;

    private void Start()
    {
        // Get TMPro objects from heirarchy and store them in an array
        Component[] textComponents = GetComponentsInChildren<TextMeshProUGUI>();
        rankText = textComponents[0].GetComponent<TextMeshProUGUI>();
        nameText = textComponents[1].GetComponent<TextMeshProUGUI>();
        homeroomText = textComponents[2].GetComponent<TextMeshProUGUI>();
        scoreText = textComponents[3].GetComponent<TextMeshProUGUI>();

        //Get buttons from heirarchy and store them in an array
        Component[] buttonComponents = GetComponentsInChildren<Button>(); // store all buttons in an array
        mainMenuButton = buttonComponents[0].GetComponent<Button>();
        clearButton = buttonComponents[1].GetComponent<Button>();
        playButton = buttonComponents[2].GetComponent<Button>();

        //Add listeners to buttons
        sbDataManager = FindObjectOfType<ScoreboardDataManager>(); // set reference to dataManager
        mainMenuButton.onClick.AddListener(delegate { CloseScoreboard(); });
        clearButton.onClick.AddListener(delegate { ClearScoreboard(); });
        playButton.onClick.AddListener(delegate { LoadLevelSelect(); });
        SetupBoard();
    }

    // Closes scoreboard and loads Start Scene
    private void CloseScoreboard()
    {
        SceneManager.LoadScene("0StartScene", LoadSceneMode.Single);
    }

    //Deletes the file containing scoreboard data and runs SetupBoard to update scene
    private void ClearScoreboard()
    {
        sbDataManager.DeleteFile("/playerscore.dat");
        SetupBoard();
    }

    //Loads level select scene
    private void LoadLevelSelect()
    {
        SceneManager.LoadScene("2LevelSelectScene", LoadSceneMode.Single);
    }

    //Loads data from ScoreboardDataManager and presents them on the scene
    private void SetupBoard()
    {
        rankText.text = "";
        nameText.text = "";
        homeroomText.text = "";
        scoreText.text = "";
        List<ScoreboardEntry> tempDataList = new List<ScoreboardEntry>();
        tempDataList = sbDataManager.LoadData("/playerscore.dat");

        for (int i = 0; i < tempDataList.Count; i++)
        {
            rankText.text = rankText.text + (i + 1).ToString() + "\n";
            nameText.text = nameText.text + tempDataList[i].name + "\n";
            homeroomText.text = homeroomText.text + tempDataList[i].homeroom + "\n";
            scoreText.text = scoreText.text + tempDataList[i].score.ToString() + "\n";
        }
    }

}
