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

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "stick" && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(other.name);
            gM.item = other.gameObject;
            Debug.Log("done");
            other.gameObject.transform.parent = transform;
            other.gameObject.GetComponent<ObjectThrow>().enabled = true;
        }
    }
 }
