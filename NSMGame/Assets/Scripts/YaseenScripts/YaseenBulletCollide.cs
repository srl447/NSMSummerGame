using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaseenBulletCollide : MonoBehaviour {

    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (transform.position.x >= player.transform.position.x + 20)
        {
            Destroy(gameObject);
            //Debug.Log("works");
        }
	}
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Box")
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }
}
