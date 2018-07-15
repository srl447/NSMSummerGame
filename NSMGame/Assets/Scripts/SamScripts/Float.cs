using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour {

    public float floatDuration;
    bool canFloat;
    bool floatStart;

	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.P) && canFloat)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
            GetComponent<Jumping>().enabled = false;
            if (!floatStart)
            {
                StartCoroutine(floatTime(floatDuration));
                floatStart = true;
            }

        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            GetComponent<Jumping>().enabled = true;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            canFloat = true;
        }
    }
    IEnumerator floatTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        canFloat = false;
        floatStart = false;
    }
}
