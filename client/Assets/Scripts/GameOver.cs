using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);

        if (screenPoint.y >= 1.1)
        {
            GameObject.Find("YouLoseText").GetComponent<UnityEngine.UI.Text>().text = "You Are A Filthy Scrub";
        }
    }
}
