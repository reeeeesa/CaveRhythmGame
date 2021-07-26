using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    //Song beats per minute
    //This is determined by the song you're trying to sync up to
    public float songBpm;

    //final beat of the song
    [SerializeField] private float lastBeat;

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
    private readonly float[] notes = new float[] { 7, 8, 12, 15, 16, 19, 20, 21, 23, 25, 27, 29, 30, 33, 34, 37, 39, 41, 43, 45, 47, 49, 51, 53, 54, 55, 57, 58, 59, 61, 63, 65, 66, 67, 68, 69, 73, 77, 81, 85, 89, 93, 97, 98, 99, 100, 101, 105, 106, 107, 113, 114, 115, 121, 122, 123, 129, 130, 131, 134, 135, 136, 137, 142, 143, 144, 145, 150, 151, 152, 153, 158, 159, 160, 161, 165, 175 };

    //Note prefabs
    public List<GameObject> objectSpawnList = new List<GameObject>();
    public GameObject jumpUpPrefab, dodgeLeftPrefab, dodgeRightPrefab;

    //for scene management
    private MenuManager menuManager;
    [SerializeField] private int score, comboMult;

    public int Score
    {
        get => score;
    }

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

        menuManager = FindObjectOfType<MenuManager>();

        objectSpawnList.Add(jumpUpPrefab); //0
        objectSpawnList.Add(dodgeRightPrefab); //1
        objectSpawnList.Add(dodgeLeftPrefab); //2

        comboMult = 1;
    }

    public void LostCombo()
    {
        comboMult = 1;
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
            
            //initialize the fields of the music note
            int randomNum = Random.Range(0, objectSpawnList.Count);
            Instantiate(objectSpawnList[randomNum], this.transform.position, this.transform.rotation);
            
            nextIndex++;
        }

        if (nextIndex < notes.Length && notes[nextIndex] < songPositionInBeats)
        {
            score += (10 * comboMult);
            comboMult++;
        }

        if (songPositionInBeats >= lastBeat)
        {
            menuManager.DisplayScoreEntryUI();
        }
        
        beatOfThisNote = notes[nextIndex];
    }
}
