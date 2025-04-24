using System.Collections;
using System.Collections.Generic;
using Dodge;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    public DILIHGameManager gameManager;
    public Animator runAnimation;

    //reference to the player rigid body 2D and UI
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        // hack to unpause the game.
        Time.timeScale = 1;

        //get reference to players Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        // Get user input for movement (assuming arrow keys)
        // let's us Input.GetAxis() and grab the "Horizontal" input
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move the player based on the movement vector
        rb.velocity = new Vector2(horizontalInput, 0) * moveSpeed;

        if (Input.GetKeyDown(KeyCode.A))
        {
            runAnimation.SetBool("move", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            runAnimation.SetBool("move", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            runAnimation.SetBool("move", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            runAnimation.SetBool("move", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    // Player must avoid the falling rocks.
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Check for the tag "Hazard" to check for hostiles.
        if (collision.CompareTag("Hazard"))
        {
            // Check to see if we have a reference to the gamemanager first.
            if (gameManager != null)
            {
                Debug.Log("Ouch!");
                gameManager.GameOverTwo();
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            }
        }
    }
}
