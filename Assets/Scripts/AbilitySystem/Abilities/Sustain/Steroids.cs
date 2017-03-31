using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Steroids : MonoBehaviour {

    // This will boost the movement speed
    private float movementBuff;
    private float abilityDuration;
    private Stopwatch abilityTimer;

	// Use this for initialization
	void Start () {
        movementBuff = 1.5f;
        abilityDuration = 5f;   // 5 sec
        abilityTimer.Start();

        if(this.gameObject.name == "Player")
        {
            PlayerValues.Speed += movementBuff;
        } else if (this.gameObject.name == "Boss")
        {
            BossValues.Speed += movementBuff;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(abilityTimer.Elapsed.Seconds >= abilityDuration)
        {
            if (this.gameObject.name == "Player")
            {
                PlayerValues.Speed -= movementBuff;
            }
            else if (this.gameObject.name == "Boss")
            {
                BossValues.Speed -= movementBuff;
            }
            abilityTimer.Stop();
            abilityTimer.Reset();
            Destroy(gameObject);
        }
	}
}
