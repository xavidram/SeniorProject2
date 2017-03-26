using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    private GameObject Projectile;

	// Use this for initialization
	void Start () {
        Projectile = GameObject.Find("Projectile");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CastQAbility();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {

        }
        if (Input.GetKeyDown(KeyCode.E))
        {

        }
        if (Input.GetKeyDown(KeyCode.R))
        {

        }
    }

    public void CastQAbility()
    {
        UnityEngine.Debug.Log("Csting Q Ability");
        UnityEngine.Debug.Log(BossValues.Speed.ToString());
        GameObject Clone = Instantiate<GameObject>(Projectile);
        Clone.transform.position = this.transform.position;
        Clone.SetActive(true);
    }
}
