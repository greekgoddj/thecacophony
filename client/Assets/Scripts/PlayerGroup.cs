using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroup : MonoBehaviour {
    public Dictionary<string, int> playerInputs;
    Dictionary<string, GameObject> playerObjects;//each input creates an object to display the direction
    public GameObject playerPrefab;//just a sprite atm
    public float playerPosRadius = 0.5f;
    Vector2 velocity;
    public float maxSpeed = 5.0f;
    public float accelleration = 5.0f;
    AudioSource audio;
    public float badPitch = 0.7f, goodPitch = 1.0f;//bad when players give different directions, good when all the same
    Vector2 bounceVelocity;//extra valocity to move by when bouncing off something, set high then reduces to 0
    public float bounceStrength = 5.0f;//velocity to start moving away from collision
    public float bouncePitchHigh, bouncePitchLow;//audio pitch to use while bouncing off something, decreases as speed does
	// Use this for initialization
	void Start () {
        playerInputs = new Dictionary<string, int>();
        playerObjects = new Dictionary<string, GameObject>();
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 totalDirection = Vector2.zero;
        foreach (KeyValuePair<string, int> input in playerInputs)
        {
            if (!playerObjects.ContainsKey(input.Key))
            {
                playerObjects[input.Key] = Instantiate(playerPrefab);
                playerObjects[input.Key].transform.parent = transform;
                playerObjects[input.Key].transform.localPosition = Vector3.zero;
            }
            GameObject playerObject = playerObjects[input.Key];
            Vector2 playerInputAsVector = GetInputAsVector(input.Value);
            playerObject.transform.localPosition = new Vector3(playerInputAsVector.x, playerInputAsVector.y, 0) * playerPosRadius;

            totalDirection += playerInputAsVector;
        }

        float bounceDeceleration = 3.0f;
        bounceVelocity = Vector2.MoveTowards(bounceVelocity, Vector2.zero, bounceDeceleration * Time.deltaTime);
        bool bouncing = true;
        if (bounceVelocity.magnitude <= 0.3f)
        {
            bounceVelocity = Vector2.zero;
            bouncing = false;
        }

        float numPlayers = playerInputs.Count;
        float maxVelocityScale = 0.0f;
        if (numPlayers > 0)
        {
            Vector2 averageDirection = (totalDirection / numPlayers);
            //all facing same way = 1, all facing random directions = close to 0
            maxVelocityScale = Mathf.Clamp01(averageDirection.magnitude);

            if (bouncing)
            {
                audio.pitch = Mathf.Lerp(bouncePitchLow, bouncePitchHigh, Mathf.Clamp01(bounceVelocity.magnitude / bounceStrength));
            }
            else
            {
                audio.pitch = Mathf.Lerp(badPitch, goodPitch, Mathf.Clamp01(averageDirection.magnitude));
            }
        }


        Vector2 targetVelocity = totalDirection.normalized * maxSpeed * maxVelocityScale;
        velocity = Vector2.MoveTowards(velocity, targetVelocity, accelleration * Time.deltaTime);

        transform.position += (new Vector3(velocity.x, velocity.y, 0) + new Vector3(bounceVelocity.x, bounceVelocity.y, 0)) * Time.deltaTime;
    }

    Vector2 GetInputAsVector(int input)
    {
        float scale = 180.0f;//144.0f;
        float mappedToSensibleAngles = ((float)input) * (180.0f / scale);
        float y = Mathf.Cos(Mathf.Deg2Rad * mappedToSensibleAngles);
        float x = Mathf.Sin(Mathf.Deg2Rad * mappedToSensibleAngles);
        return new Vector2(x, y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bounceVelocity = (transform.position - collision.gameObject.transform.position).normalized * bounceStrength;
    }
}
