using UnityEngine;

  

public class InputController2 : MonoBehaviour

{

     public Joystick joystickMove; // Joystick para movimiento

     public Joystick joystickGiro; // Joystick para rotación

    public Rigidbody rb; // Rigidbody del personaje

     public float speed = 10f; // Velocidad de movimiento

     public float rotationSmoothing = 5f; // Suavizado de la rotación

  

     private void Start()

     {

        // Asegúrate de que el Rigidbody no sea nulo

         if (rb == null)

         {

             rb = GetComponent<Rigidbody>();

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

  

    // Función para manejar la rotación

     private void Rotate()

    {

        // Obtiene los valores del joystick de rotación

         float inputX = joystickGiro.Horizontal;

         float inputY = joystickGiro.Vertical;

  

        // Solo rota si el joystick se está moviendo

         if (inputX != 0 || inputY != 0)

         {

            // Calcula el ángulo basado en el joystick (atan2 convierte los valores X e Y a un ángulo en grados)

             float targetAngle = Mathf.Atan2(inputY, inputX) * Mathf.Rad2Deg;

  

            // Calcula la rotación suavizada usando Lerp

             Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);

             rb.MoveRotation(Quaternion.Lerp(rb.rotation, targetRotation, Time.deltaTime * rotationSmoothing));

         }

     }

  

     private void Update()

     {

         Move(); // Llama a la función de movimiento

         Rotate(); // Llama a la función de rotación

     }

}