using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallUpward : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -myMoveSpeed, 0);

        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);

        if (screenPoint.y >= 1.1)
        {
            Destroy(this.gameObject);
        }
    }

    public float myMoveSpeed;
}
