﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class targetController : MonoBehaviour {

    public AudioClip scoreSound;
    public float _score, _accuracy, _shots_fired;
    public Text scoreText, accuracy;
    public Transform ExplosionSpawn;
    public GameObject ExplosionPrefab, cannon;

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Cannonball") {
            Destroy(collision.gameObject);
            GameObject explode = Instantiate(ExplosionPrefab, ExplosionSpawn.position, Quaternion.Euler(-90, 0, 0));
            _score++;
            scoreText.text = "Score = " + _score.ToString("0000");
            GetComponent<AudioSource>().Play();
            Destroy(explode, 10);
        }
    }

    // Use this for initialization
    private void Start() {
        _score = 0;
        _shots_fired = 0;
        _accuracy = 0;
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = scoreSound;
    }
    public void Update() {
        _shots_fired = cannon.GetComponent<CannonController>()._shots_fired;
        if (_shots_fired == 0)
            return;
        _accuracy = _score * 100 / _shots_fired;
        accuracy.text = "Accuracy = " + _accuracy.ToString("0.0") + "%";
    }
}
