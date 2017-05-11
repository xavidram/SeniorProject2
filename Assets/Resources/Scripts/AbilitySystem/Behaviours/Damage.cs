using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    private float BaseDamage;
    private float DamageTaken;

	// Use this for initialization
	void Start () {
        BaseDamage = 20f;
        DamageTaken = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	    if(this.gameObject.name == "Boss")
        {
            
            DamageTaken = Mathf.Abs(BossValues.Armor - BaseDamage);
            if(DamageTaken > 0)
            {
                UnityEngine.Debug.Log("This is a Boss");
                //  Armor did not soke up all damage, deal it
                BossValues.Health -= DamageTaken;
                BossValues.DamageTaken += BaseDamage;
                PlayerValues.DamageDealt += BaseDamage;
            }
        }else if (this.gameObject.name == "Player")
        {
            UnityEngine.Debug.Log("This is a Player");
            DamageTaken = Mathf.Abs(PlayerValues.Armor - BaseDamage);
            if(DamageTaken > 0)
            {
                PlayerValues.Health -= DamageTaken;
                PlayerValues.DamageTaken += BaseDamage;
                BossValues.DamageDealt += BaseDamage;
            }
        }
        Destroy(this);
	}

}
