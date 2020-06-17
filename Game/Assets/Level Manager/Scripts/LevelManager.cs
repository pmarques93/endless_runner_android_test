using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Inspector stuff
    [SerializeField] private GameObject spawnPlayer;
    [SerializeField] private Transform  spawnPlayerPos;

    // Player
    private Player p1;

    // Gameplay
    public static bool running;
    public static bool gameOver;
    public static float levelTimer;

    // Score
    public static int score;

    private void Awake()
    {
        running = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Finds player
        p1 = FindObjectOfType<Player>();

        // If the game is runninng
        if (running)
        {
            // Updates a level timer
            levelTimer += Time.deltaTime;
            // Spawns player if the player doesn't exist yet
            if (p1 == null) Instantiate(spawnPlayer, spawnPlayerPos.transform.position, spawnPlayer.transform.rotation);
        }
    }
}
