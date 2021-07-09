using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> objectSpawnList = new List<GameObject>();
    public float timer;
    public GameObject jumpUpPrefab, duckDownPrefab, dodgeLeftPrefab, dodgeRightPrefab; //add other items here



    // Start is called before the first frame update
    void Start()
    {
        timer = 1.5f;
        objectSpawnList.Add(jumpUpPrefab); //0
        objectSpawnList.Add(duckDownPrefab); //1
        objectSpawnList.Add(dodgeRightPrefab); //2
        objectSpawnList.Add(dodgeLeftPrefab); //3
    }



    // Update is called once per frame
    void Update()
    {
        //SpawnObjects();
    }



    private void SpawnObjects()
    {
        timer = timer - Time.deltaTime;



        if (timer < 0)
        {
            timer = 1.5f;
            int randomNum = Random.Range(0, objectSpawnList.Count);
            Instantiate(objectSpawnList[randomNum], this.transform.position, this.transform.rotation);
        }
    }
}