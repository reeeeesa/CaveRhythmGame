using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Puropse: Move the objects at a speed according to the song and destroy them once they get past the player
public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private SongManager songManager;
    [SerializeField] private float beatOfThisNote, songPosInBeats, t;

    //Constant to make the code more flexible if I wish to have them spawn earlier to make a higher speed
    private const float BeatsShownInAdvance = 4;

    //Spawn and remove positions
    private Vector3 SpawnPos = new Vector3(0f, 0.18f, 25f);
    private Vector3 RemovePos = new Vector3(0f, 0.18f, -7.5f);
    

    // Start is called before the first frame update
    void Start()
    {
        //find song manager class
        songManager = FindObjectOfType<SongManager>();

        //assign a beat to the obstacle from the SongManager
        beatOfThisNote = songManager.beatOfThisNote;
    }


    // Update is called once per frame
    void Update()
    {
        //update the song position
        songPosInBeats = songManager.songPositionInBeats;

        //Calculate the variable used to lerp the obstacle using info from the SongManager so it makes it there on beat
        t = (BeatsShownInAdvance - (beatOfThisNote - songPosInBeats)) / BeatsShownInAdvance;

        //Move the obstacles between a start and end positon according to t (Lerp the objects)
        transform.position = Vector3.Lerp(SpawnPos, RemovePos, t);

        //Destroy object when it gets past the player
        if (transform.position.z <= -7.5)
        {
            Destroy(this.gameObject);
            Debug.Log("NPC Destroyed");
        }
    }
}