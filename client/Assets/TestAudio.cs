using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAudio : MonoBehaviour {

    [Range(0.0f, 1.0f)]
    public float alignment = 1.0f;
    [Range(0.0f, 1.0f)]
    public float maxOffset = 0.2f;
    public AudioSource a, b;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float offset = (1 - alignment) * maxOffset;
        a.pitch = 1.0f - offset;
        b.pitch = 1.0f - offset;
        b.volume = 0;
	}
}
