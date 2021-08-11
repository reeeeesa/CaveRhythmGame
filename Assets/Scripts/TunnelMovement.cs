using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Purpose: Move the tunnels towards the player
public class TunnelMovement : MonoBehaviour
{
    //Speed is constant to make code more flexible
    private const float speed = 10;

    // Update is called once per frame
    void Update()
    {
        Movement();
    }


    //Moves the tunnel and destroys is after it leaves vision
    private void Movement()
    {
        transform.position = transform.position + new Vector3(0, 0, -1 * speed * Time.deltaTime);


        if (transform.position.z < -30f)
        {
            Destroy(this.gameObject);
        }
    }
}