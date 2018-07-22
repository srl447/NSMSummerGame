using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    public float speed = 0.1f;
    public float maxspeed = 0.5f;
    public float acceleration = 0.08f;
    public float secondspressed = 0f;
    public float secondspressedleft = 0f;
    public float speedleft = -0.1f;
    public float maxspeedleft = -0.5f;
    public float truespeed = 0f;
    public float truespeedback = 0f;
    public bool directionLeft = false;
    //public float verticalspeed = 0.0f;
    //public float maxfallspeed = -0.2f;
    //public float gravity = 10000.0f;
    //public float initialjumpspeed = 1000.0f;

    public bool onGround;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {

        truespeed = speed + (acceleration * secondspressed);
        truespeedback = -(speed + (acceleration * secondspressedleft));
        /*if (Input.GetKeyDown(KeyCode.W))
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(0, 10);
            //this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100));
            onGround = false;
        }*/

        //gravity
        //if (verticalspeed >= -0.2f && !onGround)
        //{
        //    verticalspeed += -0.01f;
        //}

        //verticalspeed -= 0.001f;
        //gameObject.transform.Translate(new Vector2(0, verticalspeed));
        //Debug.Log(this.gameObject.GetComponent<Rigidbody2D>().velocity.y);

        if (this.GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            this.gameObject.layer = 8;
        }
        else
        {
            this.gameObject.layer = 0;
        }
        if (Input.GetKey(KeyCode.D))
        {
            secondspressed += .166f;
            if (Input.GetKey(KeyCode.A))
            {
                secondspressed = 0;
            }
            if (truespeed < maxspeed)
            {
                gameObject.transform.Translate(new Vector2(speed + (acceleration * secondspressed), 0));
            }
            else
            {
                gameObject.transform.Translate(new Vector2(maxspeed, 0));
            }

        }
        else if (Input.GetKey(KeyCode.A))
        {
            secondspressedleft += .166f;
            if (Input.GetKey(KeyCode.D))
            {
                secondspressedleft = 0;
            }
            if (truespeedback > -(maxspeed))
            {
                gameObject.transform.Translate(new Vector2(-(speed + (acceleration * secondspressedleft)), 0));
            }
            else
            {
                gameObject.transform.Translate(new Vector2(-maxspeed, 0));
            }
        }
        else
        {
            secondspressed = 0;
            secondspressedleft = 0;
        }

    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Platform" && collision.transform.position.y < this.transform.position.y)
    //    {
    //        verticalspeed = 0.0f;
    //        onGround = true;
    //        //collision.GetComponent<NewPlayerMovement>().verticalspeed = 0.0f;
    //        //collision.GetComponent<NewPlayerMovement>().onPlatform = true;
    //    }
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Platform" && collision.transform.position.y < this.transform.position.y)
    //    {
    //        verticalspeed = 0.0f;
    //        onGround = true;
    //        //collision.GetComponent<NewPlayerMovement>().verticalspeed = 0.0f;
    //        //collision.GetComponent<NewPlayerMovement>().onPlatform = true;
    //    }
    //}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "MoveLeftCameraTrigger")
        {
            directionLeft = true;
            Debug.Log("LEFT");
        }
        if (col.gameObject.name == "MoveRightCameraTrigger")
        {
            directionLeft = false;
        }
    }
}
