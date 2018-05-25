using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRotation : MonoBehaviour
{

    public Transform target;

    public string lastDirection = "up";

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Key Inputs
        bool right = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);

        bool left = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);

        bool up = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);

        bool down = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);

        //assign rotation values


        if (right)
        {
            transform.position = new Vector3(target.position.x + 1.2f, target.position.y, target.position.z);
            transform.rotation = Quaternion.Euler(0, 0, 270);
            lastDirection = "right";
        }

        if (left)
        {
            transform.position = new Vector3(target.position.x - 1.2f, target.position.y, target.position.z);
            transform.rotation = Quaternion.Euler(0, 0, 90);
            lastDirection = "left";
        }

        if (up)
        {
            transform.position = new Vector3(target.position.x, target.position.y + 1.1f, target.position.z);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            lastDirection = "up";
        }

        if (down)
        {
            transform.position = new Vector3(target.position.x, target.position.y - 1.1f, target.position.z);
            transform.rotation = Quaternion.Euler(0, 0, 180);
            lastDirection = "down";
        }
        //diagonal directions
        if (up && left)
        {
            transform.position = new Vector3(target.position.x - .9f, target.position.y + .9f, target.position.z);
            transform.rotation = Quaternion.Euler(0, 0, 45);
            lastDirection = "upleft";
        }
        if (down && left)
        {
            transform.position = new Vector3(target.position.x - .9f, target.position.y - .9f, target.position.z);
            transform.rotation = Quaternion.Euler(0, 0, 135);
            lastDirection = "downleft";
        }
        if (up && right)
        {
            transform.position = new Vector3(target.position.x + .9f, target.position.y + .9f, target.position.z);
            transform.rotation = Quaternion.Euler(0, 0, 315);
            lastDirection = "upright";
        }
        if (down && right)
        {
            transform.position = new Vector3(target.position.x + .9f, target.position.y - .9f, target.position.z);
            transform.rotation = Quaternion.Euler(0, 0, 225);
            lastDirection = "downright";
        }


        //last stored direction check to reposition shield when idle and shield gets moved
        if (!up && !down && !left && !right)
        {
            if (lastDirection == "right")
            {
                transform.position = new Vector3(target.position.x + 1.2f, target.position.y, target.position.z);
                transform.rotation = Quaternion.Euler(0, 0, 270);
            }
            if (lastDirection == "left")
            {
                transform.position = new Vector3(target.position.x - 1.2f, target.position.y, target.position.z);
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            if (lastDirection == "up")
            {
                transform.position = new Vector3(target.position.x, target.position.y + 1.1f, target.position.z);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (lastDirection == "down")
            {
                transform.position = new Vector3(target.position.x, target.position.y - 1.1f, target.position.z);
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            if (lastDirection == "upleft")
            {
                transform.position = new Vector3(target.position.x - .9f, target.position.y + .9f, target.position.z);
                transform.rotation = Quaternion.Euler(0, 0, 45);
            }
            if (lastDirection == "downleft")
            {
                transform.position = new Vector3(target.position.x - .9f, target.position.y - .9f, target.position.z);
                transform.rotation = Quaternion.Euler(0, 0, 135);
            }
            if (lastDirection == "upright")
            {
                transform.position = new Vector3(target.position.x + .9f, target.position.y + .9f, target.position.z);
                transform.rotation = Quaternion.Euler(0, 0, 315);
            }
            if (lastDirection == "downright")
            {
                transform.position = new Vector3(target.position.x + .9f, target.position.y - .9f, target.position.z);
                transform.rotation = Quaternion.Euler(0, 0, 225);
            }
        }

    }
}
