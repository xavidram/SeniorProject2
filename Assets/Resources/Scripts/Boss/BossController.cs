using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    private enum AIType : int {
        Aggressive = 0,
        Defensive = 1
    }

    private Renderer r;
    private NavMeshAgent2D nmAgent;
    private GameObject Player;

    private BossAbility ability1;
    private BossAbility ability2;
    private BossUtility ability3;

    private int aiType;
    private bool isMelee;

    private float internalCD = 3f;
    private float internalTimer;

    private float a1CD = 6f;
    private float a1Timer;
    private float a2CD = 12f;
    private float a2Timer;
    private float a3CD = 9f;
    private float a3Timer;

    private float strafeTimer;
    private float strafeCD = 2f;
    private float strafeMag;

    private float minRange;

    private int decider;
    private Vector3 destination;

    // Use this for initialization
    void Start() {
        r = gameObject.GetComponent<Renderer>();
        //r.enabled = true;

        nmAgent = gameObject.GetComponent<NavMeshAgent2D>();

        Player = GameObject.FindGameObjectWithTag("Player");

        aiType = Random.Range(0, 2);

        ability1 = GameObject.Find("BossProjectile").GetComponent<BossAbility>();
        ability2 = GameObject.Find("BossProjectile2").GetComponent<BossAbility>();
        ability3 = gameObject.GetComponent<BossUtility>();
        

        minRange = -1;

        internalTimer = 0;
        a1Timer = 0;
        a2Timer = 0;
        a3Timer = 0;
        strafeTimer = 0;

        strafeMag = 0f;



    }

    // Update is called once per frame
    void Update() {
        if(minRange == -1) {
            SetAttributes();
        }

        Vector3 playerPos = Player.transform.position;
        Vector3 distFromPlayer = playerPos - transform.position;
        float playerDist = distFromPlayer.magnitude;

        if(strafeTimer <= 0) {
            strafeMag = Random.Range(-2.0f, 2.0f);
            strafeTimer = strafeCD;
        }

        //aggressive AI
        if(aiType == (int)AIType.Aggressive) {
            //ability control
            if (internalTimer <= 0) {
                int UType = ability3.GetUType();

                if(playerDist < 5.0f || playerDist < minRange) {
                    if (UType == (int)BossUtility.Behavior.Armor) {
                        if (a3Timer <= 0) {
                            ability3.Use();
                            BossValues.EAbilityCasts += 1;
                        }
                    }
                    else if (UType == (int)BossUtility.Behavior.HealthRegen) {
                        if (a3Timer <= 0) {
                            if (BossValues.Health < BossValues.MaxHealth) {
                                ability3.Use();
                                BossValues.EAbilityCasts += 1;
                            }
                        }
                    }
                    else if (UType == (int)BossUtility.Behavior.Speed) {
                        if (a3Timer <= 0) {
                            if (playerDist > ability2.GetRange() || playerDist > ability1.GetRange()) {
                                ability3.Use();
                                BossValues.EAbilityCasts += 1;
                            }
                        }
                    }
                    if (a2Timer <= 0) {
                        if (playerDist < ability2.GetRange()) {
                            ability2.Fire(Player.transform.position);
                            BossValues.WAbilityCasts += 1;
                            a2Timer = a2CD;
                        }
                    }
                    if (a1Timer <= 0) {
                        if (playerDist < ability1.GetRange()) {
                            ability1.Fire(Player.transform.position);
                            BossValues.QAbilityCasts += 1;
                            a1Timer = a1CD;
                        }
                    }
                }

                internalTimer = internalCD;
            }
            else {
                internalTimer -= Time.deltaTime;
            }

            //movement
            //if too far, get close
            if (playerDist > minRange) {
                Move(playerPos);
            }
            else {
                //melee strafe
                if (isMelee) {
                    Vector3 perp = new Vector3(distFromPlayer.y, -distFromPlayer.x, 0);
                    
                    destination = transform.position + (strafeMag * perp.normalized);
                    Move(destination);
                }
                else { //ranged
                       //stay in good range
                    if (playerDist < minRange - 5.0f) {
                        destination = -1 * distFromPlayer;
                        Move(transform.position + destination.normalized);
                    }
                    else { //strafe
                        Vector3 perp = new Vector3(distFromPlayer.y, -distFromPlayer.x, 0);
                        destination = transform.position + (strafeMag * perp.normalized);
                        Move(destination);
                    }
                }
            }
        }
        //defensive AI
        else if(aiType == (int)AIType.Defensive) {
            //ability control
            if (internalTimer <= 0) {
                int UType = ability3.GetUType();

                if (playerDist < minRange) {
                    if (UType == (int)BossUtility.Behavior.Armor) {
                        if (a3Timer <= 0) {
                            ability3.Use();
                            BossValues.EAbilityCasts += 1;
                        }
                    }
                    else if (UType == (int)BossUtility.Behavior.HealthRegen) {
                        if (a3Timer <= 0) {
                            if (BossValues.Health < BossValues.MaxHealth) {
                                ability3.Use();
                                BossValues.EAbilityCasts += 1;
                            }
                        }
                    }
                    else if (UType == (int)BossUtility.Behavior.Speed) {
                        if (a3Timer <= 0) {
                            if (playerDist > ability2.GetRange() || playerDist > ability1.GetRange()) {
                                ability3.Use();
                                BossValues.EAbilityCasts += 1;
                            }
                        }
                    }
                    if (a2Timer <= 0) {
                        if (playerDist < ability2.GetRange()) {
                            ability2.Fire(Player.transform.position);
                            a2Timer = a2CD;
                            BossValues.WAbilityCasts += 1;
                        }
                    }
                    if (a1Timer <= 0) {
                        if (playerDist < ability1.GetRange()) {
                            ability1.Fire(Player.transform.position);
                            a1Timer = a1CD;
                            BossValues.QAbilityCasts += 1;
                        }
                    }
                }

                internalTimer = internalCD;
            }
            else {
                internalTimer -= Time.deltaTime;
            }

            //movement
            //if too far, get close
            if (playerDist > minRange) {
                Vector3 perp = new Vector3(distFromPlayer.y, -distFromPlayer.x, 0);
                destination = playerPos + (strafeMag * perp.normalized);
                Move(destination);
            }
            else {
                //melee strafe
                if (isMelee) {
                    Vector3 perp = new Vector3(distFromPlayer.y, -distFromPlayer.x, 0);
                    destination = transform.position + (strafeMag * perp.normalized);
                    Move(destination);
                }
                else { //ranged
                       //stay in good range
                    if (playerDist < minRange - 5.0f) {
                        destination = -1 * distFromPlayer;
                        Move(transform.position + destination.normalized);
                    }
                    else { //strafe
                        Vector3 perp = new Vector3(distFromPlayer.y, -distFromPlayer.x, 0);
                        destination = transform.position + (strafeMag * perp.normalized);
                        Move(destination);
                    }
                }
            }
        }

        //timers
        if (a1Timer >= -60)
            a1Timer -= Time.deltaTime;
        if (a2Timer >= -60)
            a2Timer -= Time.deltaTime;
        if (a3Timer >= -60)
            a3Timer -= Time.deltaTime;
        strafeTimer -= Time.deltaTime;
    }

    void Move(Vector3 targetPos) {
        nmAgent.destination = targetPos;
        //this.transform.Translate((targetPos - this.transform.position).normalized * BossValues.Speed * Time.deltaTime);
    }

    void SetRange() {
        if(ability1.GetRange() > ability2.GetRange()) {
            minRange = ability2.GetRange();
        }
        else {
            minRange = ability1.GetRange();
        }
    }

    void SetAttributes() {
        SetRange();

        if (ability1.IsMelee() || ability2.IsMelee()) {
            isMelee = true;
        }

        if(isMelee) {
            BossValues.Speed = 2.4f;
        }
        else {
            BossValues.Speed = 1.8f;
        }
        nmAgent.speed = BossValues.Speed;
    }
}
