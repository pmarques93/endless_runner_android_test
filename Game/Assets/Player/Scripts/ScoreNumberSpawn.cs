using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreNumberSpawn : MonoBehaviour
{
    // Inspector stuff
    [SerializeField] SpriteRenderer sprite;

    // Components
    private Rigidbody2D rb;

    // Alpha variable
    private float alpha = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(0f, 1f);

        Destroy(gameObject, 350f * Time.deltaTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (alpha >= 0) alpha -= Time.fixedDeltaTime * 0.5f;


        sprite.color = new Color(255f, 255f, 255f, alpha);
    }
}
