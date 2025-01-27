using UnityEngine;

public class Missile : MonoBehaviour {

    private Transform target; // Referencia al objetivo (burbuja)
    private Rigidbody rb; // Referencia al Rigidbody del misil
    public float speed; // Velocidad del misil
    public float lifetime; // Tiempo de vida del misil

    private Vector3 direction;

    // Método público para inicializar el misil
    public void shoot(Transform target, float speed, float lifetime) {
        this.target = target;
        this.speed = speed;
        this.lifetime = lifetime;

        gameObject.SetActive(true);

        if (rb == null) {
            rb = GetComponent<Rigidbody>();
        }

        Debug.Log("Misil inicializado con éxito. (Objetivo: " + target.name + ")");

        // Destruir el misil automáticamente después de su tiempo de vida
        var randY = Random.Range(0f, .6f);
        direction = (target.position - transform.position).normalized + new Vector3(0, randY, 0);
        // Mover el misil hacia el objetivo
        rb.linearVelocity = direction * speed * 20f;

        Destroy(gameObject, lifetime);

    }
}
