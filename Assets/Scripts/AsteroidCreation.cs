// Alex Pasieka
// 10/4/18
// creates the asteroids at the start of a level

using UnityEngine;

public class AsteroidCreation : MonoBehaviour {

    private int levelNum;
    public int numAsteroids;
    public GameObject asteroid;
    private Vector3 asteroidPosition;
    private Sprite[] asteroidSprites;
    private float totalCamHeight;
    private float totalCamWidth;

    // asteroid instantiation
    private void Start() {
        // starting at level 1
        levelNum = 1;

        // camera size
        totalCamHeight = Camera.main.orthographicSize * 2f;
        totalCamWidth = totalCamHeight * Camera.main.aspect;

        CreateAsteroids();
	}

    // called once per frame
    private void Update() {
        GameObject[] allAsteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        // if all asteroids are destroyed, go to the next level
        if (allAsteroids.Length == 0) {
            levelNum++;
            CreateAsteroids();
        }
    }

    // creates new asteroids for new levels
    private void CreateAsteroids() {
        for (int i = 0; i < numAsteroids * levelNum; i++) {
            // loading all asteroid sprites
            asteroidSprites = Resources.LoadAll<Sprite>("Asteroids");

            // assigning a random asteroid sprite
            int randomSpriteIndex = Random.Range(0, asteroidSprites.Length);
            asteroid.GetComponent<SpriteRenderer>().sprite = asteroidSprites[randomSpriteIndex];

            // random starting position
            asteroidPosition = new Vector3(Random.Range(-(totalCamWidth / 2), totalCamWidth / 2),
                                           Random.Range(-(totalCamHeight / 2), totalCamHeight / 2),
                                           0);

            // instantiating
            Instantiate(asteroid, asteroidPosition, Quaternion.identity);
        }
    }
}