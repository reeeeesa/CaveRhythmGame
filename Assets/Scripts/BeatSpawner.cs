using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
    public BarPositionsList barPositionsList;

    public GameObject[] cubes;

    public Transform[] spawnPoints;

    [SerializeField]
    SoundManager soundManager;

    public float beatsPerMinute = 0;

    private float timer;

    [SerializeField]
    float beatsPerBar = 4.0f;

    int currentBarPositionIndex = 0;

    int currentBeatPositionIndexInBar = 0;

    float nextBeatPosition = 0;

    private void Start()
    {
        SetNextBeatPosition();
    }

    // Update is called once per frame
    void Update()
    {
        //CheckBasicNoteSpawning();

        CheckHasNextBeatBeenReached();
    }

    private void CheckHasNextBeatBeenReached()
    {
        if(soundManager.songPositionInBeats >= nextBeatPosition)
        {
            SpawnBeat();
            SetNextBeatPosition();
        }
    }

    private void CheckBasicNoteSpawning()
    {
        if (timer > 60 / beatsPerMinute * 4)
        {
            SpawnBeat();
            timer -= 60 / beatsPerMinute * 4;
        }

        timer += Time.deltaTime;
    }

    void SetNextBeatPosition()
    {

        bool hasNextBeatBeenFound = false;

        for (int i = currentBarPositionIndex; i < barPositionsList.barPositionsList.Count; i++)
        {
            Bar barToCheck = barPositionsList.barPositionsList[i];
            for(int j = currentBeatPositionIndexInBar; i < barToCheck.beatPositions.beatPositions.Count; j++)
            {
                Beat beatToCheck = barToCheck.beatPositions.beatPositions[j];
                if(beatToCheck.beatLength == 1)
                {
                    hasNextBeatBeenFound = true;
                    nextBeatPosition = currentBarPositionIndex * beatsPerBar 
                        + currentBeatPositionIndexInBar / beatsPerBar;
                    currentBarPositionIndex = i + 1; //move to next index
                    currentBeatPositionIndexInBar = j + 1; //move to next index
                    break;
                }
            }
            if(hasNextBeatBeenFound)
            {
                break;
            }
        }

        if(!hasNextBeatBeenFound)
        {
            EndGame();
        }
            
    }

    private void EndGame()
    {
        throw new NotImplementedException();
    }

    private void SpawnBeat()
    {
        throw new NotImplementedException();
    }
}

[System.Serializable]
public class BeatPositionsList
{
    public List<Beat> beatPositions;
}

[System.Serializable]
public class Beat
{
    //int for now, 0 if it's a rest, 1 if there's a note
    public int beatLength = 0;


    //to be done: add direction
}


[System.Serializable]
public class Bar
{
    public BeatPositionsList beatPositions;

    /*
    public int repeatThisNumberOfTimes = 0;

    public float updateBPM = -1.0f;

    public float updateBeatsInLoop = -1.0f;
    */
}

[System.Serializable]
public class BarPositionsList
{
    public List<Bar> barPositionsList;
}
