using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Editor Fields
    [SerializeField] GameObject groundPosition;
    [SerializeField] LayerMask  groundLayer;

    // Rb Stuff
    Vector2 currentVelocity;

    // Jump
    private bool onGround       = false;
    private bool jumped         = false;
    [SerializeField] float jumpSpeed;
    [SerializeField] float jumpMaxTime;
    private float jumpTimeCounter;

    // Components
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // Jump timer
        jumpTimeCounter = jumpMaxTime;
    }

    private void Update()
    {
        currentVelocity = rb.velocity;

        Grounded();
        Jump();

        rb.velocity = currentVelocity;
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

            if (touch.phase == TouchPhase.Began && onGround)
            {
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


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundPosition.transform.position, 0.2f);
    }
}
