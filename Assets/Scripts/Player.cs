using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Purpose: 
public class Player : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private int health;
    [SerializeField] private MenuManager menuManager;
    KeyCode leftArrow = KeyCode.LeftArrow;
    KeyCode rightArrow = KeyCode.RightArrow;
    KeyCode upArrow = KeyCode.UpArrow;
    KeyCode downArrow = KeyCode.DownArrow;

    public int Score
    {
        get => score;
    }

    // Start is called before the first frame update
    void Start()
    {
        menuManager = FindObjectOfType<MenuManager>();
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        if (Input.GetKeyDown(leftArrow)){
            transform.position = transform.position + new Vector3(-1, 0, 0);
        }
        if (Input.GetKeyDown(rightArrow))
        {
            transform.position = transform.position + new Vector3(1, 0, 0);
        }
        if (Input.GetKeyDown(upArrow))
        {
            transform.position = transform.position + new Vector3(0, 1, 0);
        }
        if (Input.GetKeyDown(downArrow))
        {
            transform.position = transform.position + new Vector3(0, -1, 0);
        }

    }

    // ontrigger to detect a collision
    private void OnTriggerEnter(Collider other)
    {
        // ontrigger to detect a reward using "Reward" Tag
        /*if (other.CompareTag("Reward"))
        {
            score++;
            Debug.Log("Score: " + score);
            Debug.Log("Collide: " + other);
            Destroy(other.gameObject);
        }*/

        // ontrigger to detect an obstacle using "NPC" Tag
        if (other.CompareTag("NPC"))
        {
            health--;
        }

        if (health <= 0)
        {
            menuManager.DisplayGameOverMenu();
        }
    }
}

