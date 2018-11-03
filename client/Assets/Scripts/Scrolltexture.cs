using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolltexture : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        offset += Time.deltaTime * scrollSpeed;
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0, -offset));
    }

    public float scrollSpeed;

    private float offset;
    private float rotate;
}
