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
    public float jumpHeightStart;
    public float jumpSpeed;
    Vector3 jumpPosition;
    bool isJumping;
    public float floatsies;
    void Awake()
    {
        jumpHeight = jumpHeightStart;
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
            jumpPosition = new Vector3(transform.position.x, transform.position.y + -(Mathf.Pow(jumpHeight, 3)), transform.position.z);
            if (jumpHeight < 0)
            {
                jumpHeight += jumpSpeed;
            }
            else
            {
                jumpHeight += jumpSpeed;
            }
            rb.MovePosition(jumpPosition);
        }
        if(jumpCheck.collider.tag == "Floor" && jumpHeight >= 0)
        {
            jumpHeight = jumpHeightStart;
            isJumping = false;
        }

    }
}
