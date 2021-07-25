using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDScript : MonoBehaviour
{
    public TextMeshProUGUI scoreTMP;
    public Image h1;
    [SerializeField] private Button pauseButton;
    private Player player;
    private MenuManager menuManager;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        menuManager = FindObjectOfType<MenuManager>();

        Component[] buttonComponents;
        buttonComponents = GetComponentsInChildren<Button>(); // store all the buttons in an array
        pauseButton = buttonComponents[0].GetComponent<Button>(); // Get First Button

        pauseButton.onClick.AddListener(delegate { Debug.Log("Pause"); menuManager.DisplayPauseMenu(); });
    }

    // Update is called once per frame
    void Update()
    {
        scoreTMP.text = player.Score.ToString();
    }
}
