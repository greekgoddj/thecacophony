using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        myJumpLocationIsSet = false;
        myCooldownIsActive = false;
        myJumpLocation = new Vector3(0, 0, 0);
        myCooldownTime = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.DownArrow) && !myJumpLocationIsSet && !myCooldownIsActive)
        {
            myJumpLocation = transform.position + new Vector3(0, -myJumpDistance, 0);
            Vector3 screenPoint = Camera.main.WorldToViewportPoint(myJumpLocation);
            if (screenPoint.y > 0)
            {
                myJumpLocationIsSet = true;
                GetComponent<SphereCollider>().enabled = false;
            }          
        }

        if (myJumpLocationIsSet)
        {
            transform.position = Vector3.MoveTowards(transform.position, myJumpLocation, myJumpSpeed);

            if (transform.position == myJumpLocation)
            {
                myJumpLocationIsSet = false;
                myCooldownIsActive = true;
                GetComponent<SphereCollider>().enabled = true;
            }
        }

        if (myCooldownIsActive)
        {
            myCooldownTime += Time.deltaTime;

            if (myCooldownTime > myCooldownDuration)
            {
                myCooldownIsActive = false;
                myCooldownTime = 0;
            }
        }
    }

    public float myJumpDistance;
    public float myCooldownDuration;
    public float myJumpSpeed;

    private float myCooldownTime;
    private bool myJumpLocationIsSet;
    private bool myCooldownIsActive;
    private Vector3 myJumpLocation;
}
