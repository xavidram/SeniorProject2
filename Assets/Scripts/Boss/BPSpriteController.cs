﻿using System.Collections;
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
    }
	
	// Update is called once per frame
	void Update () {
		//do
	}

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.name == "Player") {
            print("boss hit player");
            bp.Collide(coll.gameObject);
        }
    }
}
