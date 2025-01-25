using UnityEngine;

public class OrbitarEsfera : MonoBehaviour
{
    public Transform esfera; // Referencia al objeto de la esfera
    public float velocidadAngular = 50f; // Velocidad de la órbita en grados por segundo
    public float radio = 5f; // Radio de la órbita

    private float angulo; // Ángulo actual de la órbita

    void Start()
    {
        // Inicializa el ángulo a 0
        angulo = 0f;
    }

    void Update()
    {
        // Incrementa el ángulo basándose en el tiempo y la velocidad angular
        angulo += velocidadAngular * Time.deltaTime;

        // Convierte el ángulo de grados a radianes
        float anguloEnRadianes = Mathf.Deg2Rad * angulo;

        // Calcula la nueva posición orbital
        float x = esfera.position.x + Mathf.Cos(anguloEnRadianes) * radio;
        float z = esfera.position.z + Mathf.Sin(anguloEnRadianes) * radio;
        float y = transform.position.y; // Mantén la altura fija si no necesitas órbitas en 3D

        // Asigna la nueva posición
        transform.position = new Vector3(x, y, z);

        // Opcional: Apunta hacia la esfera mientras órbita
        transform.LookAt(esfera);
    }
}