using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    private Renderer r;
    private GameObject Player;

    // Use this for initialization
    void Start() {
        r = GetComponent<Renderer>();
        r.enabled = true;
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        if (r.enabled) {
            if (BossValues.Health <= 0)
                r.enabled = false;
            else
                transform.Translate(Player.transform.position.normalized * BossValues.Speed * Time.deltaTime);
        }
    }
}
