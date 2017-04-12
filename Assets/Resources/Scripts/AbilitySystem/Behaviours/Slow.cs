using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Slow : MonoBehaviour {

    //  Slow Behaviour variables
    private float SlowDuration;
    private float SlowReduction;
    private bool isAlreadySlowed;
    private Stopwatch SlowTimer;

	// Use this for initialization
	void Start () {
        SlowDuration = 3f;  // In Seconds
        SlowReduction = 0.5f;   // How much to reduce obj speed by
        isAlreadySlowed = false;
        SlowTimer = new Stopwatch();
    }
	
	// Update is called once per frame
	void Update () {
        if (isAlreadySlowed == false)
        {
            BossValues.Speed -= SlowReduction;
            isAlreadySlowed = true;
            SlowTimer.Start();
        }
        else
        {
            if(SlowTimer.Elapsed.Seconds >= SlowDuration)
            {
                BossValues.Speed += SlowReduction; // Change speed back to original
                Destroy(this.gameObject.GetComponent<Slow>());  // Remove script once effect has ended.
            }
        }
	}
}
