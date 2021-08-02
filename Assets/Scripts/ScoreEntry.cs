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
    private GameObject invalidNameText, invalidHomeroomText;

    //
    public Player player;
    private ScoreboardDataManager dataManager;

    // Start is called before the first frame update
    void Start()
    {
        invalidNameText = GameObject.Find("InvalidName");
        invalidNameText.SetActive(false);
        invalidHomeroomText = GameObject.Find("InvalidHomeroom");
        invalidHomeroomText.SetActive(false);

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
        if (Input.GetKey(KeyCode.Return))
        {
            Submit();
        }
    }

    //Get player infromation from the game (name, homeroom and score), check it is valid and send it to the ScoreboardDataManager
    void Submit()
    {
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
        else if (CheckName() == false && CheckHomeroom() == true)
        {
            invalidNameText.SetActive(true);
            invalidHomeroomText.SetActive(false);
            Debug.Log("invalid name");
        }
        else if (CheckName() == true && CheckHomeroom() == false)
        {
            invalidHomeroomText.SetActive(true);
            invalidNameText.SetActive(false);
            Debug.Log("invalid homeroom");
        }
        else if (CheckName() == false && CheckHomeroom() == false)
        {
            invalidNameText.SetActive(true);
            Debug.Log("invalid name");
            invalidHomeroomText.SetActive(true);
            Debug.Log("invalid homeroom");
        }
    }

    //Checking for a valid name within a reasonable length (12 characters)
    private bool CheckName()
    {
        bool isValid;
        string playerName = nameInput.text;

        //Check that name input is not empty and it is less than 12 characters long (Boundary)
        if (playerName.Length < 12 && playerName != "")
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
        //Setting the user's input to all caps to match naming standards
        string playerHomeroom = homeroomInput.text.ToUpper();

        //Check that homeroom input is not empty, it is 3 characters long (Boundary) and has a valid first letter (Invalid)
        if (playerHomeroom != "" && ((playerHomeroom[0] == 'J' || playerHomeroom[0] == 'M' || playerHomeroom[0] == 'B' || playerHomeroom[0] == 'D' || playerHomeroom[0] == 'P') && playerHomeroom.Length == 3))
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
