using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Purpose: 
public class Player : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private int health;
    [SerializeField] private MenuManager menuManager;
    //private Vector3 bounds;
    private CapsuleCollider cCollider;
    
    // Movement variables
    public float speed = 1;
    public Vector3 rightTarget = new Vector3(1, -0.47f, -7.5f);
    public Vector3 leftTarget = new Vector3(-1, -0.47f, -7.5f);
    public Vector3 upTarget = new Vector3(0, 0.53f, -7.5f);
    private Vector3 origin;

    public int Score
    {
        get => score;
    }

    // Start is called before the first frame update
    void Start()
    {
        menuManager = FindObjectOfType<MenuManager>();
        health = 10;
        speed = 10;
        cCollider = GetComponent<CapsuleCollider>();

        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
    }

    public void Movement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            StartCoroutine(MoveLeft());
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)) leftTarget = new Vector3(-1, -0.47f, -7.5f);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            StartCoroutine(MoveRight());
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)) rightTarget = new Vector3(1, -0.47f, -7.5f);
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            StartCoroutine(MoveUp());
        }
        if (Input.GetKeyUp(KeyCode.UpArrow)) upTarget = new Vector3(0, 0.53f, -7.5f);

        if (Input.GetKey(KeyCode.DownArrow))
        {
            cCollider.height = 1;
        }
    }

    IEnumerator MoveRight()
    {
        transform.position = Vector3.MoveTowards(transform.position, rightTarget, speed * Time.deltaTime);
        if (transform.position == rightTarget) rightTarget = origin;
        yield return 0;
    }
    IEnumerator MoveLeft()
    {
        transform.position = Vector3.MoveTowards(transform.position, leftTarget, speed * Time.deltaTime);
        if (transform.position == leftTarget) leftTarget = origin;
        yield return 0;
    }
    IEnumerator MoveUp()
    {
        transform.position = Vector3.MoveTowards(transform.position, upTarget, speed * Time.deltaTime);
        if (transform.position == upTarget) upTarget = origin;
        yield return 0;
    }

    // ontrigger to detect a collision
    private void OnTriggerEnter(Collider other)
    {

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

