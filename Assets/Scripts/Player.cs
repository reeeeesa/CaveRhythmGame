using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Purpose: 
public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int score;
    [SerializeField] private MenuManager menuManager;

    public int Score
    {
        get => score;
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        menuManager = FindObjectOfType<MenuManager>();
    }


    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        transform.position = transform.position + new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
    }

    // ontrigger to detect a reward using "Reward" Tag
    private void OnTriggerEnter(Collider other)
    {
        // ontrigger to detect an NPC using "NPC" Tag
        if (other.CompareTag("NPC"))
        {
            menuManager.DisplayScoreEntryUI();
        }

    }
}
