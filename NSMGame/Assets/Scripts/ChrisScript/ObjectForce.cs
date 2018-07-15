using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectForce : MonoBehaviour {

    public ObjectThrow ot;

    public Vector3[] takenArcArray;

    public bool applying;

    public bool started;

    public bool commence;

    public float time;

    public Vector2 tester;

    Vector2 force = new Vector2(0, 0);

    Rigidbody2D rb2D = new Rigidbody2D();

	// Use this for initialization
	void Awake ()
    {
        rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        time = Time.deltaTime;
        commence = ot.start;
        if (commence)
        {
            started = true;
        }

        applying = ot.appliedForce;
        if (applying && started)
        {
            force = GetForceVector();
            tester = force;
            rb2D.AddForce(force, ForceMode2D.Impulse);
            started = false;
        }
	}
    Vector3 GetForceVector()
    {
        takenArcArray = ot.copyArcArray;
        float a = (takenArcArray[takenArcArray.Length - 1].x - takenArcArray[takenArcArray.Length - 2].x) / (time);
        float b = (takenArcArray[takenArcArray.Length - 1].y - takenArcArray[takenArcArray.Length - 2].y) / (time);
        
        return new Vector2(a, b);
    }
}
