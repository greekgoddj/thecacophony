using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLatitudinally : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(myMoveSpeed > -maxSpeed)
                myMoveSpeed-= multiplier;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(myMoveSpeed < maxSpeed)
            {
                myMoveSpeed += multiplier;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if(myMoveSpeed > -maxSpeed)
                myMoveSpeed -= multiplier;
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (myMoveSpeed < maxSpeed)
            {
                myMoveSpeed += multiplier;
            }
        }

        //if (transform.position.x < 5.82f && transform.position.x > -5.82f)
        //{
            transform.Translate(Vector3.right * Time.deltaTime * myMoveSpeed);
        //}

        //// Player 1
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.Translate(Vector3.left * Time.deltaTime * myMoveSpeed);
        //}

        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Translate(Vector3.right * Time.deltaTime * myMoveSpeed);
        //}

        // Player 2
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(Vector3.left * Time.deltaTime * myMoveSpeed);
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(Vector3.right * Time.deltaTime * myMoveSpeed);
        //}
    }

    public float myMoveSpeed = 1;
    public float maxSpeed = 10;
    public float multiplier = 1;

}
