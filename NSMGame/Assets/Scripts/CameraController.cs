using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public NewPlayerMovement player;
    private float distance;
    public float interpVelocity;
    public Vector3 offset;
    public Vector3 leftOffset;
    Vector3 targetPos;
    public float followSharpness = 0.1f;
    bool directionLeft = false;

    // Use this for initialization
    void Start()
    {
        targetPos = transform.position;
        player = FindObjectOfType<NewPlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {   // Compute our exponential smoothing factor.
    	// lerp is an exponential moving average. So if we want to correct it for deltaTime, a linear adjustment won't do. We need an exponential adjustment.
    	float blend = 1f - Mathf.Pow(1f - followSharpness, Time.deltaTime * 60f);
       	
       	distance = transform.position.x - player.transform.position.x;
       	Debug.Log(distance);
       	Debug.Log(player.directionLeft);

       	if(distance <= offset.x && !player.directionLeft)
       	{
       		transform.position = new Vector3(player.transform.position.x + offset.x, transform.position.y, transform.position.z);
       	}
       	if(distance >= leftOffset.x && player.directionLeft)
       	{
       		transform.position = new Vector3(player.transform.position.x + leftOffset.x, transform.position.y, transform.position.z);
       	}
    }

    
}
