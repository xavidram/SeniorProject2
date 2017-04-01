using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour {

    private enum Behavior : int {
        Damage = 0,
        DamageOverTime = 1,
        Slow = 2,
        Stun = 3
    }

    private GameObject boss;
    private GameObject spriteController;
    private List<int> behaviors;

    private bool firing;
    private Vector3 targetVector;
    private float fireTimer;


    void Start() {
        //settle projectile stuff
        boss = GameObject.Find("Boss");
        spriteController = GetComponent<GameObject>();

        //generate behaviors for projectile
        behaviors = new List<int>();

        behaviors.Add(0);

        /*
        for (int i = 0; i <= 3; i++) {
            if (Random.Range(1, 100) > 50) {
                behaviors.Add(i);
            }
        }

        if (behaviors.Count == 0) {
            behaviors.Add(Random.Range(0, 3));
        }
        */

        //print out behaviors added ------ for testing purposes
        foreach (int b in behaviors) {
            print("behavior " + b);
        }
    }

    void Update() {
        if (firing) {
            if (fireTimer > 0) {
                fireTimer -= Time.deltaTime;
                transform.Translate(targetVector.normalized * 1 * Time.deltaTime);
            }
            else {
                print("Reset");
                Reset();
            }
        }
    }

    public void Fire(Vector3 targetPos) {
        if (!firing) {
            print("Firing");
            transform.position = boss.transform.position;
            //rend.enabled = true;
            //projCollider.enabled = true;
            targetVector = targetPos - transform.position;
            targetVector.z = 0;
            fireTimer = 10;
            firing = true;
        }
    }

    public void Reset() {
        //rend.enabled = false;
        //projCollider.enabled = false;
        firing = false;
        targetVector.Set(0, 0, 0);
        transform.position.Set(0, 0, 0);
        fireTimer = 0;
    }

    public void Collide(GameObject target) {
        foreach (int i in behaviors) {
            if (i == (int)Behavior.Damage) {
                //do
                target.AddComponent<Damage>();
            }
            else if (i == (int)Behavior.DamageOverTime) {
                //do
            }
            else if (i == (int)Behavior.Slow) {
                //do
            }
            else if (i == (int)Behavior.Stun) {
                //do
            }
        }
    }
}
