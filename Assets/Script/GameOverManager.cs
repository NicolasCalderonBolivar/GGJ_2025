using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void RestartGame()
    {
        // Reinicia el nivel actual
        Time.timeScale = 1f; // Asegúrate de reactivar el tiempo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        // Salir del juego (no funciona en el editor)
        Application.Quit();
        Debug.Log("El juego se ha cerrado."); // Para pruebas en el editor
    }
}
