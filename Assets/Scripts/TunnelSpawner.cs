using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TunnelSpawner : MonoBehaviour
{
    public float timer;
    public GameObject tunnelPrefab;



    // Start is called before the first frame update
    void Start()
    {
        timer = 1f;
    }



    // Update is called once per frame
    void Update()
    {
        SpawnObjects();
    }



    private void SpawnObjects()
    {
        timer = timer - Time.deltaTime;



        if (timer < 0)
        {
            timer = 1;
            Instantiate(tunnelPrefab, this.transform.position, this.transform.rotation);
        }
    }
}