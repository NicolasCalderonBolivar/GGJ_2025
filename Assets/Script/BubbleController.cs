using UnityEngine;

public class BubbleController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float floatSpeed = 2f; // Velocidad de flotación automática
    public float moveSpeed = 5f; // Velocidad de movimiento manual
    public float scrollSpeed = 50f; // Velocidad de rotación con el scroll

    [Header("Game Settings")]
    public Vector3 startPosition; // Posición inicial de la burbuja

    [Header("Score Settings")]
    public string enemyTag = "Enemy"; // Tag que identifica a los enemigos

    private Rigidbody rb;

    void Start()
    {
        // Guardar la posición inicial
        startPosition = transform.position;

        // Obtener el componente Rigidbody
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("El objeto necesita un Rigidbody para funcionar correctamente.");
        }
    }

    void Update()
    {
        // Movimiento manual con las flechas
        float horizontal = Input.GetAxis("Horizontal"); // Movimiento izquierda/derecha
        float vertical = Input.GetAxis("Vertical"); // Movimiento arriba/abajo

        // Aplicar movimiento a la esfera sin rotarla
        Vector3 movement = new Vector3(horizontal, vertical + floatSpeed * Time.deltaTime, 0f);
        rb.linearVelocity = movement * moveSpeed;

        // Rotar la esfera en el eje Z con el scroll del ratón
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0)
        {
            float rotationAmount = scrollInput * scrollSpeed * Time.deltaTime;
            transform.Rotate(0f, 0f, rotationAmount);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Si un enemigo toca la burbuja
        if (collision.collider.CompareTag(enemyTag))
        {
            Debug.Log("La burbuja fue tocada por un enemigo. Reiniciando posición.");
            ResetPosition(); // Reiniciar la posición de la burbuja
        }
    }

    private void ResetPosition()
    {
        transform.position = startPosition;
        rb.linearVelocity = Vector3.zero;
    }
}
