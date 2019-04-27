using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour {

    public float xorigin, yorigin;

	// Use this for initialization
	void Start () {
        xorigin = transform.position.x;
        yorigin = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Mathf.PingPong(Time.time, 3f) + xorigin, Mathf.PingPong(Time.time, 1.4f) + yorigin, transform.position.y);
	}
}
