using UnityEngine;

public class BubbleController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float floatSpeed = 0f; // Velocidad de flotación automática
    public float moveSpeed = 5f; // Velocidad de movimiento manual
    public float scrollSpeed = 50f; // Velocidad de rotación con el scroll

    [Header("Game Settings")]
    public Vector3 startPosition; // Posición inicial de la burigidbodyuja

    [Header("Score Settings")]
    public string enemyTag = "Enemy"; // Tag que identifica a los enemigos

    private Rigidbody rigidbody;

    void Start() {

        // Guardar la posición inicial
        startPosition = transform.position;

        // Obtener el componente Rigidbody
        rigidbody = GetComponent<Rigidbody>();

        if (rigidbody == null) {
            Debug.LogError("El objeto necesita un Rigidbody para funcionar correctamente.");
            rigidbody = new GameObject("Rigidbody").AddComponent<Rigidbody>();

            // Asignar configuración por defecto
            rigidbody.mass = 1f;
            rigidbody.linearDamping = 0f;
            rigidbody.angularDamping = 0.05f;
            rigidbody.automaticCenterOfMass = true;
            rigidbody.automaticInertiaTensor = true;
            rigidbody.interpolation = RigidbodyInterpolation.None;
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
            rigidbody.constraints = RigidbodyConstraints.None;
        }
    }

    void Update() {

        // Movimiento manual con las flechas
        float horizontal = Input.GetAxis("Horizontal"); // Movimiento izquierda/derecha
        float vertical = Input.GetAxis("Vertical"); // Movimiento arriba/abajo

        // Aplicar movimiento a la esfera sin rotarla
        Vector3 movement = new Vector3(horizontal, vertical + floatSpeed * Time.deltaTime, 0f);
        rigidbody.linearVelocity = movement * moveSpeed;

        // Rotar la esfera en el eje Z con el scroll del ratón
        // float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        // if (scrollInput != 0) {
        //     float rotationAmount = scrollInput * scrollSpeed * Time.deltaTime;
        //     transform.Rotate(rotationAmount, 0f, 0f);
        // }
    }

    private void OnCollisionEnter(Collision collision) {

        // Si un enemigo toca la burigidbodyuja
        if (collision.collider.CompareTag(enemyTag)) {
            Debug.Log("La burigidbodyuja fue tocada por un enemigo. Reiniciando posición.");
            ResetPosition(); // Reiniciar la posición de la burigidbodyuja
        }
    }

    private void ResetPosition() {
        transform.position = startPosition;
        rigidbody.linearVelocity = Vector3.zero;
    }
}
