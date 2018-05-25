using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        print("Collided! coll: " + coll.gameObject.name);
        if (coll.gameObject.tag == "Bullet")
        {
            Destroy(coll.gameObject); //destroy bullet if it touched colliders on camera's edges
        }
    }
}
