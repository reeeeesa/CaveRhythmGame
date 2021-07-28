using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Purpose: 
public class Player : MonoBehaviour
{

    [SerializeField] private int score, comboMult, health;
    [SerializeField] private MenuManager menuManager;
    [SerializeField] private Animator animator;
    public Slider healthSlider;
    
    // Movement variables
    private float speed = 0.8f;
    private Vector3 rightTarget = new Vector3(1, -0.47f, -7.5f);
    private Vector3 leftTarget = new Vector3(-1, -0.47f, -7.5f);
    private Vector3 upTarget = new Vector3(0, 0.53f, -7.5f);
    private Vector3 origin;

    public int Score
    {
        get => score;
    }

    public int Combo
    {
        get => comboMult;
    }

    // Start is called before the first frame update
    void Start()
    {
        menuManager = FindObjectOfType<MenuManager>();
        health = 10;
        speed = 10;
        comboMult = 0;

        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;
        Movement();
    }

    public void LostCombo()
    {
        comboMult = 0;
    }

    private void Movement()
    {
        //move left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            StartCoroutine(MoveLeft());
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            leftTarget = new Vector3(-1, -0.47f, -7.5f);
            transform.position = origin;
        }
        //move right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            StartCoroutine(MoveRight());
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rightTarget = new Vector3(1, -0.47f, -7.5f);
            transform.position = origin;
        }
        //move up
        if (Input.GetKey(KeyCode.UpArrow))
        {
            StartCoroutine(MoveUp());
        }
        if (Input.GetKeyUp(KeyCode.UpArrow)) 
        { 
           upTarget = new Vector3(0, 0.53f, -7.5f);
           transform.position = origin;
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
            LostCombo();
            Debug.Log("Health lost");

        }

        if (other.CompareTag("Score"))
        {
            score += (10 * (comboMult + 1));
            comboMult++;
        }

        if (health <= 0)
        {
            menuManager.DisplayGameOverMenu();
        }
    }
}

