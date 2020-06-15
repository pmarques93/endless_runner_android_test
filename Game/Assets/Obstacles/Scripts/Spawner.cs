using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Editor fields
    [SerializeField] private GameObject obstacle;

    // Screen
    private Vector2 screen;

    // Spawn variable
    private bool canSpawn;

    void Start()
    {
        // Gets screen size
        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // Can spawn an object
        canSpawn = true;
    }

    private void Update()
    {
        // spawning an obstacle
        if (LevelManager.running && canSpawn) ObstacleSpawn();
    }

    public void ObstacleSpawn()
    {
        GameObject spawn = Instantiate(obstacle) as GameObject;  // instantiates
        spawn.transform.position = new Vector2(screen.x + 3f, Random.Range(-4.793f, -1.09f)); // with this position
        canSpawn = false;  // Can't spawn more objects
    }
}
