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
    private GameObject noNameText, longNameText, noHomeroomText, longHomeroomText, invalidHomeroomText, bothHomeroomText;

    //Declare other classes refferenced
    public Player player;
    private ScoreboardDataManager dataManager;

    

    // Start is called before the first frame update
    void Start()
    {
        //Declare error message game objects and hide them
        noNameText = GameObject.Find("NoName");
        noNameText.SetActive(false);
        longNameText = GameObject.Find("NameTooLong");
        longNameText.SetActive(false);
        noHomeroomText = GameObject.Find("NoHomeroom");
        noHomeroomText.SetActive(false);
        longHomeroomText = GameObject.Find("HomeroomTooLong");
        longHomeroomText.SetActive(false);
        invalidHomeroomText = GameObject.Find("InvalidHomeroom");
        invalidHomeroomText.SetActive(false);
        bothHomeroomText = GameObject.Find("InvalidBoundaryHomeroom");
        bothHomeroomText.SetActive(false);

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
        //listen to see if the player presses enter
        if (Input.GetKey(KeyCode.Return))
        {
            Submit();
        }
    }

    //Get player infromation from the game (name, homeroom and score), check it is valid and send it to the ScoreboardDataManager
    void Submit()
    {
        CheckName();
        CheckHomeroom();

        //Check the player is within boundary of max 10 characters long
        if (CheckName() == true && CheckHomeroom() == true)
        {  
            // SaveData takes the players score and a file name e.g. "/filename.dat"
            dataManager.SaveData(nameInput.text, homeroomInput.text.ToUpper(), player.Score, "/playerscore.dat");
            SceneManager.LoadScene("1ScoreboardScene", LoadSceneMode.Single);

            //Reset timescale
            Time.timeScale = 1f;
            AudioListener.pause = false;

                
        }
    }

    //Boundary check for a valid name within a reasonable length (12 characters)
    private bool CheckName()
    {
        bool isValid;
        bool isEmpty;
        bool isLong;
        string playerName = nameInput.text;

        //Check that name input is not empty (Boundary)
        if (playerName != "")
        {
            isEmpty = true;
            noNameText.SetActive(false);
        }
        else
        {
            isEmpty = false;
            noNameText.SetActive(true);
        }

        //Check that the name is not longer than 12 characters (Boundary)
        if (playerName.Length <= 12)
        {
            isLong = true;
            longNameText.SetActive(false);
        }
        else
        {
            isLong = false;
            longNameText.SetActive(true);
        }

        //Check if all aspects of the name are within bounaries
        if (isLong && isEmpty)
        {
            isValid = true;
        }
        else
        {
            isValid = false;
        }
        return isValid;
    }

    //Checking for a valid homeroom name using the school's homeroom naming system (A 3 letter code starting with the first letter of their house: J, M, B, D or P)
    private bool CheckHomeroom()
    {
        bool isValid;
        bool isLong;
        bool isEmpty;
        bool isNameValid;

        //Setting the user's input to all caps to match naming standards
        string playerHomeroom = homeroomInput.text.ToUpper();

        //Check the user hasn't entered nothing in the field (Boundary)
        if (playerHomeroom != "")
        {
            isEmpty = true;
            noHomeroomText.SetActive(false);
        }
        else
        {
            isEmpty = false;
            noHomeroomText.SetActive(true);
        }

        //Check the user has entered a 3 character homeroom code (Boundary)
        if (playerHomeroom.Length == 3)
        {
            isLong = true;
            longHomeroomText.SetActive(false);
        }
        else if (playerHomeroom.Length != 3 && playerHomeroom != "")
        {
            isLong = false;
            longHomeroomText.SetActive(true);
        }
        else
        {
            isLong = false;
        }

        //Check that the first letter of the homeroom code is one of the house letters (Invalid)
        if (playerHomeroom[0] == 'J' || playerHomeroom[0] == 'M' || playerHomeroom[0] == 'B' || playerHomeroom[0] == 'D' || playerHomeroom[0] == 'P')
        {
            isNameValid = true;
            invalidHomeroomText.SetActive(false);
        }
        else
        {
            isNameValid = false;
            invalidHomeroomText.SetActive(true);
        }

        if (isNameValid == false && isLong == false)
        {
            invalidHomeroomText.SetActive(false);
            longHomeroomText.SetActive(false);
            bothHomeroomText.SetActive(true);
        }

        //Check that homeroom input is not invalid and within boundaries
        if (isLong && isEmpty && isNameValid)
        {
            isValid = true;
        }
        else
        {
            isValid = false;
        }

        return isValid;
    }
}
