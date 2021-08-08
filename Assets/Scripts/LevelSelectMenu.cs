using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

//Purpose: Scroll through panels of song details and open corresponding scene for active song selected.
public class LevelSelectMenu : MonoBehaviour
{
    public Button nextButton, previousButton, menuButton, playButton;
    public int songPosition;
    public Slider songSlider;

    // Start is called before the first frame update
    void Start()
    {
        //Find all buttons and put them in an array
        Component[] buttonComponents = GetComponentsInChildren<Button>();
        nextButton = buttonComponents[0].GetComponent<Button>();
        previousButton = buttonComponents[1].GetComponent<Button>();
        menuButton = buttonComponents[2].GetComponent<Button>();
        playButton = buttonComponents[3].GetComponent<Button>();

        //Listen for clicks on the buttons
        nextButton.onClick.AddListener(delegate { NextSong(); });
        previousButton.onClick.AddListener(delegate { PreviousSong(); });
        menuButton.onClick.AddListener(delegate { OpenMenu(); });
        playButton.onClick.AddListener(delegate { StartGame(); });

        //Set the song details to the correct position
        songPosition = 0;
        songSlider.value = songPosition;
    }

    void Update()
    {
        //If right or left arrows are pressed, go to  next or previous song ans if enter is pressed, start game
        if (Input.GetKeyUp(KeyCode.RightArrow)) NextSong();
        if (Input.GetKeyUp(KeyCode.LeftArrow)) PreviousSong();
        if (Input.GetKeyUp(KeyCode.Return)) StartGame();
    }

    //Loads appropriate scene according to what the song position is
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

    //Adds 1 to songPosition and moves slider to show details of corresponding song
    private void NextSong()
    {
        Debug.Log("Next Song");
        songPosition++;
        songSlider.value = songPosition;
    }

    //Subtacts 1 to songPosition and moves slider to show details of corresponding song
    private void PreviousSong()
    {
        Debug.Log("Previous Song");
        songPosition--;
        songSlider.value = songPosition;
    }

    //Loads start screen
    private void OpenMenu()
    {
        Debug.Log("Open Menu");
        SceneManager.LoadScene("0StartScene", LoadSceneMode.Single);
    }
}