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

    // Use this for initialization
    void Start() {

        //  Load all sprites from Projectile sprites folder
        Sprites = Resources.LoadAll<Sprite>("Sprites/ProjectileSprites");
        //  Select one sprite.
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[0];

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
            hitObject.gameObject.AddComponent<DamageOverTime>();  //  Add Slow Behaviour;
        }
    }


}
