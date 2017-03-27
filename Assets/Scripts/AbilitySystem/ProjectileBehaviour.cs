using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {

    //  Range Ability variables
    private float minDistance;
    private float maxDistance;
    private float lifeDistance;
    private float projectileSpeed;
    private Vector3 mouseLocation;
    private float targetDistance;
    private Vector3 startPosition;
    private Sprite[] Sprites;

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
        minDistance = 5f; maxDistance = 10f;
        lifeDistance = Random.Range(minDistance, maxDistance);
        mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //  Ignore colission with player
        Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), GameObject.Find("Player").GetComponent<Collider2D>());
        startPosition = this.transform.position;
        targetDistance = Vector3.Distance(startPosition, this.transform.position);
        projectileSpeed = 0.5f;   //Speed of projectile
    }
	
	// Update is called once per frame
	void Update () {
        if(targetDistance < lifeDistance)
        {
            targetDistance = Vector3.Distance(startPosition, this.transform.position);
            this.transform.Translate(mouseLocation * projectileSpeed * Time.deltaTime);
        }else
        {
            this.gameObject.SetActive(false);
        }
	}

    private void OnCollisionEnter2D(Collision2D hitObject)
    {
        if (hitObject.gameObject.name == "Boss")
        {
            UnityEngine.Debug.Log("Enemy Hit, Applying Behaviour");
            hitObject.gameObject.AddComponent<DamageOverTime>();  //  Add Slow Behaviour;
            Destroy(gameObject);
        }
    }


}
