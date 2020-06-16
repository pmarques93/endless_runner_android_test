﻿using System.Collections;
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

    // Score
    public static int score;

    private void Awake()
    {
        running = false;
        gameOver = false;
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
        }
    }
}
