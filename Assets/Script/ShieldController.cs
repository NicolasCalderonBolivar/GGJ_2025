using UnityEngine;
using UnityEngine.UI; // Necesario para el uso de UI

public class ShieldController : MonoBehaviour {

    public GameObject[] enemies; // Array de enemigos en la escena
    private Vector3[] initialEnemyPositions; // Posiciones iniciales de los enemigos
    private Quaternion[] initialEnemyRotations; // Rotaciones iniciales de los enemigos
    private Rigidbody[] enemyRigidbodies; // Almacena los Rigidbody de los enemigos

    public int score = 0; // Puntuación del jugador
    public Text scoreText; // Referencia al objeto Text en UI para mostrar la puntuación

    [Header("Player Settings")]
    public GameObject player; // Referencia al jugador
    public GameObject gameOverUI;     // Referencia al panel de "GAME OVER" y los botones

    void Start() {

        if (player == null) {
            // player = GameObject.FindWithTag("Player"); // Buscar el jugador por etiqueta
            player = GameObject.FindWithTag("Bubble"); // Buscar el jugador por etiqueta
        }

        // Guardar las posiciones y rotaciones iniciales de los enemigos
        initialEnemyPositions = new Vector3[enemies.Length];
        initialEnemyRotations = new Quaternion[enemies.Length];
        enemyRigidbodies = new Rigidbody[enemies.Length];

        for (int i = 0; i < enemies.Length; i++) {
            initialEnemyPositions[i] = enemies[i].transform.position;
            initialEnemyRotations[i] = enemies[i].transform.rotation;
            enemyRigidbodies[i] = enemies[i].GetComponent<Rigidbody>();
        }

        // Asegúrate de que la puntuación se muestra al inicio
        UpdateScoreUI();
    }

    private void Update() {
        // seguir al jugador
        transform.position = player.transform.position;
        UpdateScore();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")){
            // Si el escudo colisiona con un enemigo
            Destroy(other.gameObject); // Destruir al enemigo
            // score++; // Aumentar la puntuación
            // UpdateScoreUI(); // Actualizar la UI de la puntuación
        }
        else if (other.CompareTag("Obstacle"))
        {
            // Si la burbuja colisiona con un enemigo
            GameOver(); // Reiniciar el juego
        }
    }

    // private void ResetGame()
    // {

    //     // Reiniciar posición y rotación de los enemigos
    //     for (int i = 0; i < enemies.Length; i++)
    //     {
    //         enemies[i].transform.position = initialEnemyPositions[i];
    //         enemies[i].transform.rotation = initialEnemyRotations[i];

    //         if (enemyRigidbodies[i] != null)
    //         {
    //             enemyRigidbodies[i].linearVelocity = Vector3.zero; // Reiniciar la velocidad lineal
    //             enemyRigidbodies[i].angularVelocity = Vector3.zero; // Reiniciar la rotación
    //         }
    //     }

    //     // **Reiniciar la puntuación a cero** (esto es lo que hace que pierdas el puntaje)
    //     score = 0;
    //     UpdateScoreUI();

        
    // }

    public void GameOver() {
        // Mostrar el mensaje de GAME OVER y los botones
        Debug.Log("GAME OVER");
        if (gameOverUI != null) {
            Debug.Log("Activando menu de Game Over");
            gameOverUI.SetActive(true);  // Activa la UI de Game Over
        }

        Debug.Log("Pausando juego");
        // Opcional: detener el tiempo del juego
        Time.timeScale = 0f;
    }

    private void UpdateScore() {

        if (Time.timeScale == 0) {
            return;
        }
        
        // Actualizar la puntuación
        score += 1;
        UpdateScoreUI();
    }

    private void UpdateScoreUI() {
        // Actualizar la UI de la puntuación
        if (scoreText != null) {
            // Mostrar la puntuación en la UI
            scoreText.text = "P " + score.ToString();
        }
    }
}


