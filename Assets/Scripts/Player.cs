using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Purpose: Manages player movement, collisions and score
public class Player : MonoBehaviour
{

    [SerializeField] private int score, comboMult, health;
    [SerializeField] private MenuManager menuManager;
    [SerializeField] private Animator animator;
    public Slider healthSlider;
    
    // Movement variables and targets
    private float speed = 0.8f;
    private Vector3 rightTarget = new Vector3(1, -0.47f, -7.5f);
    private Vector3 leftTarget = new Vector3(-1, -0.47f, -7.5f);
    private Vector3 upTarget = new Vector3(0, 0.53f, -7.5f);
    private Vector3 origin;

    //gets score for other classes to read
    public int Score
    {
        get => score;
    }

    //gets combo for other classes to read
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

    //resets combo back to 0
    public void LostCombo()
    {
        comboMult = 0;
    }

    //Listens for key presses and starts their respective movement code, then resets their position once the key is up
    private void Movement()
    {
        //move left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            StartCoroutine(MoveLeft());
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            leftTarget = new Vector3(-1, -0.47f, -7.5f);
            transform.position = origin;
        }
        //move right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            StartCoroutine(MoveRight());
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rightTarget = new Vector3(1, -0.47f, -7.5f);
            transform.position = origin;
        }
        //move up
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            StartCoroutine(MoveUp());
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) 
        { 
           upTarget = new Vector3(0, 0.53f, -7.5f);
           transform.position = origin;
        }

    }

    //moves player towards rightTarget and when it gets there makes rightTarget the origin so it moves back
    IEnumerator MoveRight()
    {
        transform.position = Vector3.MoveTowards(transform.position, rightTarget, speed * Time.deltaTime);
        if (transform.position == rightTarget) rightTarget = origin;
        yield return 0;
    }
    //moves player towards leftTarget and when it gets there makes leftTarget the origin so it moves back
    IEnumerator MoveLeft()
    {
        transform.position = Vector3.MoveTowards(transform.position, leftTarget, speed * Time.deltaTime);
        if (transform.position == leftTarget) leftTarget = origin;
        yield return 0;
    }
    //moves player towards upTarget and when it gets there makes upTarget the origin so it moves back
    IEnumerator MoveUp()
    {
        transform.position = Vector3.MoveTowards(transform.position, upTarget, speed * Time.deltaTime);
        if (transform.position == upTarget) upTarget = origin;
        yield return 0;
    }

    //handles collisions the player makes 
    private void OnTriggerEnter(Collider other)
    {

        // When player triggers a collision with a "Miss" tagged object, take away health and reset combo
        if (other.CompareTag("Miss"))
        {
            health--;
            LostCombo();
            Debug.Log("Health lost");

        }

        // When the player triggers a collision with a "Hit" tagged object, add to score and combo
        if (other.CompareTag("Hit"))
        {
            score += (10 * (comboMult + 1));
            comboMult++;
        }

        // When the player runs out of health, display GameOverMenu
        if (health <= 0)
        {
            menuManager.DisplayGameOverMenu();
        }
    }
}

