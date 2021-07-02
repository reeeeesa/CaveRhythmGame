using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Purpose: 
public class GameManager : MonoBehaviour
{
    private Player player;
    private LevelSelectMenu song;
    private int currentLevel; // track current level
    private int lastLevel = 3; // set last level

    void Awake()
    {
        player = FindObjectOfType<Player>();
        song = FindObjectOfType<LevelSelectMenu>();
    }

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        if (player.levelComplete)
        {
            player.levelComplete = false;
            LoadNextLevel();
        }
    }

    // Return current level
    public int GetLevel()
    {
        return currentLevel;
    }

    // Start or re-start a game - load and unload appropriate scenes
    public void StartGame()
    {
        currentLevel = 1; // when game begins start at level 1 scene
        SceneManager.LoadScene(currentLevel, LoadSceneMode.Additive);
    }

    // Load Next Level or EndGame
    public void LoadNextLevel()
    {
        // if check to load next scene/level
        if (currentLevel < lastLevel)
        {
            Debug.Log("Level Completed");
            //unload current Level
            SceneManager.UnloadSceneAsync(currentLevel);
            // Merge next scene with Game Scene
            SceneManager.LoadScene("2LevelSelectScene", LoadSceneMode.Additive);
        }
        else
        {
            Debug.Log("Game Over");
        }
    }
}
