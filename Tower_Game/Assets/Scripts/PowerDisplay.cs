using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerDisplay : MonoBehaviour {

    Text powerNumber;

	// Use this for initialization
	void Start () {
        powerNumber = GetComponent<Text>();
	}
	
	// Update is called once per frame
	public void textUpdate (float powerValue) {
        powerValue = (powerValue / 30) * 100;
        powerNumber.text = "Power = " + powerValue.ToString("0");
	}
}
