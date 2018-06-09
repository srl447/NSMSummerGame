using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour {

    public GameManager gM;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("stick") && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(other.name);
            gM.pickUp = other.gameObject;
            other.gameObject.transform.parent = transform;
            other.gameObject.GetComponent<ObjectThrow>().enabled = true;
        }
    }
 }
