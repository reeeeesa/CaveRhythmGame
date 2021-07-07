using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Purpose: 
public class Player : MonoBehaviour
{
    [SerializeField] private int score, speed;
    [SerializeField] private int health;
    [SerializeField] private MenuManager menuManager;
    private Vector3 bounds;

    public int Score
    {
        get => score;
    }

    // Start is called before the first frame update
    void Start()
    {
        menuManager = FindObjectOfType<MenuManager>();
        health = 10;
        bounds = new Vector2(-1, -1);
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, bounds.x, bounds.x * -1);
        viewPos.y = Mathf.Clamp(viewPos.y, bounds.y, bounds.y * -1);
        transform.position = viewPos;
    }

    public void Movement()
    {
        transform.position = transform.position + new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0); // zoom zoom
        /*if (Input.GetKeyDown(leftArrow)){
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
        }*/
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
            Debug.Log("Health lost");
        }

        if (health <= 0)
        {
            menuManager.DisplayGameOverMenu();
        }
    }
}

