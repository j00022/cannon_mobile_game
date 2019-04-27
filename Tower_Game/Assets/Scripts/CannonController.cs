using UnityEngine;
using System.Collections.Generic;

public class CannonController : MonoBehaviour {
    public int Cannonballs = 0;
    public GameObject Cannon_Ball;
    public Transform cannonBallSpawn;
    public int maxBalls;
    private float cannon_Power = 1f;
    private const float AngleIncrement = 5f;
    private float _angle = 0;
    public Queue<GameObject> queue = new Queue<GameObject>();
    public AudioClip fireSound;

    public void AngleUp() {
        if (_angle >= 90f)
            return;
        _angle += AngleIncrement;
        transform.rotation = Quaternion.Euler(0, 0, _angle);
    }
    public void AngleDown() {
        if (_angle <= 0f)
            return;
        _angle -= AngleIncrement;
        transform.rotation = Quaternion.Euler(0, 0, _angle);
    }
    public void MoveRight() {
        transform.root.position += Vector3.right * Speed;
    }
    public void MoveLeft() {
        transform.root.position += Vector3.left * Speed;
    }
    public void ChangePower(float newPower) {
        cannon_Power = newPower / 2 + 1;
    }
    public void Fire() {
        GetComponent<AudioSource>().Play();
        if (queue.Count >= maxBalls) {
            Destroy(queue.Dequeue());
        }
        var aCannonBall = Instantiate(Cannon_Ball, cannonBallSpawn.transform.position, Quaternion.identity);
        queue.Enqueue(aCannonBall);
        Rigidbody2D cannonBallRigidBody = aCannonBall.GetComponent<Rigidbody2D>();
        cannonBallRigidBody.velocity = Quaternion.Euler(0, 0, _angle) * Vector3.right * cannon_Power;
    }

    public void Awake() {
       maxBalls = 10;
    }
    // Use this for initialization
    void Start() {
        GetComponent<AudioSource>().clip = fireSound;
    }

    [Range(0.001f, 2.0f)]
    public float Speed = 0f;
    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.RightArrow)) {
            //Move cannon right
            transform.root.position += Vector3.right * Speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            //Move cannon left
            transform.root.position += Vector3.left * Speed;
        }
    }
}