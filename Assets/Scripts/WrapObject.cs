// Alex Pasieka
// 10/14/18
// wraps all game objects around the screen

using UnityEngine;

public class WrapObject : MonoBehaviour {

    private float totalCamHeight;
    private float totalCamWidth;
    private Vector3 objectPosition;

    // initialization
    void Start() {
        // camera size math
        totalCamHeight = Camera.main.orthographicSize * 2f;
        totalCamWidth = totalCamHeight * Camera.main.aspect;
    }

    // called once per frame
    void Update() {
        // gets the current position of the object
        objectPosition = transform.position;

        // left bound
        if (objectPosition.x < -(totalCamWidth / 2)) {
            objectPosition.x = totalCamWidth / 2;
        }
        // right bound
        if (objectPosition.x > totalCamWidth / 2) {
            objectPosition.x = -(totalCamWidth / 2);
        }
        // bottom bound
        if (objectPosition.y < -(totalCamHeight / 2)) {
            objectPosition.y = totalCamHeight / 2;
        }
        // top bound
        if (objectPosition.y > totalCamHeight / 2) {
            objectPosition.y = -(totalCamHeight / 2);
        }

        // sets the new position of the object
        transform.position = objectPosition;
    }
}