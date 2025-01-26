using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con UI

public class BubbleController : MonoBehaviour
{
    [Header("Game Settings")]
    public string enemyTag = "Enemy"; // Tag que identifica a los enemigos
    public GameObject gameOverUI;     // Referencia al panel de "GAME OVER" y los botones

    private Rigidbody rb;

    void Start()
    {
        // Obtener el componente Rigidbody
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("El objeto necesita un Rigidbody para funcionar correctamente.");
        }

        // Asegúrate de que el UI de Game Over esté desactivado al inicio
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);  // Desactiva la UI de Game Over
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Si un enemigo toca la burbuja
        if (collision.collider.CompareTag(enemyTag))
        {
            Debug.Log("GAME OVER");
            GameOver(); // Llamar a la función de fin del juego
        }
    }

    public void GameOver()
    {
        // Mostrar el mensaje de GAME OVER y los botones
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);  // Activa la UI de Game Over
        }

        // Opcional: detener el tiempo del juego
        Time.timeScale = 0f;
    }
}
