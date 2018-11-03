using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipe : MonoBehaviour
{
    [SerializeField]
    private GameObject _pipePrefab;
    public float mySpawnFrequency;

    float myMinSpawnX;
    float myMaxSpawnX;
    System.Random myRandomNumberGenerator;
    float myTimeSinceLastSpawn;

    // Use this for initialization
    void Start ()
    {
        myRandomNumberGenerator = new System.Random();
    }
	
	// Update is called once per frame
	void Update ()
    {
        myTimeSinceLastSpawn += Time.deltaTime;

        if (myTimeSinceLastSpawn > mySpawnFrequency)
        {
            myTimeSinceLastSpawn = 0;


                Spawn();
        }
    }

    private void Spawn()
    {
        GameObject newPipe = Instantiate(_pipePrefab);

        System.Random random = new System.Random();
        int getRandom = random.Next(2);

        if(getRandom == 1)
        {
            newPipe.transform.position = new Vector3(3.273f, Camera.main.ViewportToWorldPoint(new Vector3(0, -0.2f, 0)).y);
            newPipe.transform.localRotation = Quaternion.Euler(0, 0, 180f);
            var fall = newPipe.GetComponent<FallUpward>();
            fall.myMoveSpeed = -fall.myMoveSpeed;

        }
        else
        {
            newPipe.transform.position = new Vector3(-3.273f, Camera.main.ViewportToWorldPoint(new Vector3(0, -0.2f, 0)).y);
        }
    }
}
