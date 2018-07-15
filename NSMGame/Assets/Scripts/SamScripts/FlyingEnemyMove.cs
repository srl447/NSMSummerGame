using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyMove : MonoBehaviour {

    public float time;
    public Vector3 dir;
	// Use this for initialization
	void Awake ()
    {
        StartCoroutine(SwitchDir());
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        this.GetComponent<Rigidbody2D>().MovePosition(transform.position+dir);
	}

    IEnumerator SwitchDir()
    {
        yield return new WaitForSecondsRealtime(time);
        dir = dir * -1;
        StartCoroutine(SwitchDir());
    }
}
