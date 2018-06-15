using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		if (Input.GetKey(KeyCode.Space))
        {
            this.GetComponent<RigidBody2D>().AddForce(new Vector2(0, 1));
        }
	}
}
