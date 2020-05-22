// Alex Pasieka
// 10/14/18
// calculates score based on size of asteroid destroyed

using UnityEngine;

public class Score : MonoBehaviour {

    public int score;
    private int largeAsteroidPoints;
    private int mediumAsteroidPoints;
    private int smallAsteroidPoints;
    public Font font;

    // initialization
    private void Start() {
        // start the score at zero
        score = 0;
        largeAsteroidPoints = 20;
        mediumAsteroidPoints = 50;
        smallAsteroidPoints = 100;
    }

    // calculates the score based on the size of destroyed asteroids
    public void CalculateScore(GameObject _asteroid) {
        if (_asteroid.transform.localScale.x == 1) {
            score += largeAsteroidPoints;
        }
        if (_asteroid.transform.localScale.x == 0.5) {
            score += mediumAsteroidPoints;
        }
        if (_asteroid.transform.localScale.x == 0.25) {
            score += smallAsteroidPoints;
        }
    }

    // displays score in upper left corner
    private void OnGUI() {
        if (GetComponent<Lives>().lifeCounter > 0) {
            GUI.skin.label.alignment = TextAnchor.MiddleLeft;
            GUI.skin.label.fontSize = 30;
            GUI.skin.label.font = font;
            GUI.Label(new Rect(20, 15, 200, 30), score.ToString());
        }
    }
}
