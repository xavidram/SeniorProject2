using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Stun : MonoBehaviour
{

    //  Stun Behaviour variables
    private float SlowDuration;
    private Stopwatch SlowTimer;

    private float oldSpeed;

    // Use this for initialization
    void Start()
    {
        SlowDuration = 3f;  // In Seconds
        SlowTimer = new Stopwatch();

        oldSpeed = BossValues.Speed;
        BossValues.Speed = 0;
        SlowTimer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (SlowTimer.Elapsed.Seconds >= SlowDuration)
        {
            BossValues.Speed = oldSpeed; // Change speed back to original
            Destroy(this.gameObject.GetComponent<Stun>());  // Remove script once effect has ended.
        }
    }
}
