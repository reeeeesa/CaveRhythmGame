using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//Purpose:  
public class ScoreEntry : MonoBehaviour
{
    private ScoreboardDataManager dataManager;
    public TMP_Dropdown optionDropdown;
    public TMP_InputField nameInput;
    public Button submitButton;
    public SongManager songManager;

    // Start is called before the first frame update
    void Start()
    {

        Component[] inputTextComponents = GetComponentsInChildren<TMP_InputField>(); // Get the input text as a child
        nameInput = inputTextComponents[0].GetComponent<TMP_InputField>(); // Get the button text as a child

        Component[] buttonComponents = GetComponentsInChildren<Button>(); ;
        submitButton = buttonComponents[0].GetComponent<Button>(); // store all the buttons in an array

        submitButton.onClick.AddListener(delegate { Submit(); });

        dataManager = FindObjectOfType<ScoreboardDataManager>();
        songManager = FindObjectOfType<SongManager>();
    }

    void Submit()
    {
        // SaveData takes the players score and a file name e.g. "/filename.dat"
        dataManager.SaveData(nameInput.text, songManager.Score, "playerscore.dat");
        SceneManager.LoadScene("1ScoreboardScene", LoadSceneMode.Single);
        
        //Reset timescale
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }
}
