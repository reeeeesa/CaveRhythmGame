using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDScript : MonoBehaviour
{
    public TextMeshProUGUI scoreTMP, comboTMP;
    [SerializeField] private Button pauseButton;
    private MenuManager menuManager;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        menuManager = FindObjectOfType<MenuManager>();
        player = FindObjectOfType<Player>();

        Component[] buttonComponents;
        buttonComponents = GetComponentsInChildren<Button>(); // store all the buttons in an array
        pauseButton = buttonComponents[0].GetComponent<Button>(); // Get First Button

        pauseButton.onClick.AddListener(delegate { Debug.Log("Pause"); menuManager.DisplayPauseMenu(); });
    }

    // Update is called once per frame
    void Update()
    {
        scoreTMP.text = player.Score.ToString();
        comboTMP.text = player.Combo.ToString();
    }
}
