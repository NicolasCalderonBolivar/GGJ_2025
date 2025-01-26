using UnityEngine;

  

public class InputController : MonoBehaviour

{

    public Joystick joystickMove; // Joystick para movimiento

     public Rigidbody rb; // Rigidbody del personaje

     public float speed = 10f; // Velocidad de movimiento

     public string enemyTag = "Enemy"; // Tag que identifica a los enemigos
     public Vector3 startPosition; // Posición inicial de la burbuja
     

  

     private void Start()

     {

            // Guardar la posición inicial
            startPosition = transform.position;
            // Asegúrate de que el Rigidbody no sea nulo

         if (rb == null)

         {

             rb = GetComponent<Rigidbody>();
            
        if (rb == null)
        {
            Debug.LogError("El objeto necesita un Rigidbody para funcionar correctamente.");
        }

         }

     }

  

    // Función para manejar el movimiento

     private void Move()

     {

        // Obtiene los valores del joystick para los ejes X (horizontal) y Y (vertical)

         float moveX = joystickMove.Horizontal * speed; // Movimiento horizontal

             float moveY = joystickMove.Vertical * speed;  // Movimiento vertical

  

        // Aplica el movimiento al Rigidbody, manteniendo Z en 0

         rb.linearVelocity = new Vector3(moveX, moveY, 0f);

         }

  

     private void Update()

    {

         Move(); // Llama a la función de movimiento en cada frame

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