using UnityEngine;

public class TouchUIController : MonoBehaviour
{
    public BubbleController bubbleController;  // Referencia al controlador de la burbuja

    // Estas funciones serán llamadas desde los botones
    public void OnMoveLeftPressed()
    {
        bubbleController.MoveHorizontally(-1f); // Mover a la izquierda
    }

    public void OnMoveRightPressed()
    {
        bubbleController.MoveHorizontally(1f); // Mover a la derecha
    }

    public void OnMoveUpPressed()
    {
        bubbleController.MoveVertically(1f); // Mover hacia arriba
    }

    public void OnMoveDownPressed()
    {
        bubbleController.MoveVertically(-1f); // Mover hacia abajo
    }

    public void OnRotateLeftPressed()
    {
        bubbleController.Rotate(-1f); // Rotar a la izquierda
    }

    public void OnRotateRightPressed()
    {
        bubbleController.Rotate(1f); // Rotar a la derecha
    }

    // Esta función detiene el movimiento cuando se suelta un botón
    public void OnButtonReleased()
    {
        bubbleController.StopMoving(); // Detener el movimiento o rotación
    }
}
