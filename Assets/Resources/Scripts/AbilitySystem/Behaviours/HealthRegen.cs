using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegen : MonoBehaviour {

	private float HealthGain = 10f;	//	Amount of health that will be returned

	// Use this for initialization
	void Start () {
		if(this.gameObject.tag == "Player"){
			if((PlayerValues.Health + HealthGain) > PlayerValues.MaxHealth)
				PlayerValues.Health = PlayerValues.MaxHealth;
			else
				PlayerValues.Health += HealthGain;
		}else if(this.gameObject.tag == "Boss"){
			if((BossValues.Health + HealthGain) > BossValues.MaxHealth)
				BossValues.Health = BossValues.MaxHealth;
			else
				BossValues.Health += BossValues.HealthGain;
		}
		Destroy(this);	// Remove script
	}
}
