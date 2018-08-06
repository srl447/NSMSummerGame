using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{


    public LayerMask DefaultRaycastLayers;

    public Vector2 raycastStart;
    public Vector3 raycastAdd;
    Rigidbody2D rb;

    public RaycastHit2D jumpCheck;

    float jumpHeight;
    float jumpHeightStart;
    float jumpSpeed;
    public float jumpSpeedUp, jumpSpeedDown; //legnth of the trapezoid, smaller = more trapezoids = slower
    public float jumpGraphLocation; //left edge of trapezoid
    Vector3 jumpPosition;
    bool isJumping;
    public float floatsies;
    void Awake()
    {
        jumpHeightStart = jumpGraphLocation;
    }
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Ground Collision
        if(GetComponent<SpriteRenderer>().flipX == true)
        {
            //Raycast downwards to detect ground
            raycastAdd = new Vector3(-.7f, .7f, 0);
        }
        else
        {
            //on back, so flips on turn around
            raycastAdd = new Vector3(.7f, .7f, 0);
        }
        raycastStart = transform.position - raycastAdd;
        jumpCheck = Physics2D.Raycast(raycastStart, Vector2.down/3, 1f, DefaultRaycastLayers);
        //drawing raycast in the editor
        //Debug.DrawRay(raycastStart, Vector2.down / 3f, Color.green);
        //Debug.Log(jumpCheck.collider.tag);
        //Debug.Log(raycastStart);
        //Debug.Log(rb.velocity.y);

        if (jumpCheck.collider != null)
        {
            rb.gravityScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.W) && jumpCheck.collider.tag == "Floor")
        {
            isJumping = true;
        }
        if (isJumping)
        {
            if (jumpGraphLocation < 0)
            {
                jumpSpeed = jumpSpeedUp;
            }
            else
            {
                jumpSpeed = jumpSpeedDown;
            }
            //Calculate the area under the curve using trapezoidal rule
            jumpHeight = (.5f) * jumpSpeed * (-Mathf.Pow(jumpGraphLocation, 3) + -Mathf.Pow(jumpGraphLocation+jumpSpeed, 3));
            //set the next location to start the trapezoid
            jumpGraphLocation += jumpSpeed;
            //Sets the next position for the player
            jumpPosition = new Vector3(transform.position.x, transform.position.y + jumpHeight, transform.position.z);
            //moves the player
            rb.MovePosition(jumpPosition);
            //Debug.Log(jumpHeight);
        }
        if(jumpCheck.collider.tag == "Floor" && jumpGraphLocation >= 0)
        {
            jumpGraphLocation = jumpHeightStart;
            isJumping = false;
        }

    }
    
}
