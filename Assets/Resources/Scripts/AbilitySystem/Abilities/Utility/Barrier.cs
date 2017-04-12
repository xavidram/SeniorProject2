using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Barrier : MonoBehaviour {

    private Stopwatch abilityTimer;
    private float abilityDuration;
    private GameObject Rock;

	// Use this for initialization
	void Start () {
        Rock = GameObject.FindWithTag("Rock");
        abilityTimer = new Stopwatch();
        abilityDuration = 5f;
    }
	
	// Update is called once per frame
	void Update () {
        if (abilityTimer.Elapsed.Seconds >= abilityDuration)
        {
            //restart it
            Reset();
        }
    }

    public void UseAbility(Vector3 Position)
    {
        abilityTimer.Start();
        Rock.gameObject.transform.position = Position;
        Rock.gameObject.GetComponent<Renderer>().enabled = true;
        // If to seconds elapsed, turn on collision
    }

    void Reset()
    {
        Rock.gameObject.transform.position = new Vector3(-25, 0, 0);
        Rock.gameObject.GetComponent<Renderer>().enabled = false;
        abilityTimer.Stop();
        abilityTimer.Reset();
    }
   
}
