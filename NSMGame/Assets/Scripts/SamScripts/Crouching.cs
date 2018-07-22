using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouching : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if(Input.GetKeyDown(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - transform.localScale.y*5/2, transform.position.z);
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 2, transform.localScale.z);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - transform.localScale.y * 2 / 5, transform.position.z);
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 2, transform.localScale.z);
        }
		
	}
}
