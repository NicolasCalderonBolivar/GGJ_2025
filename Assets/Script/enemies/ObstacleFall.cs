using UnityEngine;

public class ObstacleFall : MonoBehaviour {

    // Metodo para hacer caer el obstaculo
    public void FallDown(float speed, float lifetime) {

        MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();
        meshCollider.convex = true;

        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        gameObject.SetActive(true);

        // Configurar gravedad
        rb.useGravity = false;
        rb.linearVelocity = new Vector3(0, -speed * 10, 0);

        // Configurar tiempo de vida
        Destroy(gameObject, lifetime);
    }
}
