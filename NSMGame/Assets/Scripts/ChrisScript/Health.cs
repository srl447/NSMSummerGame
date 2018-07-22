using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    private Stat health1;

    [SerializeField]
    private Stat health2;

    [SerializeField]
    private Stat health3;

    [SerializeField]
    private Stat health4;

    [SerializeField]
    private Stat regen1;

    [SerializeField]
    private Stat regen2;

    [SerializeField]
    private BarScript shield;

    [SerializeField]
    private BarScript shield2;

    private float hitcount;

    private bool playerHit;

    private bool shieldDelay;

    // Use this for initialization
    private void Awake()
    {
        health1.Initialize();
        health2.Initialize();
        health3.Initialize();
        health4.Initialize();
        regen1.Initialize();
        regen2.Initialize();

    }
    private void Start()
    {
        hitcount = 0;
        shieldDelay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerHit = true;
            shieldDelay = true;
            if (regen1.CurrentVal > 0)
            {
                regen1.CurrentVal -= 100;
            }
            else if (regen2.CurrentVal > 0)
            {
                regen2.CurrentVal -= 100;
            }
            else if (hitcount == 0)
            {

                hitcount = 1;
                health1.CurrentVal -= 100;
            }
            else if (hitcount == 1)
            {
                hitcount = 2;
                health2.CurrentVal -= 100;
            }
            else if (hitcount == 2)
            {
                hitcount = 3;
                health3.CurrentVal -= 100;
            }
            else if (hitcount == 3)
            {
                hitcount = 4;
                health4.CurrentVal -= 100;
            }
        }
        else
        {
            playerHit = false;
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (hitcount == 1)
            {
                hitcount = 0;
                health1.CurrentVal += 100;
            }

            else if (hitcount == 2)
            {
                hitcount = 1;
                health2.CurrentVal += 100;
            }
            else if (hitcount == 3)
            {
                hitcount = 2;
                health3.CurrentVal += 100;
            }
            else if (hitcount == 4)
            {
                hitcount = 3;
                health4.CurrentVal += 100;
            }
        }
        if (playerHit == false && shieldDelay == true)
        {
            StartCoroutine(ShieldRegenerationCooldown());
        }
    }

    IEnumerator ShieldRegenerationCooldown()
    {
        if (regen1.CurrentVal == 0)
        {
            if (shieldDelay == true)
            {
                shieldDelay = false;
                yield return new WaitForSeconds(3);
                if (shieldDelay == false)
                {
                    shield.lerpSpeed = 50;
                    shield2.lerpSpeed = 50;
                    regen1.CurrentVal += 100;
                    regen2.CurrentVal += 100;
                }
            }
            shield.lerpSpeed = 2;
            shield2.lerpSpeed = 2;
        }
    }
}
