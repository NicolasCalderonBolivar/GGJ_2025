using UnityEngine;

public class OrbitarEsfera : MonoBehaviour {

    public Transform objetCenter; // Referencia al objeto al que orbita
    public float velocidadAngular = 240f; // Velocidad de la órbita en grados por segundo
    public float radio = .1f; // Radio de la órbita
    public float velocidad = 1f; // Velocidad de la órbita en grados por segundo

    private float angulo; // Ángulo actual de la órbita

    void Start() {
        // Inicializa el ángulo a 0
        angulo = 0f;

        // Obtener transform del padre
        objetCenter = objetCenter == null ? transform.parent : objetCenter;
    }

    void Update() {

        bool isMovingLeft = Input.GetKey(KeyCode.LeftArrow);
        bool isMovingRight = Input.GetKey(KeyCode.RightArrow);

        if ((isMovingLeft && isMovingRight) || (!isMovingLeft && !isMovingRight)) {
            velocidad = 0f;
            return;
        }

        velocidad = isMovingLeft ? 1f : -1f;
        move();

        // float input_scroll_wheel = Input.GetAxis("Mouse ScrollWheel");
        // if (input_scroll_wheel != 0) {
        //     velocidadAngular = input_scroll_wheel < 0 ? -90f : 90f;
        //     move();
        // }
    }

    void move() {

        // Incrementa el ángulo basándose en el tiempo y la velocidad angular
        angulo += velocidad * velocidadAngular * Time.deltaTime;

        // Convierte el ángulo de grados a radianes
        float anguloEnRadianes = Mathf.Deg2Rad * angulo;

        // Calcula la nueva posición orbital
        float x = objetCenter.position.x + Mathf.Cos(anguloEnRadianes) * radio;
        float y = objetCenter.position.y + Mathf.Sin(anguloEnRadianes) * radio;
        float z = transform.position.z;

        // Asigna la nueva posición
        transform.position = new Vector3(x, y, z);

        // Opcional: Apunta hacia el objeto central mientras órbita (gira en xy)
        transform.rotation = Quaternion.Euler(0, 0, angulo - 90f);
    }
}