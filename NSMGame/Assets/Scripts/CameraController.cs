using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public NewPlayerMovement player;
    private float distance;
    public float interpVelocity;
    public Vector3 offset;
    Vector3 targetPos;

    // Use this for initialization
    void Start()
    {
        targetPos = transform.position;
        player = FindObjectOfType<NewPlayerMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, transform.position.z), Time.deltaTime * 10f);


        /*distance = player.transform.position.x - transform.position.x;
        Debug.Log(distance);
        Debug.Log(Mathf.Abs(distance));
        if (player.transform.position.x >= transform.position.x - 2.5f)
        {
            //transform.position = new Vector3();
            Debug.Log("camera too left, lerping right");
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x + 2.5f, transform.position.y, transform.position.z), Time.deltaTime * 10f);
        }
        if (player.transform.position.x <= transform.position.x - 4f)
        {
            //transform.position = new Vector3(player.transform.position.x + 4f, transform.position.y, transform.position.z);
            Debug.Log("camera too right, lerping left");
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x + 4f, transform.position.y, transform.position.z), Time.deltaTime * 10f);
        }
        if (player.transform.position.y <= transform.position.y - 4f)
        {
            Debug.Log("camera too high, lerping down");
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, player.transform.position.y - 4f, transform.position.z), Time.deltaTime * 10f);
        }
        if (player.transform.position.y >= transform.position.y + 4f)
        {
            Debug.Log("camera too low, lerping up");
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, player.transform.position.y + 4f, transform.position.z), Time.deltaTime * 10f);
        }

        //Debug.Log(player.transform.position.x);
        //Debug.Log(transform.position.x);
        */
    }
}
