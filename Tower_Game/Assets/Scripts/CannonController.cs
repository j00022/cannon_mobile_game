using UnityEngine;
using System.Collections.Generic;

public class CannonController : MonoBehaviour {
    public int Cannonballs = 0;
    public GameObject Cannon_Ball;
    public Transform cannonBallSpawn;
    public int maxBalls;
    private float cannon_Power = 0f;
    private const float AngleIncrement = 5f;
    private float _angle = 0;
    public Queue<GameObject> queue = new Queue<GameObject>();

    public void AngleUp() {
        if (_angle >= 90f)
            return;
        Debug.Log("Move Angle Up");
        _angle += AngleIncrement;
        transform.rotation = Quaternion.Euler(0, 0, _angle);
    }
    public void AngleDown() {
        if (_angle <= 0f)
            return;
        Debug.Log("Move Angle Down");
        _angle -= AngleIncrement;
        transform.rotation = Quaternion.Euler(0, 0, _angle);
    }
    public void ChangePower(float newPower) {
        cannon_Power = newPower;
    }
    public void Fire() {
        if (queue.Count >= maxBalls) {
            Destroy(queue.Dequeue());
        }
        var aCannonBall = Instantiate(Cannon_Ball, cannonBallSpawn.transform.position, Quaternion.identity);
        queue.Enqueue(aCannonBall);
        Rigidbody2D cannonBallRigidBody = aCannonBall.GetComponent<Rigidbody2D>();
        cannonBallRigidBody.velocity = Quaternion.Euler(0, 0, _angle) * Vector3.right * cannon_Power;
    }

    public void Awake() {
        Debug.Log("In Awake");
       maxBalls = 10;
    }
    // Use this for initialization
    void Start() {
        Debug.Log("In Start");
    }

    [Range(0.001f, 2.0f)]
    public float Speed = 0f;
    // Update is called once per frame
    void Update() {
        Debug.Log("In Update");
        if (Input.GetKey(KeyCode.RightArrow)) {
            //Move cannon right
            transform.root.position += Vector3.right * Speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            //Move cannon left
            transform.root.position += Vector3.left * Speed;
        }

    }

    //For physics
    private void FixedUpdate() {

    }

    //For UI stuff, such as camera following
    private void LateUpdate() {

    }

}