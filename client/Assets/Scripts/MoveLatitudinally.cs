using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLatitudinally : MonoBehaviour {

	// Use this for initialization
	void Start () {
    playerInputs = new Dictionary<string, int>();
	}
  
    float number = 0;
  public Dictionary<string, int> playerInputs;

	// Update is called once per frame
	void Update ()
  {
    myMoveSpeed = 0;
    int total = 0;

    if (Input.GetKey(KeyCode.LeftArrow))
    {
      if (myMoveSpeed > -maxSpeed)
        myMoveSpeed -= multiplier;
    }
    if (Input.GetKey(KeyCode.RightArrow))
    {
      if (myMoveSpeed < maxSpeed)
      {
        myMoveSpeed += multiplier;
      }
    }
    total += 100;

    if (Input.GetKey(KeyCode.A))
    {
      if (myMoveSpeed > -maxSpeed)
        myMoveSpeed -= multiplier;
    }
    if (Input.GetKey(KeyCode.D))
    {
      if (myMoveSpeed < maxSpeed)
      {
        myMoveSpeed += multiplier;
      }
    }
    total += 100;

    foreach (KeyValuePair<string, int> input in playerInputs)
    {
      myMoveSpeed += input.Value;
      total += 100;
    }
    myMoveSpeed /= total;
    myMoveSpeed *= maxSpeed;
    transform.Translate(Vector3.right * Time.deltaTime * myMoveSpeed);
  }

    public float myMoveSpeed = 1;
    public float maxSpeed = 10;
    public float multiplier = 100;

}
