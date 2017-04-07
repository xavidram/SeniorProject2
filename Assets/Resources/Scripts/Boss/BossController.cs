using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    private Renderer r;
    private GameObject Player;

    private BossAbility ability1;
    private float a1Cooldown = 5;
    private float a1Timer;

    // Use this for initialization
    void Start() {
        r = GetComponent<Renderer>();
        r.enabled = true;
        Player = GameObject.FindWithTag("Player");

        ability1 = GameObject.Find("BossProjectile").GetComponent<BossAbility>();
    }

    // Update is called once per frame
    void Update() {
        if (r.enabled) {
            if (BossValues.Health <= 0)
                r.enabled = false;
            else
                transform.Translate((Player.transform.position-transform.position).normalized * BossValues.Speed * Time.deltaTime);

            if (a1Timer <= 0) {
                a1Timer = a1Cooldown;
                ability1.Fire(Player.transform.position);
            }
            else {
                a1Timer -= Time.deltaTime;
            }
        }
    }
}
