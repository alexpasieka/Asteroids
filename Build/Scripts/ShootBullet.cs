// Alex Pasieka
// 10/11/18
// moves bullets along their respective direction vectors

using UnityEngine;

public class ShootBullet : MonoBehaviour {

    public float speed;
    public float duration;
    private Vector3 direction;

    // initialization
    private void Start() {
        direction = GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipControls>().spaceshipDirection;
    }

    // called once per frame
    private void Update () {
        // moving bullet
        transform.position += direction * speed;
        // limiting the amount of time a bullet exists for
        Destroy(gameObject, duration);
	}
}
