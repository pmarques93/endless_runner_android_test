using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameplayMenu : MonoBehaviour
{
    // Inspector stuff
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject restartMenu;

    private void Awake()
    {
        restartMenu.SetActive(false);
    }

    private void Update()
    {
        if (LevelManager.gameOver)
            restartMenu.SetActive(true);

    }

    public void Play()
    {
        playButton.SetActive(false);
        LevelManager.running = true;
    }

    public void Restart()
    {
        LevelManager.score      = 0;
        LevelManager.levelTimer = 0;
        SceneManager.LoadScene(0);
    }

}
