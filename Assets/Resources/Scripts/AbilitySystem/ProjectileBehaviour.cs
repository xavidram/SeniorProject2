using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {

    //  Range Ability variables
    private float lifeDistance;
    private float projectileSpeed;
    private Vector3 mouseLocation;
    private Vector3 targetVector;
    private Vector3 startPosition;
    private Sprite[] Sprites;
    private float targetDistance;
    private List<int> behaviors;
    private int abilityNum;

    private enum Behavior : int {
        Damage = 0,
        DamageOverTime = 1,
        Slow = 2,
        Stun = 3
    }

    // Use this for initialization
    void Start() {

        //  Load all sprites from Projectile sprites folder
        Sprites = Resources.LoadAll<Sprite>("Sprites/ProjectileSprites");
        //  Select one sprite.
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[0];

        behaviors = new List<int>();
        // Add random behaviors
        for (int i = 0; i <= System.Enum.GetValues(typeof(Behavior)).Length; i++){
            if (Random.Range(0,100) > 50) {
                behaviors.Add(i);
            }
        }

        // Ensure at least one behavior
        if (behaviors.Count == 0){
            behaviors.Add(Random.Range(0,System.Enum.GetValues(typeof(Behavior)).Length));
        }

        //  enable prefab
        if (!this.gameObject.activeSelf)
            this.gameObject.SetActive(true);
        gameObject.tag = "Projectile";
        lifeDistance = 10f;
        mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //  Ignore colission with player
        Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), GameObject.Find("Player").GetComponent<Collider2D>());
        startPosition = this.transform.position;
        targetVector = mouseLocation - this.transform.position;
        targetVector.z = 0;
        projectileSpeed = 2f;   //Speed of projectile
    }
	
	// Update is called once per frame
	void Update () {
        targetDistance = Vector3.Distance(startPosition, this.transform.position);
        if(targetDistance < lifeDistance)
        {
            targetDistance = Vector3.Distance(startPosition, this.transform.position);
            transform.Translate(targetVector.normalized * projectileSpeed * Time.deltaTime);
        }else if(targetDistance > lifeDistance)
        {
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
	}

    private void OnCollisionEnter2D(Collision2D hitObject)
    {
        if (hitObject.gameObject.name == "Boss")
        {
            UnityEngine.Debug.Log("Enemy Hit, Applying Behaviour");
            foreach (int i in behaviors) {
                if (i == (int)Behavior.Damage) {
                    hitObject.gameObject.AddComponent<Damage>();
                }
                else if (i == (int)Behavior.DamageOverTime) {
                    hitObject.gameObject.AddComponent<DamageOverTime>();
                }
                else if (i == (int)Behavior.Slow) {
                    hitObject.gameObject.AddComponent<Slow>();
                }
                else if (i == (int)Behavior.Stun) {
                    hitObject.gameObject.AddComponent<Stun>();
                }
            }
            Destroy(this.gameObject);
        }
    }


}
