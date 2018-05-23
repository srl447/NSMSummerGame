using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaseenBulletCollide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Box")
        {
            Destroy(coll.gameObject);
        }
    }
}
