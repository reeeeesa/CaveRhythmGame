using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager1 : MonoBehaviour
{
    //Song beats per minute
    //This is determined by the song you're trying to sync up to
    public float songBpm;

    //The number of seconds for each song beat
    public float secPerBeat;

    //Current song position, in seconds
    public float songPosition;

    //Current song position, in beats
    public float songPositionInBeats;

    //How many seconds have passed since the song started
    public float dspSongTime;

    //an AudioSource attached to this GameObject that will play the music.
    public AudioSource musicSource;

    //the index of the next note to be spawned
    private int nextIndex = 0;

    //beat the current note will be spawned on
    public float beatOfThisNote;

    //keep all the position-in-beats of notes in the song
    private readonly float[] notes = new float[] { 6f, 7f, 8f, 10f, 11f, 12f, 152f };

    //Note prefabs
    public List<GameObject> objectSpawnList = new List<GameObject>();
    public GameObject jumpUpPrefab, dodgeLeftPrefab, dodgeRightPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //Load the AudioSource attached to the Conductor GameObject
        musicSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        //Start the music
        musicSource.Play();

        objectSpawnList.Add(jumpUpPrefab); //0
        objectSpawnList.Add(dodgeRightPrefab); //1
        objectSpawnList.Add(dodgeLeftPrefab); //2
    }

    // Update is called once per frame
    void Update()
    {
        //determine how many seconds since the song started
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);

        //determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;

        if (nextIndex < notes.Length && notes[nextIndex] < songPositionInBeats + 4)
        {
            int randomNum = Random.Range(0, objectSpawnList.Count);
            Instantiate(objectSpawnList[randomNum], this.transform.position, this.transform.rotation);

            //initialize the fields of the music note

            nextIndex++;
        }
        
        beatOfThisNote = notes[nextIndex];
    }
}
