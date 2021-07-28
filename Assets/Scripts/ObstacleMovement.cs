using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private SongManager songManager;
    private const float BeatsShownInAdvance = 4;
    private Vector3 SpawnPos = new Vector3(0f, 0.18f, 25f);
    private Vector3 RemovePos = new Vector3(0f, 0.18f, -7.5f);
    [SerializeField] private float beatOfThisNote, songPosInBeats, t;

    // Start is called before the first frame update
    void Start()
    {
        songManager = FindObjectOfType<SongManager>();
        beatOfThisNote = songManager.beatOfThisNote;
    }


    // Update is called once per frame
    //the update function of music notes
    void Update()
    {
        songPosInBeats = songManager.songPositionInBeats;

        t = (BeatsShownInAdvance - (beatOfThisNote - songPosInBeats)) / BeatsShownInAdvance;

        transform.position = Vector3.Lerp(SpawnPos, RemovePos, t);

        if (transform.position.z <= -7.5f)
        {
            Destroy(this.gameObject);
            Debug.Log("NPC Destroyed");
        }
    }
}