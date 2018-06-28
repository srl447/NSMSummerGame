using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

    public GameObject bullet;
    public float bulletDistance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newBullet = Instantiate(bullet) as GameObject;
            if (this.GetComponent<SpriteRenderer>().flipX == false)
            {
                newBullet.transform.position = transform.position + new Vector3(bulletDistance, 0);
                bullet.GetComponent<BulletMove>().flipped = false;
            }
            else
            {
                newBullet.transform.position = transform.position + new Vector3(-bulletDistance, 0);
                bullet.GetComponent<BulletMove>().flipped = true;
            }
        }
		
	}
}
