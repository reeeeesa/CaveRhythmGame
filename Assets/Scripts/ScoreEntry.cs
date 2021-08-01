using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//Purpose: Get player information (name, score and homeroom) via user interface
public class ScoreEntry : MonoBehaviour
{
    //Declare UI elements
    public TMP_Dropdown optionDropdown;
    public TMP_InputField nameInput, homeroomInput;
    public Button submitButton;
    private GameObject invalidText;

    //
    public Player player;
    private ScoreboardDataManager dataManager;
    private string playerName, playerHomeroom;
    private bool validData;

    // Start is called before the first frame update
    void Start()
    {
        invalidText = GameObject.Find("Invalid");
        invalidText.SetActive(false);

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
        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            Submit();
        }
    }

    //Get player infromation from the game (name, homeroom and score), check it is valid and send it to the ScoreboardDataManager
    void Submit()
    {
        
        while (validData == false)
        {
            playerName = nameInput.text;
            playerHomeroom = homeroomInput.text;
            //Check the player is within boundary of max 10 characters long
            if (playerName.Length <= 10 && playerHomeroom.Length == 3 && playerHomeroom[0] == 'P' || playerHomeroom[0] == 'B' || playerHomeroom[0] == 'M' || playerHomeroom[0] == 'J' || playerHomeroom[0] == 'D')
            {
                // SaveData takes the players score and a file name e.g. "/filename.dat"
                dataManager.SaveData(nameInput.text, homeroomInput.text, player.Score, "/playerscore.dat");
                SceneManager.LoadScene("1ScoreboardScene", LoadSceneMode.Single);

                //Reset timescale
                Time.timeScale = 1f;
                AudioListener.pause = false;

                validData = true;
            }
            else
            {
                invalidText.SetActive(true);
            }
        }
    }
}
