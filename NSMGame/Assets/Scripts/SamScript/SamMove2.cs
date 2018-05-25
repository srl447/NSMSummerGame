using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamMove2 : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate ()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector2(speed, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector2(-speed, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector2(0, speed));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector2(0, -speed));
        }
    }
}
