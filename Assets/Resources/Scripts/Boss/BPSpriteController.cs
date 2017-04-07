using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPSpriteController : MonoBehaviour {

    private Renderer r;
    private BossProjectile bp;

    // Use this for initialization
    void Start () {
        bp = gameObject.GetComponentInParent<BossProjectile>();
        r = GetComponent<Renderer>();
        r.enabled = enabled;
        Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), GameObject.Find("Boss").GetComponent<Collider2D>());
    }
	
	// Update is called once per frame
	void Update () {
		//do
	}

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.name == "Player") {
            print("boss hit player");
            bp.Collide(coll.gameObject);
            bp.Reset();
        }
    }
}
