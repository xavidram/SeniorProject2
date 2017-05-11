using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAbility : MonoBehaviour {

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
    private int abilityNum;

    private float range;
    private float speed;

    private float distTraveled;
    private bool firing;
    private Vector3 targetVector;
    private float fireTimer;


    void Start() {
        //settle projectile stuff
        boss = GameObject.Find("Boss");
        spriteController = gameObject.GetComponentInChildren<BPSpriteController>();

        if(gameObject.name == "BossProjectile") {
            abilityNum = 1;
        }
        else if (gameObject.name == "BossProjectile2") {
            abilityNum = 2;
        }

        //decide if melee or projectile
        abilityType = (Random.Range(1, 100)) % 2;

        //generate behaviors for projectile
        behaviors = new List<int>();
        
        //add behaviors
        if((Random.Range(0, 100)) < 50) {
            //chance to add damage or dot
            behaviors.Add(Random.Range(0, 100) % 2);
        }
        if ((Random.Range(0, 100)) < 50) {
            //chance to add slow or stun
            behaviors.Add((Random.Range(0, 100) % 2) + 2);
        }

        //ensure at least one behavior
        if (behaviors.Count == 0) {
            behaviors.Add(Random.Range(0, 4));
        }

        //if ability2 and no damage, add damage
        if (abilityNum == 2) {
            if (!(behaviors.Contains(0) || behaviors.Contains(1))) {
                behaviors.Add(0);
            }
        }
        
        if (abilityType == (int)AbilityType.Projectile) {
            range = 10f;
            speed = 6f;
        }
        else if (abilityType == (int)AbilityType.Melee) {
            range = 3f;
            speed = 8f;
        }

        //debug
        print("boss projectile " + abilityNum);
        if(abilityType == 0) {
            print("projectile");
        }
        else if(abilityType == 1) {
            print("melee");
        }
        print("range " + GetRange());
        foreach(int b in behaviors) {
            if(b == (int)Behavior.Damage) {
                print("damage");
            }
            else if(b == (int)Behavior.DamageOverTime) {
                print("dot");
            }
            else if(b == (int)Behavior.Slow) {
                print("slow");
            }
            else if(b == (int)Behavior.Stun) {
                print("stun");
            }
        }
        ListOfBehaviors();
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

    public float GetRange() {
        return range;
    }

    public bool IsMelee() {
        if(abilityType == (int)AbilityType.Melee) {
            return true;
        }
        return false;
    }

    public void Fire(Vector3 targetPos) {
        if (!firing) {
            print("Firing");
            transform.position = boss.transform.position;
            spriteController.ShowSprite();
            spriteController.EnableCollision();
            targetVector = targetPos - transform.position;
            targetVector.z = 0;
            spriteController.Rotate(targetVector);
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
        if(abilityNum == 1)
        {
            BossValues.QAbilityHits += 1;
        }else if (abilityNum == 2)
        {
            BossValues.WAbilityHits += 1;
        }
        foreach (int i in behaviors) {
            if (i == (int)Behavior.Damage) {
                target.AddComponent<Damage>();
            }
            else if (i == (int)Behavior.DamageOverTime) {
                target.AddComponent<DamageOverTime>();
            }
            else if (i == (int)Behavior.Slow) {
                target.AddComponent<Slow>();
            }
            else if (i == (int)Behavior.Stun) {
                target.AddComponent<Stun>();
            }
        }
    }

    public void ListOfBehaviors()
    {
        string behaviorsList = "";
        foreach (int i in behaviors)
        {
            if (i == (int)Behavior.Damage)
            {
                behaviorsList += "Damage ";
            }
            else if (i == (int)Behavior.DamageOverTime)
            {
                behaviorsList += "DamageOverTime ";
            }
            else if (i == (int)Behavior.Slow)
            {
                behaviorsList += "Slow ";
            }
            else if (i == (int)Behavior.Stun)
            {
                behaviorsList += "Stun ";
            }
        }
        if(abilityNum == 1)
        {
            BossValues.QAbilityBehaviors = behaviorsList;
        }else if(abilityNum == 2) {
            BossValues.WAbilityName = behaviorsList;
        }
    }
}
