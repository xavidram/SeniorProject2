using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour {

    private enum AbilityType : int {
        Projectile = 0,
        Melee = 1
    }

    private enum Behavior : int {
        Damage = 0,
        DamageOverTime = 1,
        Slow = 2,
        Stun = 3
    }

    private GameObject boss;
    private BPSpriteController spriteController;

    private List<int> behaviors;
    private int abilityType;

    private float range;
    private float speed;

    private float distTraveled;
    private bool firing;
    private Vector3 targetVector;
    private float fireTimer;


    void Start() {
        //settle projectile stuff
        boss = GameObject.Find("Boss");
        spriteController = GetComponentInChildren<BPSpriteController>();

        //decide if melee or projectile

        abilityType = (Random.Range(1, 100)) % 2;


        //generate behaviors for projectile
        behaviors = new List<int>();

        behaviors.Add(0);

        /*
        for (int i = 0; i <= 3; i++) {
            if (Random.Range(0, 100) > 50) {
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

        if(abilityType == (int)AbilityType.Projectile) {
            range = 10f;
            speed = 8f;
            print("boss ability is projectile");
        }
        else if(abilityType == (int)AbilityType.Melee) {
            range = 2f;
            speed = 8f;
            print("boss ability is melee");
        }
    }

    void Update() {
        if (firing) {
            if (distTraveled <= range) {
                transform.Translate(targetVector.normalized * speed * Time.deltaTime);
                distTraveled += (targetVector.normalized * speed * Time.deltaTime).magnitude;
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
            spriteController.ShowSprite();
            spriteController.EnableCollision();
            targetVector = targetPos - transform.position;
            targetVector.z = 0;
            distTraveled = 0;
            firing = true;
        }
    }

    public void Reset() {
        spriteController.HideSprite();
        spriteController.DisableCollision();
        firing = false;
        targetVector.Set(0, 0, 0);
        transform.position.Set(0, 0, 0);
    }

    public void Collide(GameObject target) {
        if(target.gameObject.name == "Player")
        {
            foreach (int i in behaviors)
            {
                if (i == (int)Behavior.Damage)
                {
                    target.AddComponent<Damage>();
                }
                else if (i == (int)Behavior.DamageOverTime)
                {
                    target.AddComponent<DamageOverTime>();
                }
                else if (i == (int)Behavior.Slow)
                {
                    target.AddComponent<Slow>();
                }
                else if (i == (int)Behavior.Stun)
                {
                    target.AddComponent<Stun>();
                }
            }
        }
    }
}
