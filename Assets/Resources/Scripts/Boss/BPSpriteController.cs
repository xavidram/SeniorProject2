using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPSpriteController : MonoBehaviour {

    private Renderer r;
    private PolygonCollider2D bpCollider;
    private BossAbility bp;

    // Use this for initialization
    void Start () {
        bp = gameObject.GetComponentInParent<BossAbility>();
        r = GetComponent<Renderer>();
        r.enabled = enabled;
        bpCollider = GetComponent<PolygonCollider2D>();
        bpCollider.enabled = true;
        Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), GameObject.Find("Boss").GetComponent<Collider2D>());
    }
	
	// Update is called once per frame
	void Update () {
		//do
	}

    public void HideSprite() {
        r.enabled = false;
    }

    public void ShowSprite() {
        r.enabled = true;
    }

    public void DisableCollision() {
        bpCollider.enabled = false;
    }

    public void EnableCollision() {
        bpCollider.enabled = true;
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.name == "Player") {
            print("boss hit playe - collisionr");
            bp.Collide(coll.gameObject);
            bp.Reset();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Player") {
            print("boss hit player - trigger");
            bp.Collide(other.gameObject);
            bp.Reset();
        }
    }
}
