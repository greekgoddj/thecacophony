using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStuffToHit : MonoBehaviour {
    Vector3 pos;
    public GameObject prefab;
	// Use this for initialization
	void Start () {
        pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(pos, transform.position) > 10)
        {
            Spawn();
            pos = transform.position;
        }
	}

    void Spawn()
    {
        Vector2 fromPos = new Vector2(transform.position.x - pos.x, transform.position.y - pos.y);
        Vector2 pos2 = new Vector2(transform.position.x, transform.position.y) + fromPos.normalized * 8 + Random.insideUnitCircle.normalized * 3;
        Instantiate(prefab).transform.position = new Vector3(pos2.x, pos2.y, 0);
    }
}
