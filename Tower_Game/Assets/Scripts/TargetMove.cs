using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour {

    private float xorigin, yorigin;
    private float x_boundary, y_boundary;

	// Use this for initialization
	void Start () {
        xorigin = transform.position.x;
        yorigin = transform.position.y;
        x_boundary = 6.222f;
        y_boundary = 3.333f;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Mathf.PingPong(Time.time, x_boundary) + xorigin, Mathf.PingPong(Time.time, y_boundary) + yorigin, transform.position.y);
	}
}
