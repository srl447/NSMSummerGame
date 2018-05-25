using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D rb;
    public CircleCollider2D hitbox;

    public float moveVel;

    public float dashVel;
    private float dashTimer;

    private bool rightDash;
    private bool leftDash;
    private bool upDash;
    private bool downDash; 

    Vector2 vel;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {

        //Key Inputs
        bool right = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);

        bool left = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);

        bool up = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);

        bool down = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);

        //assign movement values from inputs 
        if (right) {
            vel.x = moveVel;
        }

        if (left) {
            vel.x = -moveVel;
        }

        if (up){
            vel.y = moveVel;
        }

        if (down)
        {
            vel.y = -moveVel;
        }

        //if horizontal buttons not pressed, then set the X vel to 0
        if (!right && !left){
            vel.x = 0; 
        }

        //if vertical buttons not pressed, then set the Y vel to 0 
        if (!up && !down){
            vel.y = 0; 
        }

        //Dash code 

        bool dash = Input.GetKey(KeyCode.Space);

        if (!rightDash)
        {
            if (right && dash)
            {
                rightDash = true;
                StartCoroutine(dashing());
            }
        }

        if (!leftDash)
        {
            if (left && dash)
            {
                leftDash = true;
                StartCoroutine(dashing());
            }
        }

        if (!upDash)
        {
            if (up && dash)
            {
                upDash = true;
                StartCoroutine(dashing());
            }
        }

        if (!downDash)
        {
            if (down && dash)
            {
                downDash = true;
                StartCoroutine(dashing());
            }
        }

        //Moves the player after the inputs have been taken into account
        rb.MovePosition((Vector2)transform.position + vel * Time.deltaTime);
	}

    IEnumerator dashing(){

        if (rightDash){
            for (int i = 0; i < 60; i++)
            {
                yield return new WaitForFixedUpdate();
                vel.x = dashVel;
            }
            rightDash = false; 
        }

        if (leftDash)
        {
            for (int i = 0; i < 60; i++)
            {
                yield return new WaitForFixedUpdate();
                vel.x = -dashVel;
            }
            leftDash = false;
        }

        if (upDash)
        {
            for (int i = 0; i < 60; i++)
            {
                yield return new WaitForFixedUpdate();
                vel.y = dashVel;
            }
            upDash = false;
        }

        if (downDash)
        {
            for (int i = 0; i < 60; i++)
            {
                yield return new WaitForFixedUpdate();
                vel.y = -dashVel;
            }
            downDash = false;
        }
    }

}
