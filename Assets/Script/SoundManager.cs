using UnityEngine;

public class SoundManager : MonoBehaviour {
    
    public AudioSource audioSource; // Asigna el Audio Source desde el Inspector
    public AudioClip moveClip; // Arrastra el clip de movimiento al Inspector
    public PlayerControls playerControls; // Referencia al script de control del jugador

    private bool isPlaying = false; // Controla si el sonido está reproduciéndose

    void Start() {

        // Configura el clip de audio
        if (audioSource != null) {
            audioSource.clip = moveClip;
            audioSource.loop = true; // Hacemos que el sonido se repita mientras se mueva
        }

        // Validación de la referencia a PlayerControls
        if (playerControls == null) {
            Debug.LogError("PlayerControls no asignado en SoundManager.");
        }
    }

    void Update() {

        if (playerControls == null) {
            Debug.LogError("PlayerControls no asignado en SoundManager.");
            return;
        }

        Vector3 velocity = playerControls.GetPlayerVelocity(); // Obtenemos la velocidad del jugador
        bool isMoving = velocity.magnitude > 0.1f; // Detecta si hay movimiento significativo

        if (isMoving && !isPlaying) {
            // Inicia el sonido si el personaje se está moviendo y el sonido no está activo
            audioSource.Play();
            isPlaying = true;
            return;
        }
        
        if (!isMoving && isPlaying) {
            // Detén el sonido si el personaje deja de moverse
            audioSource.Stop();
            isPlaying = false;
            return;
        }

        // Revisar si el tiempo de ejecucion esta activo
        if (Time.timeScale == 0f && isPlaying) {
            audioSource.Stop();
            isPlaying = false;
        }
    }
}
