using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeonMove : MonoBehaviour {
    public float speed = 0.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(new Vector2(-speed, 0));
        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(new Vector2(speed, 0));
        }

    }
    
}

