using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {

    private float blinkDistance;
    private Vector3 startPosition;
    private Vector3 mousePosition;
    private Vector3 targetVector;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UseAbility()
    {
        blinkDistance = 5f;
        mousePosition = Camera.main.ViewportToScreenPoint(Input.mousePosition);
        targetVector = mousePosition - this.transform.position;
        targetVector.z = 0;
        this.transform.position = targetVector.normalized * blinkDistance;
    }

}
