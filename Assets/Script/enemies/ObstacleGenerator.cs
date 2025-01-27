using UnityEngine;

public class ObstacleGenerator : MonoBehaviour {

    [Header("References Settings")]
    public GameObject obstacleType1; // Prefab del misil
    public GameObject obstacleType2; // Prefab del misil
    public GameObject obstacleType3; // Prefab del misil
    public GameObject obstacleType4; // Prefab del misil

    [Header("Spawn Settings")]
    public float speedDown = 0.1f; // Velocidad de caída
    public float stepsSpeed = 0.1f; // Velocidad de incremento de la velocidad
    public float rateGenerate = 2f; // Intervalo entre disparos (en segundos)
    public float lifetime = 15f; // Tiempo antes de que el obstáculo se destruya automáticamente
    private float nextFireTime = 0f; // Control del tiempo de disparo
    private Vector3 spawnPoint; // Punto de generación del misil

    void Update() {
        // Comprobar si es momento de disparar
        if (Time.time >= nextFireTime) {
            SpawnObstacle();
            nextFireTime = Time.time + rateGenerate;
        }
    }

    private void UpdateSpawnPoint() {
        // Actualizar el punto de generación
        var randX = Random.Range(-4f, 4f);
        spawnPoint = new Vector3(randX, 14f, 0f);
    }

    private void SpawnObstacle() {

        UpdateSpawnPoint();
        GameObject obstacleType = null;

        int type = Random.Range(1, 4);
        Debug.Log("Type: " + type);
        switch (type) {
            case 1:
                obstacleType = obstacleType1;
                break;
            case 2:
                obstacleType = obstacleType2;
                break;
            case 3:
                obstacleType = obstacleType3;
                break;
            case 4:
                obstacleType = obstacleType4;
                break;    
        }

        GameObject obstacle = Instantiate(obstacleType, spawnPoint, Quaternion.identity);
        obstacle.tag = "Enemy";
        
        ObstacleFall obstacleFall = obstacle.GetComponent<ObstacleFall>();
        obstacleFall.FallDown(speedDown, lifetime);

        // Incrementar la velocidad de caída
        speedDown += stepsSpeed;
        if (lifetime > 5f) {
            lifetime -= stepsSpeed;
        }
    }
}
