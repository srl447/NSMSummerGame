using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {

    public bool isHurt;
    public bool invincible;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet" || collision.gameObject.tag == "Enemy")
        {
            if (!invincible) StartCoroutine("Hurt");
        }


       
    }
    IEnumerator Hurt()
    {
        invincible = true;
        isHurt = true;
        yield return new WaitForEndOfFrame();
        isHurt = false; 

        GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.7f, 0.7f, 0.5f); ;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.9f);

        invincible = false;

    }





}
