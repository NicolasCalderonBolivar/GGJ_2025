using UnityEngine;

  

public class PlayerControls : MonoBehaviour {

    [Header("Input Settings")]
    public Joystick joystickMove; // Joystick para movimiento

    [Header("Movement Settings")]
    public float moveSpeed = 5f; // Velocidad de movimiento manual
    public float brakeSpeed = 5f; // Velocidad de frenado

    [Header("Game Settings")]
    public Vector3 startPosition; // Posición inicial de la burbuja

    [Header("Score Settings")]
    public string enemyTag = "Enemy"; // Tag que identifica a los enemigos

    [Header("Target Settings")]
    public GameObject player;


    private Rigidbody rigidbodyPlayer; // Rigidbody del personaje

    void Start() {

        // Guardar la posición inicial
        rigidbodyPlayer = player.GetComponent<Rigidbody>();

        if (rigidbodyPlayer == null) {
            Debug.LogError("No se ha encontrado un Rigidbody en el GameObject. Creando uno nuevo...");
        }
    }

    private void Update() {

        // Obtiene los valores del joystick para los ejes X (horizontal) y Y (vertical)
        float moveX = joystickMove.Horizontal;
        float moveY = joystickMove.Vertical;

        if (moveX != 0 || moveY != 0) {
            Move(moveX, moveY);
        }

        if (moveX == 0 && moveY == 0) {
            brakeMove();
        }
    }

    // Frenar el movimiento hasta detenerse empleando la velocidad de frenado
    private void brakeMove() {
        var rateBrake = Time.deltaTime * brakeSpeed;
        rigidbodyPlayer.linearVelocity = Vector3.Lerp(rigidbodyPlayer.linearVelocity, Vector3.zero, rateBrake);
    }

    // Función para manejar el movimiento
    private void Move(float moveX, float moveY) {
        rigidbodyPlayer.linearVelocity = new Vector3(moveX, moveY, 0f) * moveSpeed;
    }
}