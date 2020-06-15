using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Inspector stuff
    [SerializeField] private GameObject obstacle;
    private Rigidbody2D rb;
    
    // Screen
    private Vector2 screen;

    // Score
    [HideInInspector] public bool scored;

    // Movement
    [HideInInspector] public float speed;
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;

    void Awake()
    {
        // Gets rigidbody and spawner
        rb = GetComponent<Rigidbody2D>();

        // Randomizes a speed
        speed = Random.Range(minSpeed, maxSpeed);

        // Sets spawner velocity ro rb
        rb.velocity = new Vector2(-speed, 0f);

        // Gets screen size
        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // Player can score
        scored = false;
    }

    // Update is called once per frame
    void Update()
    {
        // when it reaches minimum position, creates the next object and destroys itself
        if (transform.position.x < -10.59)
        {
            GameObject next = Instantiate(obstacle) as GameObject;  // instantiates
            next.transform.position = new Vector2(screen.x + 3f, Random.Range(-4.793f, -1.09f)); // with this position
            Destroy(gameObject);
        }
    }
}
