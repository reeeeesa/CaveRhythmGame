using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TunnelMovement : MonoBehaviour
{
    [SerializeField] private float speed;



    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
    }



    // Update is called once per frame
    void Update()
    {
        Movement();
    }



    private void Movement()
    {
        transform.position = transform.position + new Vector3(0, 0, -1 * speed * Time.deltaTime);



        if (transform.position.z < -30f)
        {
            Destroy(this.gameObject);
            //Debug.Log("Tunnel Destroyed");
        }
    }
}