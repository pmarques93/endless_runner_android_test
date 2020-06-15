using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMenu : MonoBehaviour
{
    [SerializeField] private GameObject playButton;

    public void Play()
    {
        playButton.SetActive(false);
        LevelManager.running = true;
    }

}
