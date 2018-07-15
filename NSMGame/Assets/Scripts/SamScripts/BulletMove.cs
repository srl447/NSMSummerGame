using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    public float bulletSpeed;
    public bool flipped;
	// Use this for initialization
	void Start ()
    {
        //bullets have a total life time based on spawn time
        StartCoroutine(Life());
	}
	
	// Update is called once per frame
	void Update () {
        if (flipped)
        {
            transform.position = transform.position + (Vector3.left * Time.deltaTime * bulletSpeed);
        }
        else if (!flipped)
        {
            transform.position = transform.position + (Vector3.right * Time.deltaTime * bulletSpeed);
        }

		
	}
    //Keeps the bullet alive for a certain amount of time, then destroys it
    IEnumerator Life()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //bullets ignore player collision
        if (collision.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
        else
        {
            //bullets also will die on colliding with objects 
            Destroy(gameObject);
        }
    }
}
