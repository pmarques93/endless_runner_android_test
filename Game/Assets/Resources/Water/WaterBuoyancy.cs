using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBuoyancy : MonoBehaviour
{

    // 0.6 0.95

    // Inspector stuff
    [SerializeField] BuoyancyEffector2D effector;

    // Density
    private bool goingUp;

    private void Start()
    {
        goingUp = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (goingUp)
        {
            effector.density += 0.5f * Time.fixedDeltaTime;
            if (effector.density >= 0.95) goingUp = false;
        }

        if (goingUp == false)
        {
            effector.density -= 0.5f * Time.fixedDeltaTime;
            if (effector.density <= 0.60) goingUp = true;
        }
    }
}
