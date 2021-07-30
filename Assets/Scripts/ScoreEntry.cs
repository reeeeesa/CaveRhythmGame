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
    public TMP_InputField nameInput, homeroomInput;
    public Button submitButton;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {

        Component[] inputTextComponents = GetComponentsInChildren<TMP_InputField>(); // Get the input text as a child
        nameInput = inputTextComponents[0].GetComponent<TMP_InputField>(); // Get the button text as a child\
        homeroomInput = inputTextComponents[1].GetComponent<TMP_InputField>();

        Component[] buttonComponents = GetComponentsInChildren<Button>(); ;
        submitButton = buttonComponents[0].GetComponent<Button>(); // store all the buttons in an array

        submitButton.onClick.AddListener(delegate { Submit(); });

        dataManager = FindObjectOfType<ScoreboardDataManager>();
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Submit();
        }
    }

    void Submit()
    {
        if (nameInput)
        {
            // SaveData takes the players score and a file name e.g. "/filename.dat"
            dataManager.SaveData(nameInput.text, homeroomInput.text, player.Score, "/playerscore.dat");
            SceneManager.LoadScene("1ScoreboardScene", LoadSceneMode.Single);

            //Reset timescale
            Time.timeScale = 1f;
            AudioListener.pause = false;
        }
    }
}
