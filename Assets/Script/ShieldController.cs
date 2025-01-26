using UnityEngine;
using UnityEngine.UI; // Necesario para el uso de UI

public class ShieldController : MonoBehaviour
{
    public BubbleController bubbleController; // Referencia al script de la burbuja
    public GameObject[] enemies; // Array de enemigos en la escena
    private Vector3[] initialEnemyPositions; // Posiciones iniciales de los enemigos
    private Quaternion[] initialEnemyRotations; // Rotaciones iniciales de los enemigos
    private Rigidbody[] enemyRigidbodies; // Almacena los Rigidbody de los enemigos

    public int score = 0; // Puntuación del jugador
    public Text scoreText; // Referencia al objeto Text en UI para mostrar la puntuación

    void Start()
    {
        // Guardar las posiciones y rotaciones iniciales de los enemigos
        initialEnemyPositions = new Vector3[enemies.Length];
        initialEnemyRotations = new Quaternion[enemies.Length];
        enemyRigidbodies = new Rigidbody[enemies.Length];

        for (int i = 0; i < enemies.Length; i++)
        {
            initialEnemyPositions[i] = enemies[i].transform.position;
            initialEnemyRotations[i] = enemies[i].transform.rotation;
            enemyRigidbodies[i] = enemies[i].GetComponent<Rigidbody>();
        }

        // Asegúrate de que la puntuación se muestra al inicio
        UpdateScoreUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Si el escudo colisiona con un enemigo
            Destroy(other.gameObject); // Destruir al enemigo
            score++; // Aumentar la puntuación
            UpdateScoreUI(); // Actualizar la UI de la puntuación
        }
        else if (other.CompareTag("Bubble"))
        {
            // Si la burbuja colisiona con un enemigo
            ResetGame(); // Reiniciar el juego
        }
    }

    private void ResetGame()
    {
        // Reiniciar posición y rotación de los enemigos
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].transform.position = initialEnemyPositions[i];
            enemies[i].transform.rotation = initialEnemyRotations[i];

            if (enemyRigidbodies[i] != null)
            {
                enemyRigidbodies[i].linearVelocity = Vector3.zero; // Reiniciar la velocidad lineal
                enemyRigidbodies[i].angularVelocity = Vector3.zero; // Reiniciar la rotación
            }
        }

        

        // **Reiniciar la puntuación a cero** (esto es lo que hace que pierdas el puntaje)
        score = 0;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        // Actualizar la UI de la puntuación
        if (scoreText != null)
        {
            scoreText.text = "Puntuación: " + score.ToString(); // Mostrar la puntuación en la UI
        }
    }
}


