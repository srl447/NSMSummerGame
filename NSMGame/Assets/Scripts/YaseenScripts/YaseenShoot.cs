using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaseenShoot : MonoBehaviour {
    public GameObject bullet;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newBullet = Instantiate(bullet) as GameObject;
            newBullet.transform.position = this.transform.position;
        }
	}
}
