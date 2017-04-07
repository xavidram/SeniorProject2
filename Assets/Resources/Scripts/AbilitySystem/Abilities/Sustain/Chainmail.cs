using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Chainmail : MonoBehaviour {

    private float armorAddon;
    private Stopwatch abilityTimer;
    private float abilityDuration;
	// Use this for initialization
	void Start () {
        armorAddon = 15f;
        abilityDuration = 10f;  //  10 seconds
        abilityTimer = new Stopwatch();
        abilityTimer.Start();
        
        //  Check if this is a player or boss
        if (this.gameObject.name == "Player")
        {
            PlayerValues.Armor += armorAddon;
        }else if(this.gameObject.name == "Boss")
        {
            BossValues.Armor += armorAddon;
        }

    }
	
	// Update is called once per frame
	void Update () {
        if(abilityTimer.Elapsed.Seconds >= abilityDuration)
        {
            if (this.gameObject.name == "Player")
            {
                PlayerValues.Armor -= armorAddon;
            }
            else if (this.gameObject.name == "Boss")
            {
                BossValues.Armor -= armorAddon;
            }
            //  Remove script from object
            abilityTimer.Stop();
            abilityTimer.Reset();
            Destroy(gameObject);
        }
	}
}
