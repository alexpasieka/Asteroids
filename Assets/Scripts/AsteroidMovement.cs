// Alex Pasieka
// 10/4/18
// moves the asteroids in different directions at constant speeds

using UnityEngine;

public class AsteroidMovement : MonoBehaviour {

    public float speed;
    private float angleOfRotation;
    private Vector3 direction;
    private Vector3 velocity;

    // initialization
    private void Start() {
        // random rotation
        angleOfRotation = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0, 0, angleOfRotation);

        // random direction
        direction = Random.insideUnitCircle.normalized;

        // calculating velocity
        velocity = speed * direction;
    }

    // called once per frame
    private void Update() {
        // moving the asteroid
        transform.position += velocity;
    }
}