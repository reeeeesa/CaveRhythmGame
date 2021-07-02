using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelectMenu : MonoBehaviour
{
    public GameObject song1;
    public GameObject song2;
    public GameObject song3;

    // Start is called before the first frame update
    void Start()
    {
        song1 = GameObject.Find("Song1");
        song1.SetActive(false);
        song2 = GameObject.Find("Song2");
        song2.SetActive(false);
        song3 = GameObject.Find("Song3");
        song3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
