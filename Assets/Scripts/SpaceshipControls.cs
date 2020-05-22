// Alex Pasieka
// 10/4/18
// movement and user control of the spaceship

using UnityEngine;

public class SpaceshipControls : MonoBehaviour {

    public float rateOfAccel;
    public float rateOfDecel;
    public float maxSpeed;
    public float rotationSpeed;
    private float angleOfRotation;
    public Vector3 spaceshipDirection;
    private Vector3 velocity;
    private Vector3 acceleration;
    public GameObject bullet;

    // initialization
    private void Start() {
        spaceshipDirection =  Vector3.right;
        velocity = Vector3.zero;
        acceleration = Vector3.zero;
    }

    // called once per frame
    private void Update() {
        Drive();
        RotateSpaceship();
        // limit number of bullets on screen to 4
        if (GameObject.FindGameObjectsWithTag("Bullet").Length < 4) {
            Shoot();
        }
    }

    // drive the spaceship forward
    private void Drive() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            // add acceleration to velocity
            acceleration = rateOfAccel * spaceshipDirection;
            velocity += acceleration;
            // limit velocity vector
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        }
        // deceleration
        else {
            // multiply velocity by deceleration
            velocity *= rateOfDecel;
        }
        // add velocity to position
        transform.position += velocity;
    }

    // rotate spaceship based on direction input
    private void RotateSpaceship() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            // rotating counter clockwise
            spaceshipDirection = Quaternion.Euler(0, 0, rotationSpeed) * spaceshipDirection;
            angleOfRotation += rotationSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow)) {
            // rotating clockwise
            spaceshipDirection = Quaternion.Euler(0, 0, -rotationSpeed) * spaceshipDirection;
            angleOfRotation -= rotationSpeed;
        }
        // rotate the spaceship to face correct direction
        transform.rotation = Quaternion.Euler(0, 0, angleOfRotation);
    }

    // shoot bullets
    private void Shoot() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}