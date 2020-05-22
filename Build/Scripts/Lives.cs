// Alex Pasieka
// 10/14/18
// keeps track of lives

using UnityEngine;

public class Lives : MonoBehaviour {

    public GameObject spaceship;
    public int lifeCounter;
    private GameObject[] numSpaceshipParts;
    private GameObject[] numSpaceships;
    public Font font;

	// initialization
	private void Start() {
        // starting with 3 lives
        lifeCounter = 3;
	}
	
	// called once per frame
	private void Update() {
        // finding spaceship parts and spaceships
        numSpaceshipParts = GameObject.FindGameObjectsWithTag("Spaceship Part");
        numSpaceships = GameObject.FindGameObjectsWithTag("Spaceship");

        // if there are no spaceship parts and no spaceships on screen, then subtract a life
        if (numSpaceshipParts.Length == 0 && numSpaceships.Length == 0) {
            if (lifeCounter > 0) {
                lifeCounter--;
            }
            // if there are lives left
            if (lifeCounter > 0) {
                // create a new spaceship
                Instantiate(spaceship, Vector3.zero, Quaternion.identity);
            }
        }
    }

    private void OnGUI() {
        // displaying lives
        if (lifeCounter > 0) {
            for (int i = 0; i < lifeCounter; i++) {
                Texture life = (Texture)Resources.Load("Spaceship Icon");
                GUI.DrawTexture(new Rect(life.width / 2 * i + 20 + (i * 10), 50, life.width / 2, life.height / 2), life);
            }
        }
        // game over screen
        else {
            int finalScore = GetComponent<Score>().score;

            GUI.skin.label.alignment = TextAnchor.MiddleCenter;
            GUI.skin.label.fontSize = 50;
            GUI.skin.label.font = font;
            GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "GAME OVER\nFINAL SCORE: " + finalScore);
        }
    }
}
