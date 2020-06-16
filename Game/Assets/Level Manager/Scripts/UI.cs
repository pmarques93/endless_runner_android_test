using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + LevelManager.score;
    }
}
