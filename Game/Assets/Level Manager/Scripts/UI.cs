using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;

    [SerializeField] TextMeshProUGUI highScore;


    private void Awake()
    {
        PlayerPrefs.GetInt("Highscore");
    }

    void Update()
    {
        score.text = "Score: " + LevelManager.score;

        highScore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
    }


    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("Highscore");
    }
}
