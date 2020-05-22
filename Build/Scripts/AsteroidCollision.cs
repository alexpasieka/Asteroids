// Alex Pasieka
// 10/4/18
// breaks down asteroids based on collision detection between the spaceship/bullets and asteroids

using UnityEngine;

public class AsteroidCollision : MonoBehaviour {

    private GameObject[] asteroids;
    public GameObject asteroidPrefab;
    private Sprite[] asteroidSprites;
    public GameObject spaceshipPart;
    private GameObject scoreCalculator;

    // initialization
    private void Start() {
        scoreCalculator = GameObject.FindGameObjectWithTag("Manager");
    }

    // called once per frame
    private void Update() {
        // array of all asteroids on screen
        asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

        // calling the collision methods
        foreach (GameObject asteroid in asteroids) {
            if (CircleCollision(asteroid) == true) {
                if (gameObject.tag == "Spaceship") {
                    // an asteroid breaks down if the ship collides with it
                    if (asteroid.transform.localScale.x > 0.25) {
                        AsteroidBreakdown(asteroid.transform.position, asteroid.transform.localScale);
                    }
                    // play spaceship desctruction animation
                    SpaceshipDestruction();
                    Destroy(asteroid);
                    Destroy(gameObject);

                    // calculates score
                    scoreCalculator.GetComponent<Score>().CalculateScore(asteroid);
                }
                if (gameObject.tag == "Bullet") {
                    // after 3 hits, an asteroid is destroyed
                    if (asteroid.transform.localScale.x > 0.25) {
                        AsteroidBreakdown(asteroid.transform.position, asteroid.transform.localScale);
                    }
                    Destroy(asteroid);
                    Destroy(gameObject);

                    // calculates score
                    scoreCalculator.GetComponent<Score>().CalculateScore(asteroid);
                }
            }
        }
    }

    // checks for collision between 2 game objects' bounding circles
    private bool CircleCollision(GameObject _asteroid) {
        // getting centers of game objects
        Vector3 objectCenter = GetComponent<Collider>().bounds.center;
        Vector3 asteroidCenter = _asteroid.GetComponent<Collider>().bounds.center;

        // getting radii of game objects
        float objectRadius = GetComponent<Collider>().bounds.extents.x;
        float asteroidRadius = _asteroid.GetComponent<Collider>().bounds.extents.x;

        // calculating distance between centers
        float distance = Mathf.Sqrt(Mathf.Pow((objectCenter.x - asteroidCenter.x), 2) +
                                    Mathf.Pow((objectCenter.y - asteroidCenter.y), 2));

        // checking for collision
        if (distance < objectRadius + asteroidRadius) {
            return true;
        }
        // else...
        return false;
    }

    // breaks down larger asteroids into 2 smaller ones
    private void AsteroidBreakdown(Vector3 collisionPosition, Vector3 previousScale) {
        // creates 2 new smaller asteroids
        for (int i = 0; i < 2; i++) {
            // loading all asteroid sprites
            asteroidSprites = Resources.LoadAll<Sprite>("Asteroids");

            // assigning a random asteroid sprite
            int randomSpriteIndex = Random.Range(0, asteroidSprites.Length);
            asteroidPrefab.GetComponent<SpriteRenderer>().sprite = asteroidSprites[randomSpriteIndex];

            // instantiating new asteroid at collision point
            GameObject newAsteroid = Instantiate(asteroidPrefab, collisionPosition, Quaternion.identity);

            // setting the scale of the new asteroid to the same as the previous asteroid
            newAsteroid.transform.localScale = previousScale;

            // scaling the new asteroid down
            newAsteroid.transform.localScale /= 2;
        }
    }

    // plays the spaceship destruction animation
    private void SpaceshipDestruction() {
        for (int i = 0; i < 4; i++) {
            Instantiate(spaceshipPart, transform.position, Quaternion.identity);
        }
    }
}