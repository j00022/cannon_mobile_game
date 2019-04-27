using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class targetController : MonoBehaviour {

    public AudioClip scoreSound;
    public float _score;
    public Text scoreText;
    public Transform ExplosionSpawn;
    public GameObject ExplosionPrefab;

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Cannonball") {
            Destroy(collision.gameObject);
            GameObject explode = Instantiate(ExplosionPrefab, ExplosionSpawn.position, Quaternion.Euler(-90, 0, 0));
            _score++;
            scoreText.text = "Score = " + _score.ToString("0000");
            GetComponent<AudioSource>().Play();
        }
    }

    // Use this for initialization
    private void Start() {
        _score = 0;
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = scoreSound;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
