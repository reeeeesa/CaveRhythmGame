using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{

    //Reference to the AudioSource component which should be atatched to the sound manager
    AudioSource audioSource;

    //The music track that the sound manager should play
    [SerializeField]
    AudioClip musicTrack;

    //The offset to the first beat of the song in seconds
    [SerializeField]
    float firstBeatOffset;

    //Song beats per minute
    //This is determined by the song you're trying to sync up to
    public float songBpm;

    //Current song position, in beats
    public float songPositionInBeats;

    //The number of seconds for each song beat
    float secPerBeat;

    //Current song position, in seconds
    float songPosition;

    //How many seconds have passed since the song started
    float dspSongTime;

    // Start is called before the first frame update
    void Start()
    {
        //Get a reference to the Audio Source attached to the sound manager game object
        audioSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        //Start the music
        PlayMusicTrack();
    }

    // Update is called once per frame
    void Update()
    {
        //determine how many seconds since the song started
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);

        //determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;
    }

    void PlayMusicTrack()
    {
        audioSource.PlayOneShot(musicTrack);
    }
}