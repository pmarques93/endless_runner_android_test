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

    private void Awake()
    {
        running = false;
    }

    private void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        // Finds player
        p1 = FindObjectOfType<Player>();

        // If the game is runninng
        if (running)
        {
            // Spawns player if the player doesn't exist yet
            if (p1 == null) Instantiate(spawnPlayer, spawnPlayerPos.transform.position, spawnPlayer.transform.rotation);
            Time.timeScale = 1f;
        }

        // If the game isn't running
        else if (running == false)
        {
            Time.timeScale = 0f;
        }
    }
}
