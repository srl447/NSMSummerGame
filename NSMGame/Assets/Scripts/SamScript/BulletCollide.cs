using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void onCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("works");
        if (coll.gameObject.tag == "Box")
        {
            Destroy(coll.gameObject);
        }
    }
}
