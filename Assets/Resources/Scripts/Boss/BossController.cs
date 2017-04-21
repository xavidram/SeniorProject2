using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    private Renderer r;
    private GameObject Player;

    private BossAbility ability1;
    private BossAbility ability2;
    private BossUtility ability3;

    private float internalCD = 3f;
    private float internalTimer;

    private float a1CD = 6f;
    private float a1Timer;
    private float a2CD = 12f;
    private float a2Timer;
    private float a3CD = 9f;
    private float a3Timer;

    private int decider;
    private Vector3 destination;

    // Use this for initialization
    void Start() {
        r = gameObject.GetComponent<Renderer>();
        //r.enabled = true;

        Player = GameObject.FindGameObjectWithTag("Player");

        ability1 = GameObject.Find("BossProjectile").GetComponent<BossAbility>();
        ability2 = GameObject.Find("BossProjectile2").GetComponent<BossAbility>();
        ability3 = gameObject.GetComponent<BossUtility>();

        internalTimer = 0;
        a1Timer = 0;
        a2Timer = 0;
        a3Timer = 0;
    }

    // Update is called once per frame
    void Update() {

        if (internalTimer <= 0) {
            Vector3 distFromPlayer = Player.transform.position - transform.position;
            float playerDist = distFromPlayer.magnitude;
            int UType = ability3.GetUType();

            if(UType == (int)BossUtility.Behavior.Armor) {
                if (a3Timer <= 0) {
                    ability3.Use();
                }
            }
            else if (UType == (int)BossUtility.Behavior.HealthRegen) {
                if (a3Timer <= 0) {
                    if (BossValues.Health < BossValues.MaxHealth) {
                        ability3.Use();
                    }
                }
            }
            else if (UType == (int)BossUtility.Behavior.Speed) {
                if(a3Timer <= 0) {
                    if(playerDist > ability2.GetRange() || playerDist > ability1.GetRange()) {
                        ability3.Use();
                    }
                }
            }
            if (a2Timer <= 0) {
                if(playerDist < ability2.GetRange()) {
                    ability2.Fire(Player.transform.position);
                    a2Timer = a2CD;
                }
            }
            if (a1Timer <= 0) {
                if (playerDist < ability1.GetRange()) {
                    ability1.Fire(Player.transform.position);
                    a1Timer = a1CD;
                }
            }

            internalTimer = internalCD;
        }
        else {
            internalTimer -= Time.deltaTime;
        }

        destination = Player.transform.position;
        Move(destination);

        if (a1Timer >= -60)
            a1Timer -= Time.deltaTime;
        if (a2Timer >= -60)
            a2Timer -= Time.deltaTime;
        if (a3Timer >= -60)
            a3Timer -= Time.deltaTime;
    }

    void Move(Vector3 targetPos) {
        this.transform.Translate((targetPos - this.transform.position).normalized * BossValues.Speed * Time.deltaTime);
    }
}
