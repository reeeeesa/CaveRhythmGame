using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private SongManager songManager;
    private float BeatsShownInAdvance = 4;
    private Vector3 SpawnPos =  new Vector3(0f, 0.18f, 25f);
    private Vector3 RemovePos = new Vector3(0f, 0.18f, -7.5f);
    [SerializeField]private float beatOfThisNote, songPosInBeats, t;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
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
        //Movement();
    }

    private void Movement()
    {
        transform.position = transform.position + new Vector3(0, 0, -1 * speed * Time.deltaTime);



        if (transform.position.z < -20f)
        {
            Destroy(this.gameObject);
            Debug.Log("NPC Destroyed");
        }
    }
}