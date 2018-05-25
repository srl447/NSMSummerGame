using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHide : MonoBehaviour
{
    public PlayerMovement pM;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(pM.isDashing == true)
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = Color.blue;
        }
		
	}
}
