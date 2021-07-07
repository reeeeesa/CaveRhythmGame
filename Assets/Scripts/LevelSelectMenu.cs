using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelectMenu : MonoBehaviour
{
    public Button nextButton, previousButton, menuButton, playButton;
    private int songPosition;
    public GameObject songInfo;
    //public List<GameObject> songList = new List<GameObject>();
    //public GameObject song1, song2, song3;


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
        songInfo = GameObject.Find("SongInfo");

        //song1 = GameObject.Find("Song1");
        //song2 = GameObject.Find("Song2");
        //song2.SetActive(false);
        //song3 = GameObject.Find("Song3");
        //song3.SetActive(false);

        //songList.Add(song1);
        //songList.Add(song2);
        //songList.Add(song3);
    }

    //public void DisplaySong1()
    //{
    //    song1.SetActive(true);
    //}

    //public void DisplaySong2()
    //{
    //    song2.SetActive(true);
    //}

    //public void DisplaySong3()
    //{
    //    song3.SetActive(true);
    //}

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
        songInfo.transform.Translate(1000, 0, 0, Space.Self);
    }

    private void PreviousSong()
    {
        Debug.Log("Previous Song");
        songPosition--;
        songInfo.transform.Translate(-1000, 0, 0, Space.Self);
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