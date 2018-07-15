using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour {

    public int jumpMultiplier = 12;
    public int gravityMultiplier = 5;
    public float gravity = -9.81f;

    Rigidbody2D rb;

     void Awake()
    {
        
    }
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Debug.Log(rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.W) && rb.velocity.y == 0)
        {
            rb.velocity += Vector2.up * jumpMultiplier;
        }
        else if (rb.velocity.y > 3)
        {
            Physics2D.gravity = new Vector2(0, gravity * gravityMultiplier);
        }
        else if (rb.velocity.y < -.5)
        {
            Physics2D.gravity = new Vector2(0, gravity * gravityMultiplier * 2);
        }
        else
        {
            Physics2D.gravity = new Vector2(0, gravity);
        }
	}
}
