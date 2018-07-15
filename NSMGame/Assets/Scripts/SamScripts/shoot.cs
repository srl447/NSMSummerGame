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

        if(Input.GetKeyDown(KeyCode.O))
        {
            GameObject newBullet = Instantiate(bullet) as GameObject;
            if (this.GetComponent<SpriteRenderer>().flipX == false)
            {
                newBullet.GetComponent<BulletMove>().flipped = false;
                newBullet.transform.position = transform.position + new Vector3(bulletDistance, 0);
            }
            else if (this.GetComponent<SpriteRenderer>().flipX == true)
            {
                newBullet.GetComponent<BulletMove>().flipped = true;
                newBullet.transform.position = transform.position + new Vector3(-bulletDistance, 0);
            }
        }
		
	}
}
