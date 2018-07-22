using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{

    public int jumpMultiplier = 12;
    public int gravityMultiplier = 5;
    public float gravity = -9.81f;

    public LayerMask DefaultRaycastLayers;

    public Vector2 raycastStart;
    public Vector3 raycastAdd;
    Rigidbody2D rb;

    public RaycastHit2D jumpCheck;

    void Awake()
    {

    }
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GetComponent<SpriteRenderer>().flipX == true)
        {
            raycastAdd = new Vector3(-1, 1, 0);
        }
        else
        {
            raycastAdd = new Vector3(1, 1, 0);
        }
        raycastStart = transform.position - raycastAdd;
        jumpCheck = Physics2D.Raycast(raycastStart, Vector2.down, 2f, DefaultRaycastLayers);
        Debug.DrawRay(raycastStart, Vector2.down * 2f, Color.green);
        Debug.Log(jumpCheck.collider.tag);
        Debug.Log(raycastStart);
        //Debug.Log(rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.W) && jumpCheck.collider.tag == "Floor")
        {
            rb.velocity += Vector2.up * jumpMultiplier;
        }
        else if (rb.velocity.y > 6)
        {
            //Physics2D.gravity = new Vector2(0, gravity * gravityMultiplier);
            rb.gravityScale = gravityMultiplier;
        }
        else if (rb.velocity.y < -1)
        {
            //Physics2D.gravity = new Vector2(0, gravity * gravityMultiplier * 2);
            rb.gravityScale = gravityMultiplier * 2;
        }
        else
        {
            //Physics2D.gravity = new Vector2(0, gravity);
            rb.gravityScale = 1;
        }
    }
}
