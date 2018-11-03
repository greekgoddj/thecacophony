using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLatitudinally : MonoBehaviour
{

  // Use this for initialization
  void Start()
  {
    playerInputs = new Dictionary<string, int>();
  }

  public Dictionary<string, int> playerInputs;

  // Update is called once per frame
  void Update()
  {
    float totalMoveSpeed = 0;
    int total = 0;

    if (Input.GetKey(KeyCode.LeftArrow))
    {
      if (myPlayer1MoveSpeed > -maxSpeed)
      {
        myPlayer1MoveSpeed -= multiplier;
      }
      totalMoveSpeed -= multiplier;

    }
    if (Input.GetKey(KeyCode.RightArrow))
    {
      if (myPlayer1MoveSpeed < maxSpeed)
      {
        myPlayer1MoveSpeed += multiplier;
      }
      totalMoveSpeed += multiplier;
    }
    total += 100;

    if (Input.GetKey(KeyCode.A))
    {
      if (myPlayer2MoveSpeed > -maxSpeed)
      {
        myPlayer2MoveSpeed -= multiplier;
      }
      totalMoveSpeed -= multiplier;
    }
    if (Input.GetKey(KeyCode.D))
    {
      if (myPlayer2MoveSpeed < maxSpeed)
      {
        myPlayer2MoveSpeed += multiplier;
      }
      totalMoveSpeed += multiplier;
    }
    total += 100;

    foreach (KeyValuePair<string, int> input in playerInputs)
    {
      totalMoveSpeed += input.Value;
      total += 100;
    }

    // Average out keyboard and web player move speeds
    totalMoveSpeed /= total;
    totalMoveSpeed *= maxSpeed;
    transform.Translate(Vector3.right * Time.deltaTime * totalMoveSpeed);

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
  public float multiplier = 20;

}
