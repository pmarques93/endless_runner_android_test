using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Editor Fields
    [SerializeField] private GameObject groundPosition;
    [SerializeField] private LayerMask  groundLayer;
    [SerializeField] private LayerMask  obstaclesLayer;

    // Rb Stuff
    Vector2 currentVelocity;

    // Jump
    private bool onGround       = false;
    private bool jumped         = false;
    [SerializeField] float jumpSpeed;
    [SerializeField] float jumpMaxTime;
    private float jumpTimeCounter;

    // Components
    private Rigidbody2D rb;
    private Animator anim;

    // Score
    [SerializeField] private GameObject perfectScorePrefab;
    [SerializeField] private GameObject middleScorePrefab;
    [SerializeField] private GameObject lowScorePrefab;
    [SerializeField] private GameObject perfectScoreNumber;
    [SerializeField] private GameObject middleScoreNumber;
    [SerializeField] private GameObject lowScoreNumber;
    [SerializeField] private Transform  scoreSpawnPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // Jump timer
        jumpTimeCounter = jumpMaxTime;
    }

    private void Update()
    {
        if (LevelManager.gameOver == false)
        {
            currentVelocity = rb.velocity;

            Grounded();
            Jump();
            Score();

            rb.velocity = currentVelocity;
        }

        // Animations
        anim.SetBool("grounded", onGround);
        anim.SetBool("gameRunning", LevelManager.running);
    }

    void Grounded()
    {
        // onGround confirm
        Collider2D groundHit = Physics2D.OverlapCircle(groundPosition.transform.position, 0.2f, groundLayer);
        if (groundHit != null && jumped == false)
            onGround = true;
        else
            onGround = false;
    }

    void Jump()
    {
        // Pressed jump
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && onGround && LevelManager.levelTimer > 0.01f)
            {
                SoundManager.PlaySound("jump");  // Plays jump sound
                currentVelocity.y = jumpSpeed;
                rb.gravityScale = 0.0f;
                jumpTimeCounter = Time.time;
            }
            // While touching or while actual time - jump time (when pressed) < jump max time
            else if ((touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) && ((Time.time - jumpTimeCounter) < jumpMaxTime))
            {
            }
            else
                rb.gravityScale = 10f;
        }

    }

    void Score()
    {   
        // Creates a collider to get the obstacle
        Collider2D obstacle = Physics2D.OverlapCircle(transform.position, 5.5f, obstaclesLayer);
        if (obstacle != null)
        {
            
            Obstacle obs = obstacle.GetComponent<Obstacle>(); // Gets the obstacle object

            Vector2 closestPoint = obstacle.ClosestPoint(transform.position); // Gets closest point from player position
            
            if (transform.position.x > obstacle.transform.position.x && obs.scored == false) // if the obstacle is behind the player
            {
                obs.scored = true; // The obstacle can't give a score anymore
                SoundManager.PlaySound("score"); // Plays score sound

                if (closestPoint.y - groundPosition.transform.position.y <= -2.5f) // Low score
                {
                    Instantiate(lowScorePrefab, transform.position, perfectScorePrefab.transform.rotation);
                    Instantiate(lowScoreNumber, scoreSpawnPosition.transform.position, transform.rotation);
                    LevelManager.score += 1;
                }

                else if (closestPoint.y - groundPosition.transform.position.y > -2.5f && closestPoint.y - groundPosition.transform.position.y < -1f) // Mid score
                {
                    Instantiate(middleScorePrefab, transform.position, perfectScorePrefab.transform.rotation);
                    Instantiate(middleScoreNumber, scoreSpawnPosition.transform.position, transform.rotation);
                    LevelManager.score += 2;
                }

                else if (closestPoint.y - groundPosition.transform.position.y >= -1f) // Perfect score
                {
                    Instantiate(perfectScorePrefab, transform.position, perfectScorePrefab.transform.rotation);
                    Instantiate(perfectScoreNumber, scoreSpawnPosition.transform.position, transform.rotation);
                    LevelManager.score += 3;
                }

            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            rb.gravityScale = 10f;
            
            // Sets highscore
            if (LevelManager.score > PlayerPrefs.GetInt("Highscore"))
                PlayerPrefs.SetInt("Highscore", LevelManager.score);

            LevelManager.running    = false;
            LevelManager.gameOver   = true;
        }
    }
}
