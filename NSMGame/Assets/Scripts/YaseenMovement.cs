using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaseenMovement : MonoBehaviour
{
    public float speed = 0.5f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      //  gameObject.transform.Translate(new Vector2(1, 0));

    }
    void FixedUpdate()
    {
    if (Input.GetKey(KeyCode.D)){
            gameObject.transform.Translate(new Vector2(speed, 0));
        }
    if (Input.GetKey(KeyCode.A)) { 
            gameObject.transform.Translate(new Vector2(-(speed), 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(new Vector2(0, -(speed)));
        }
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(new Vector2(0, speed));
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
    if (coll.gameObject.tag == "Box")
        {
            coll.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }
}

