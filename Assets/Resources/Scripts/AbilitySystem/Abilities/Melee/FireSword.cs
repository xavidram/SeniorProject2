using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSword : MonoBehaviour {

    private float lifeDistance;
    private Vector3 startPosition;
    private Vector3 targetVector;
    private float projectileSpeed;
    private Vector3 mouseLocation;
    private float targetDistance;
    private GameObject firesword;
    private bool casted;

    // Use this for initialization
    void Start()
    {
        firesword = GameObject.Find("firesword_meele");
        // Enable Prefab
        if (!this.gameObject.activeSelf)
            this.gameObject.SetActive(true);

        gameObject.tag = "FireSword";
        lifeDistance = 0.5f;
        // Ignore Player Collision
        Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), GameObject.Find("Player").GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        if (casted)
        {
            targetDistance = Vector3.Distance(startPosition, this.transform.position);
            if (targetDistance < lifeDistance)
            {
                targetDistance = Vector3.Distance(startPosition, this.transform.position);
                transform.Translate(targetVector.normalized * projectileSpeed * Time.deltaTime);
            }
            else if (targetDistance > lifeDistance)
            {
                //Destroy(this.gameObject);
                Reset();
            }
        }
    }

    public void UseAbility(Vector3 Position)
    {
        firesword.gameObject.transform.position = Position;
        firesword.gameObject.GetComponent<Renderer>().enabled = true;
        mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        startPosition = Position;
        targetVector = mouseLocation - this.transform.position;
        targetVector.z = 0;
        projectileSpeed = 2f;
        casted = true;
    }

    void Reset()
    {
        firesword.gameObject.transform.position = new Vector3(-24, 1, 0);
        firesword.gameObject.GetComponent<Renderer>().enabled = false;
        casted = false;
    }

    private void OnCollisionEnter2D(Collision2D hitObject)
    {
        if (hitObject.gameObject.name == "Boss")
        {
            PlayerValues.QAbilityHits += 1;
            // Fire Sword does damage, damage over time
            hitObject.gameObject.AddComponent<Damage>();
            hitObject.gameObject.AddComponent<DamageOverTime>();
            Reset();
        }
    }
}
