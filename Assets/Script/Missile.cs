using UnityEngine;

public class Missile : MonoBehaviour
{
    private Transform target; // Referencia al objetivo (burbuja)
    private float speed; // Velocidad del misil
    private float lifetime; // Tiempo de vida del misil

    // Método público para inicializar el misil
    public void Initialize(Transform target, float speed, float lifetime)
    {
        this.target = target;
        this.speed = speed;
        this.lifetime = lifetime;

        // Destruir el misil automáticamente después de su tiempo de vida
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Si no hay objetivo, no hacemos nada
        if (target == null) return;

        // Mover el misil hacia el objetivo
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Orientar el misil hacia el objetivo
        transform.LookAt(target);
    }
}
