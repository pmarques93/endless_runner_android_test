using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Sounds
    public static AudioClip jump;
    public static AudioClip score;


    private static AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

        jump = Resources.Load<AudioClip>("Sound Assets/Jump");
        score = Resources.Load<AudioClip>("Sound Assets/Score");
    }


    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jump":
                audio.PlayOneShot(jump);
                break;
            case "score":
                audio.PlayOneShot(score);
                break;
        }
    }
}
