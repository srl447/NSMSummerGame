using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    private int frame = 0;

    public GameObject target; // player

    public GameObject bullet;

    public bool firing = false;
    private int firedAtFrame = 0;

    private Vector3 direction;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () {
        frame++;

       if (frame % 300 == 0 && !firing) // fire shots every 5 seconds
        {
            firing = true;
            firedAtFrame = frame;
            bullet = Instantiate(GameObject.Find("Bullet"), transform.localPosition, transform.rotation); //create bullet
            direction = (target.transform.position - transform.position).normalized; // find a path toward the player's position
        }
       if (firing && bullet != null) {
            
            bullet.transform.position += direction * 5 * Time.deltaTime; //move bullet toward the player's position
        }
        if (frame == firedAtFrame + 300 || bullet == null)
        {
            firing = false; //make the bullet stop moving after it's destroyed or leaves the screen
        }
        
    }
}
