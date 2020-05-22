// Alex Pasieka
// 10/13/18
// spaceship destruction animation

using UnityEngine;

public class SpaceshipPartMovement : MonoBehaviour {

    public float speed;
    private float angleOfRotation;
    private Vector3 direction;
    private Vector3 velocity;
    private Vector3 collisionPosition;

    // initialization
    private void Start() {
        // random rotation
        angleOfRotation = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0, 0, angleOfRotation);

        // random direction
        direction = Random.insideUnitCircle.normalized;

        // using the position of collision as the starting point for the animation
        collisionPosition = transform.position;

        // calculating velocity
        velocity = speed * direction;
    }
	
	// called once per frame
	private void Update() {
        // add velocity to position
        collisionPosition += velocity;

        // move spaceship parts
        transform.position = collisionPosition;

        // lower opacity
        Color opacity = gameObject.GetComponent<Renderer>().material.color;
        opacity.a *= .95f;
        gameObject.GetComponent<Renderer>().material.color = opacity;

        // deletes spaceship parts after they are barely visible
        if (opacity.a < .1f) {
            Destroy(gameObject);
        }
    }
}
