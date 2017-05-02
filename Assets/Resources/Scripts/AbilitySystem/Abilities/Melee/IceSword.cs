using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSword : MonoBehaviour {

    private float lifeDistance;
    private Vector3 startPosition;
    private Vector3 targetVector;
    private float projectileSpeed;
    private Vector3 mouseLocation;
    private float targetDistance;
    private GameObject icesword;
    private bool casted;

    // Use this for initialization
    void Start()
    {
        icesword = GameObject.Find("icesword_meele");
        // Enable Prefab
        if (!this.gameObject.activeSelf)
            this.gameObject.SetActive(true);

        gameObject.tag = "IceSword";
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
        icesword.gameObject.transform.position = Position;
        icesword.gameObject.GetComponent<Renderer>().enabled = true;
        mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        startPosition = Position;
        targetVector = mouseLocation - this.transform.position;
        targetVector.z = 0;
        projectileSpeed = 2f;
        casted = true;
    }

    void Reset()
    {
        icesword.gameObject.transform.position = new Vector3(-25, 1, 0);
        icesword.gameObject.GetComponent<Renderer>().enabled = false;
        casted = false;
    }

    private void OnCollisionEnter2D(Collision2D hitObject)
    {
        if (hitObject.gameObject.name == "Boss")
        {
            // Ice Sword does damage, and slows on hit
            hitObject.gameObject.AddComponent<Damage>();
            hitObject.gameObject.AddComponent<Slow>();
            Reset();
        }
    }
}
