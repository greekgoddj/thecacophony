using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToBelowScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);

        if (screenPoint.y >= 1.1)
        {
            if (runMultiple)
            {
                
            }
            else
            {
                transform.position = new Vector3(transform.position.x, Camera.main.ViewportToWorldPoint(new Vector3(0, -0.1f, 0)).y, transform.position.z);
            }
        }
    }

    public bool runMultiple;
}
