using UnityEngine;

public class MissileLauncher : MonoBehaviour {

    [Header("Missile Settings")]
    public GameObject missilePrefab; // Prefab del misil
    public Transform bubble; // Referencia al objeto burbuja
    public float missileSpeed = 10f; // Velocidad del misil
    public float fireRate = 2f; // Intervalo entre disparos (en segundos)

    [Header("Spawn Settings")]
    public Transform spawnPoint; // Punto de generación del misil
    public float missileLifetime = 10f; // Tiempo antes de que el misil se destruya automáticamente
    private float nextFireTime = 0f; // Control del tiempo de disparo

    void Update() {
        // Comprobar si es momento de disparar
        if (Time.time >= nextFireTime) {
            FireMissile();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void updateSpawnPoint() {
        // Actualizar el punto de generación del misil
        if (bubble != null) {
            
            var randX = Random.Range(-1f, 1f);
            randX = randX > 0 ? 5f : -5f;

            var randY = Random.Range(0, 6f) + 1f;

            spawnPoint.position = bubble.position + new Vector3(randX, randY, 0f);
        }
    }

    private void FireMissile() {

        if (missilePrefab != null && bubble != null && spawnPoint != null) {

            // Instanciar el misil en el punto de generación
            updateSpawnPoint();
            GameObject missile = Instantiate(missilePrefab, spawnPoint.position, Quaternion.identity);

            // Obtener el componente Missile y configurarlo
            Missile missileScript = missile.GetComponent<Missile>();
            if (missileScript != null) {
                missileScript.shoot(bubble, missileSpeed / 10, missileLifetime);
            } else {
                Debug.LogError("El prefab del misil no tiene el script 'Missile'.");
            }
        }
    }
}
