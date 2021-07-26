using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelectMenu : MonoBehaviour
{
    public Button nextButton, previousButton, menuButton, playButton;
    public int songPosition;
    public Slider songSlider;


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

        songPosition = 0;
        songSlider.value = songPosition;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow)) NextSong();
        if (Input.GetKeyUp(KeyCode.LeftArrow)) PreviousSong();
        if (Input.GetKeyUp(KeyCode.KeypadEnter)) StartGame();
    }

    private void StartGame()
    {
        Debug.Log("Load Game Scene");
        if (songPosition == 0)
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }
        else if (songPosition == 1)
        {
            SceneManager.LoadScene("Song1", LoadSceneMode.Single);
        }
        else if (songPosition == 2)
        {
            SceneManager.LoadScene("Song2", LoadSceneMode.Single);
        }
        else
        {
            songPosition = 0;
        }
    }

    private void NextSong()
    {
        Debug.Log("Next Song");
        songPosition++;
        songSlider.value = songPosition;
    }

    private void PreviousSong()
    {
        Debug.Log("Previous Song");
        songPosition--;
        songSlider.value = songPosition;
    }

    private void OpenMenu()
    {
        Debug.Log("Open Menu");
        SceneManager.LoadScene("0StartScene", LoadSceneMode.Single);
    }
    // Update is called once per frame
    
}