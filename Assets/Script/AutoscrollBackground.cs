using UnityEngine;

public class AutoscrollBackground : MonoBehaviour {

    public float speed = 1.5f;

    void Update() {
        // Mover el fondo hacia abajo
        float speedMove = speed * Time.deltaTime;
        transform.Translate(new Vector3(0f, -speedMove, 0f));
    }
}
