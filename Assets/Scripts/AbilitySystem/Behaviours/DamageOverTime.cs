using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DamageOverTime : MonoBehaviour {

    //   damage will be dealt every second.

    private float BaseDamage;
    private float DamageTaken;
    private float dotDuration;
    private Stopwatch dotTimer;

	// Use this for initialization
	void Start () {
        BaseDamage = 10f;
        DamageTaken = 0f;
        dotDuration = 4f;   // 4 second, should deal 40 dmg;
        dotTimer = new Stopwatch();
        StartCoroutine(DealDamageOverTime());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //  DOT will be casted through coroutine
    public IEnumerator DealDamageOverTime()
    {
        dotTimer.Start();
        while(dotTimer.Elapsed.Seconds < dotDuration)
        {
            //  Deal damage to player or boss depending on tag of object.
            if (this.gameObject.tag == "Boss")
                BossValues.Health -= BaseDamage;
            else if (this.gameObject.tag == "Player")
                PlayerValues.Health -= BaseDamage;

            yield return new WaitForSeconds(1); // deal every second
        }
        Destroy(GetComponent<DamageOverTime>());    // Remove script after damage dealt
    }
}
