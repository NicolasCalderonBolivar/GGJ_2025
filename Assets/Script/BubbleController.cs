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

    private Vector3 movement; // Movimiento actual de la burbuja (horizontales y verticales)

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
        // Movimiento con las flechas del teclado
        float horizontal = Input.GetAxis("Horizontal"); // Movimiento izquierda/derecha
        float vertical = Input.GetAxis("Vertical"); // Movimiento arriba/abajo

        // Actualizar el movimiento solo si las flechas o botones táctiles están activos
        if (horizontal != 0 || vertical != 0)
        {
            movement = new Vector3(horizontal * moveSpeed, vertical * moveSpeed, 0f);
        }

        // Aplica el movimiento solo cuando la variable 'movement' tiene algún valor
        rb.linearVelocity = movement;

        // Rotación con scroll del ratón
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0)
        {
            float rotationAmount = scrollInput * scrollSpeed * Time.deltaTime;
            transform.Rotate(rotationAmount, 0f, 0f);
        }
    }

    // Métodos públicos para movimiento táctil
    public void MoveHorizontally(float direction)
    {
        movement = new Vector3(direction * moveSpeed, rb.linearVelocity.y, 0f);
    }

    public void MoveVertically(float direction)
    {
        movement = new Vector3(rb.linearVelocity.x, direction * moveSpeed, 0f);
    }

    // Ahora la rotación se ajusta según una velocidad similar al scroll
    public void Rotate(float direction)
    {
        // La rotación es proporcional al scrollSpeed, igual que cuando usas el mouse scroll
        float rotationAmount = direction * scrollSpeed * Time.deltaTime;
        transform.Rotate(rotationAmount, 0f, 0f);
    }

    // Método para detener el movimiento
    public void StopMoving()
    {
        movement = Vector3.zero; // Detener el movimiento cuando no se presionan los botones
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

public void ResetPosition()
{
    transform.position = startPosition; // Restablecer la posición a la inicial
    rb.linearVelocity = Vector3.zero; // Detener cualquier movimiento
    rb.angularVelocity = Vector3.zero; // Detener cualquier rotación
}


}

