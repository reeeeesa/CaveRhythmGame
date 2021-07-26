using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

// Display Scoreboard
public class ScoreboardUI : MonoBehaviour
{
    public TextMeshProUGUI rankText, nameText, scoreText;
    public Button mainMenuButton, clearButton, playButton;
    private ScoreboardDataManager sbDataManager;

    private void Start()
    {
        Component[] textComponents = GetComponentsInChildren<TextMeshProUGUI>(); // store all text in an array
        rankText = textComponents[0].GetComponent<TextMeshProUGUI>();
        nameText = textComponents[1].GetComponent<TextMeshProUGUI>();
        scoreText = textComponents[2].GetComponent<TextMeshProUGUI>();

        Component[] buttonComponents = GetComponentsInChildren<Button>(); // store all buttons in an array
        mainMenuButton = buttonComponents[0].GetComponent<Button>();
        clearButton = buttonComponents[1].GetComponent<Button>();
        playButton = buttonComponents[2].GetComponent<Button>();


        sbDataManager = FindObjectOfType<ScoreboardDataManager>(); // set reference to dataManager
        mainMenuButton.onClick.AddListener(delegate { CloseScoreboard(); });
        clearButton.onClick.AddListener(delegate { ClearScoreboard(); });
        playButton.onClick.AddListener(delegate { LoadLevelSelect(); });
        SetupBoard();
    }

    private void CloseScoreboard()
    {
        SceneManager.LoadScene("0StartScene", LoadSceneMode.Single);
    }

    private void ClearScoreboard()
    {
        sbDataManager.DeleteFile("/playerscore.dat");
        SetupBoard();
    }

    private void LoadLevelSelect()
    {
        SceneManager.LoadScene("2LevelSelectScene", LoadSceneMode.Single);
    }


    private void SetupBoard()
    {
        rankText.text = "";
        nameText.text = "";
        scoreText.text = "";
        List<ScoreboardEntry> tempDataList = new List<ScoreboardEntry>();
        tempDataList = sbDataManager.LoadData("/playerscore.dat");

        for (int i = 0; i < tempDataList.Count; i++)
        {
            rankText.text = rankText.text + (i + 1).ToString() + "\n";
            nameText.text = nameText.text + tempDataList[i].name + "\n";
            scoreText.text = scoreText.text + tempDataList[i].score.ToString() + "\n";
        }
    }

}
