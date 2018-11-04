using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObject : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public float speed = 4.0f;
    Vector3 velocity;
    
	// Use this for initialization
	void Start () {
		if (offset.z == 0)
        {
            offset = new Vector3(offset.x, offset.y, transform.position.z);
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref velocity, 1.0f);
        //transform.position = Vector3.MoveTowards(transform.position, target.position + offset, speed * Time.deltaTime);
	}
}
