using UnityEngine;

public class ShellControls : MonoBehaviour {

    [Header("Input Settings")]
    public Joystick joystickGiro; // Joystick para rotación

    [Header("Movement Settings")]
    public float speed = 10f; // Velocidad de movimiento

    [Header("Target Settings")]
    public Rigidbody rigidbodyShell; // Rigidbody del personaje

    void Start() {
        if (rigidbodyShell == null) {
            rigidbodyShell = GameObject.FindWithTag("Shell").GetComponent<Rigidbody>();
        }
    }

    void Update() {

        // Obtiene los valores del joystick de rotación
        float inputX = joystickGiro.Horizontal;
        float inputY = joystickGiro.Vertical;

        if (inputX != 0 || inputY != 0) {
            Rotate(inputX, inputY);
        }
    }

    void Rotate(float inputX, float inputY) {

        // Solo rota si el joystick se está moviendo
        if (inputX != 0 || inputY != 0) {

            // Calcula el ángulo basado en el joystick
            float targetAngle = Mathf.Atan2(inputY, inputX) * Mathf.Rad2Deg - 90f;

            // Calcula la rotación suavizada usando Lerp
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
            rigidbodyShell.MoveRotation(Quaternion.Lerp(rigidbodyShell.rotation, targetRotation, Time.deltaTime * speed));
        }
    }
}