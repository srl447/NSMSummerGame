using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
        Physics2D.IgnoreLayerCollision(8, 13);
    }
}
