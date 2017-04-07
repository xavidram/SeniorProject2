using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Vector3 targetPosition;
    private Animator Anim;

	// Use this for initialization
	void Start () {
        Anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0;
        }

        //  Check if player is walking.
        if (transform.position != Vector3.zero)
        {
            Anim.SetBool("isWalking", true);
            Anim.SetFloat("Input_X", transform.position.x);
            Anim.SetFloat("Input_Y", transform.position.y);
        }
        else
            Anim.SetBool("isWalking", false);
        
        //  Move
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * PlayerValues.Speed);
	}
}
