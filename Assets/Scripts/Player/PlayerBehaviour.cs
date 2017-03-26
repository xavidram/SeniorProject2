using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    private float DMG;
    private Stopwatch Timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeBasicDamage(float Dmg)
    {
        //  Check for armor, subtract armor from damage, then apply the rest
        DMG = Dmg - PlayerValues.Armor;
        if(DMG < 0)
        {
            // No damage take, armor soaked it up
        }else
        {
            PlayerValues.Health -= DMG;
        }
    }

    public void Slow(float Time)
    {

    }

    
}
