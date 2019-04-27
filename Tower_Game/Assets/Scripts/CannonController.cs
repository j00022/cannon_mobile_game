using UnityEngine;
using System.Collections.Generic;

public class CannonController : MonoBehaviour {
    public int ball_count = 0;
    public int max_Balls = 10;
    public Queue<GameObject> queue = new Queue<GameObject>();
    public GameObject cannon_Ball;
    public Transform cannon_Ball_Spawn;

    private float cannon_Power = 1f;
    private const float angleIncrement = 5f;
    private float _angle = 0;
    public float speed = 0.075f;

    public AudioClip fireSound;

    public void AngleUp() {
        if (_angle >= 90f)
            return;
        _angle += angleIncrement;
        transform.rotation = Quaternion.Euler(0, 0, _angle);
    }
    public void AngleDown() {
        if (_angle <= 0f)
            return;
        _angle -= angleIncrement;
        transform.rotation = Quaternion.Euler(0, 0, _angle);
    }
    public void MoveRight() {
        transform.root.position += Vector3.right * speed;
    }
    public void MoveLeft() {
        transform.root.position += Vector3.left * speed;
    }
    public void ChangePower(float newPower) {
        cannon_Power = newPower / 2 + 1;
    }
    public void Fire() {
        GetComponent<AudioSource>().Play();
        if (queue.Count >= max_Balls) {
            Destroy(queue.Dequeue());
        }
        var aCannonBall = Instantiate(cannon_Ball, cannon_Ball_Spawn.transform.position, Quaternion.identity);
        queue.Enqueue(aCannonBall);
        Rigidbody2D cannonBallRigidBody = aCannonBall.GetComponent<Rigidbody2D>();
        cannonBallRigidBody.velocity = Quaternion.Euler(0, 0, _angle) * Vector3.right * cannon_Power;
    }

    // Use this for initialization
    void Start() {
        GetComponent<AudioSource>().clip = fireSound;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.RightArrow)) {
            //Move cannon right
            transform.root.position += Vector3.right * speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            //Move cannon left
            transform.root.position += Vector3.left * speed;
        }
    }
}