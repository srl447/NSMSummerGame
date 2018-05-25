using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    private int frame = 0;

    public GameObject target; // player
    public GameObject bulletPrefab;
    public GameObject bullet;

    private int firedAtFrame = 0;

    private Vector3 direction;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () {

        frame++;
        if (frame % 300 == 0) // fire shots every 5 seconds
        {
            firedAtFrame = frame;
            Instantiate(bulletPrefab, transform.localPosition, transform.rotation); //create bullet
        }
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            bool isReflect = col.gameObject.GetComponent<BulletHandler>().isReflected;
            if (isReflect)
            {
                Destroy(gameObject);
            }
        }
    }

}
