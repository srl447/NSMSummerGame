using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamMovement : MonoBehaviour
{

    public float speed;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(new Vector2(speed, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(new Vector2(-speed, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(new Vector2(0, speed));
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(new Vector2(0, -speed));
        }
    }

    void onCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Box")
        {
            coll.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }
}
