using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenApple : MonoBehaviour {

    private float healthAddon;

	// Use this for initialization
	void Start () {
        healthAddon = 20f;  // Health to be recovered

        if(this.gameObject.name == "Player")
            PlayerValues.Health += ((PlayerValues.Health + healthAddon) > PlayerValues.MaxHealth) ? 100 : healthAddon;
        else if(this.gameObject.name == "Boss")
            BossValues.Health += ((BossValues.Health + healthAddon) > BossValues.MaxHealth) ? 100 : healthAddon;

        //  Remove the script
        Destroy(gameObject);
	}

}
