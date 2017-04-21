using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUtility : MonoBehaviour {
    /* Chainmail    armor
     * HealthRegen  health regen
     * SpellShield  needs implementation
     * Steroids     speed buff
     * Barrier      terrain block
     * Blink        teleport
    */
    private enum Behavior : int {
        Armor = 0,
        HealthRegen = 1,
        Speed = 2
    }

    private GameObject boss;
    private int utility;

	// Use this for initialization
	void Start () {
        boss = GameObject.Find("Boss");

        utility = Random.Range(1, 100) % 3;

        //debug
        print("boss utility");
        if(utility == 0) {
            print("armor");
        }
        else if(utility == 1) {
            print("healthregen");
        }
        else if(utility == 2) {
            print("speed");
        }
	}
	
	// Update is called once per frame
	void Update () {
		//do animation stuff for buff
	}

    public void Use() {
        if(utility == (int)Behavior.Armor) {
            boss.AddComponent<Chainmail>();
        }
        else if(utility == (int)Behavior.HealthRegen) {
            boss.AddComponent<HealthRegen>();
        }
        else if(utility == (int)Behavior.Speed) {
            boss.AddComponent<Steroids>();
        }
    }
}
