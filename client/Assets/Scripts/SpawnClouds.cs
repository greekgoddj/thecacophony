using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClouds : MonoBehaviour {

	// Use this for initialization
	void Start () {
        myRandomNumberGenerator = new System.Random();
        myMinSpawnX = (float)Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        myMaxSpawnX = (float)Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 1)).x;
    }
	
	// Update is called once per frame
	void Update () {

        myTimeSinceLastSpawn += Time.deltaTime;

        if (myTimeSinceLastSpawn > mySpawnFrequency)
        {
            myTimeSinceLastSpawn = 0;

            int numberOfCloudsToSpawn = myRandomNumberGenerator.Next(4);

            for (int i = 0; i < numberOfCloudsToSpawn; ++i)
            {
                SpawnCloud();
            }

        }
    }

    private void SpawnCloud()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);

        if (screenPoint.x >= 1.1)
        {
            transform.position = new Vector3(transform.position.x, Camera.main.ViewportToWorldPoint(new Vector3(0, -0.1f, 0)).y, transform.position.z);
        }

        float xcoordinate = (float)myRandomNumberGenerator.NextDouble() * (myMaxSpawnX - myMinSpawnX) + myMinSpawnX;

        Debug.Log(xcoordinate);

        GameObject newCloud = Instantiate(myCloudPrefab);
        newCloud.transform.position = new Vector3((float)xcoordinate, Camera.main.ViewportToWorldPoint(new Vector3(0, -0.2f, 0)).y, 0);
    }

    public float mySpawnFrequency;
    public GameObject myCloudPrefab;

    float myMinSpawnX;
    float myMaxSpawnX;
    System.Random myRandomNumberGenerator;
    float myTimeSinceLastSpawn;
}
