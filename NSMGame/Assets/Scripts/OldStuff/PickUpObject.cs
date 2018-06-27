using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour {

    public GameManager gM;
    GameObject held;

    public float force;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetMouseButtonDown(0))
        {
            held.GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.mousePosition.x - transform.position.x, Input.mousePosition.y - transform.position.y) * force);
        }
	}

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "stick" && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(other.name);
            gM.item = other.gameObject;
            held = other.gameObject;
            Debug.Log("done");
            other.gameObject.transform.parent = transform;
            other.gameObject.GetComponent<ObjectThrow>().enabled = true;
        }
    }
 }
