using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(SleepTimer());
	}
	
    IEnumerator SleepTimer() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
