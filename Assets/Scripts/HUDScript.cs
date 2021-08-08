using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Purpose: Update the status of the HUD elements to give the user feedback on their condition
public class HUDScript : MonoBehaviour
{
    //Declare UI elements
    public TextMeshProUGUI scoreTMP, comboTMP;
    [SerializeField] private Button pauseButton;

    //Declare classes
    private MenuManager menuManager;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        //find classes that provide information shown in HUD
        menuManager = FindObjectOfType<MenuManager>();
        player = FindObjectOfType<Player>();

        Component[] buttonComponents; // create array for buttons 
        buttonComponents = GetComponentsInChildren<Button>(); // store all the buttons in an array
        pauseButton = buttonComponents[0].GetComponent<Button>(); // Get First Button

        pauseButton.onClick.AddListener(delegate { Debug.Log("Pause"); menuManager.DisplayPauseMenu(); });
    }

    // Update is called once per frame
    void Update()
    {
        //update the text for the score and combo
        scoreTMP.text = player.Score.ToString();
        comboTMP.text = player.Combo.ToString();
    }
}
