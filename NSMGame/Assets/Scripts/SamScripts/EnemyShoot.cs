using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    public GameObject player;
    public GameObject bullet;

    public float bulletDistance;
    public float enemyRange;
    public float bulletRate;

    bool canShoot = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if the player's x position is within enemyRange, shoot
        if (canShoot && (transform.position.x > player.transform.position.x) && (transform.position.x < player.transform.position.x + enemyRange) && (transform.position.y > player.transform.position.y - 4) && (transform.position.y < player.transform.position.y + 4))
        {
            GameObject newBullet = Instantiate(bullet) as GameObject;
            newBullet.transform.position = transform.position + new Vector3(bulletDistance, 0);
            canShoot = false;
            StartCoroutine(bulletWait(bulletRate));
        }
		
	}

    IEnumerator bulletWait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canShoot = true;
    }
}
