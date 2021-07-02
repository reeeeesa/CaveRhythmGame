using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuControls : MonoBehaviour
{
    public Button nextButton;
    public Button previousButton;
    public Button menuButton;
    public Button playButton;


    // Start is called before the first frame update
    void Start()
    {
        Component[] buttonComponents = GetComponentsInChildren<Button>();
        nextButton = buttonComponents[0].GetComponent<Button>();
        previousButton = buttonComponents[1].GetComponent<Button>();
        menuButton = buttonComponents[2].GetComponent<Button>();
        playButton = buttonComponents[3].GetComponent<Button>();

        nextButton.onClick.AddListener(delegate { NextSong(); });
        previousButton.onClick.AddListener(delegate { PreviousSong(); });
        menuButton.onClick.AddListener(delegate { OpenMenu(); });
        playButton.onClick.AddListener(delegate { StartGame(); });

    }

    private void StartGame()
    {
        Debug.Log("Load Game Scene");
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    private void NextSong()
    {
        Debug.Log("Next Song");
    }

    private void PreviousSong()
    {
        Debug.Log("Previous Song");
    }

    private void OpenMenu()
    {
        Debug.Log("Open Menu");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
