using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamEditJustinDash : MonoBehaviour {

    public Rigidbody2D rb;
    public CircleCollider2D hitbox;

    public float moveVel;

    public float dashVel;
    private float dashTimer;

    private bool rightDash;
    private bool leftDash;
    private bool upDash;
    private bool downDash;

    bool dash, isDashing;
    Vector2 vel;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //only run while not dashing
        if(!dash)
        {
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
        }

        //Dash code 

        if (Input.GetKey(KeyCode.Space) && !isDashing)
        {
         dash = true;
         isDashing = true; //just to give dash a cooldown, needs better naming convention
         StartCoroutine(Dashing(vel));
        }

        //Moves the player after the inputs have been taken into account
        rb.MovePosition((Vector2)transform.position + vel * Time.deltaTime);
	}

    //dashes the player in the direction their going
    IEnumerator Dashing(Vector2 dir)
    {
        /*for (float i = dashVel; i > 1; i/2)
        {
            yield return new WaitForFixedUpdate();
            vel = dir*i;
        }

        //set everything back to end the dash
        //dashVel = holdDashVel;/*/
        dash = false;

        yield return new WaitForSeconds(3); //3 seconds cooldown on dash
        isDashing = false;
    }
}