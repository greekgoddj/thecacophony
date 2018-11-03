using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLatitudinally : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    float number = 0;

	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(myPlayer1MoveSpeed > -maxSpeed)
                myPlayer1MoveSpeed -= multiplier;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(myPlayer1MoveSpeed < maxSpeed)
            {
                myPlayer1MoveSpeed += multiplier;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if(myPlayer2MoveSpeed > -maxSpeed)
                myPlayer2MoveSpeed -= multiplier;
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (myPlayer2MoveSpeed < maxSpeed)
            {
                myPlayer2MoveSpeed += multiplier;
            }
        }

        transform.Translate(Vector3.right * Time.deltaTime * (myPlayer1MoveSpeed + myPlayer2MoveSpeed));
        SetAudioPitchs();
    }

    void SetAudioPitchs()
    {
        GameObject.Find("LeftPanel").GetComponent<AudioSource>().pitch = (myPlayer1MoveSpeed / 100) + 1;
        GameObject.Find("RightPanel").GetComponent<AudioSource>().pitch = (myPlayer2MoveSpeed / 100) + 1;
    }

    public float myPlayer1MoveSpeed = 0;
    public float myPlayer2MoveSpeed = 0;
    public float maxSpeed = 5;
    public float multiplier = 1;

}
