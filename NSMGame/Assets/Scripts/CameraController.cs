using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public NewPlayerMovement player;
    private float distance;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<NewPlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        distance = player.transform.position.x - transform.position.x;
        Debug.Log(distance);
        Debug.Log(Mathf.Abs(distance));
        if (player.transform.position.x >= transform.position.x - 2.5f)
        {
            //transform.position = new Vector3();
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x + 2.5f, transform.position.y, transform.position.z), Time.deltaTime * 10f);
        }
        if (player.transform.position.x <= transform.position.x - 4f)
        {
            //transform.position = new Vector3(player.transform.position.x + 4f, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x + 4f, transform.position.y, transform.position.z), Time.deltaTime * 10f);
        }
        if (player.transform.position.y <= transform.position.y - 4f)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, player.transform.position.y - 2f, transform.position.z), Time.deltaTime * 10f);
        }
        if (player.transform.position.y >= transform.position.y + 4f)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, player.transform.position.y + 2f, transform.position.z), Time.deltaTime * 10f);
        }

        //Debug.Log(player.transform.position.x);
        //Debug.Log(transform.position.x);

    }
}
