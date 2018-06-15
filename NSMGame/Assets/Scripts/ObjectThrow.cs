using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThrow : MonoBehaviour {


    public ThrowingArcRender tar;

    public GameManager gM;

    public bool start = false;

    int nextPosIndex = 0;

    public Vector3[] copyArcArray;

    Rigidbody2D rb = new Rigidbody2D();

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //tar.arcArray

        if (Input.GetMouseButtonDown(0) && !!!start)
        {
            copyArcArray = tar.arcArray;
            for (int i = 0; i < copyArcArray.Length; i++)
            {
                copyArcArray[i] += transform.position;
            }
            nextPosIndex = 1;
            start = true;
            transform.parent = null;
        }
        if (start)
        {
            if (nextPosIndex == tar.arcArray.Length - 1)
            {
                start = false;
            }
            try
            {
                rb.MovePosition(/*new Vector2(transform.position.x + .001f, */copyArcArray[nextPosIndex]);
                if (transform.position.y > copyArcArray[nextPosIndex].y - .5f)
                {
                    nextPosIndex += 6 - (int)Mathf.Ceil(5 * transform.position.y / (tar.apexY - tar.pexY));

                }
                else
                {
                    Debug.Log("still going");
                }
            }
            catch (System.IndexOutOfRangeException e)
            {
                Debug.Log("error");
                rb.MovePosition(copyArcArray[copyArcArray.Length - 1]);
                start = false;
                gM.item = null;
            }
            if (transform.position == copyArcArray[copyArcArray.Length - 1])
            {
                start = false;
                gM.item = null;
            }
        }
	}
}
