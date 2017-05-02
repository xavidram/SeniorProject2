using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShard : MonoBehaviour {

    private float lifeDistance;
    private Vector3 startPosition;
    private Vector3 targetVector;
    private float projectileSpeed;
    private Vector3 mouseLocation;
    private float targetDistance;
    private GameObject iceshard;
    private bool casted;

    // Use this for initialization
    void Start()
    {
        iceshard = GameObject.Find("iceshard_projectile");

        // Enable Prefab
        if (!this.gameObject.activeSelf)
            this.gameObject.SetActive(true);

        gameObject.tag = "IceShard";
        lifeDistance = 10f;
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
        iceshard.gameObject.transform.position = Position;
        iceshard.gameObject.GetComponent<Renderer>().enabled = true;
        mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        startPosition = Position;
        targetVector = mouseLocation - this.transform.position;
        targetVector.z = 0;
        projectileSpeed = 2f;
        casted = true;
    }

    void Reset()
    {
        iceshard.gameObject.transform.position = new Vector3(-25, 2, 0);
        iceshard.gameObject.GetComponent<Renderer>().enabled = false;
        casted = false;
    }

    private void OnCollisionEnter2D(Collision2D hitObject)
    {
        if (hitObject.gameObject.name == "Boss")
        {
            PlayerValues.QAbilityHits += 1;
            // IceShard does damage, and Stuns
            hitObject.gameObject.AddComponent<Damage>();
            hitObject.gameObject.AddComponent<Stun>();
            Reset();
        }
    }
}
