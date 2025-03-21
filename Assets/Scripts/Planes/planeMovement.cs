using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    public float velocidad = 5f;  // Velocidad de movimiento
    public float alturaFija = 5f; // Altura en la que se mantiene el objeto

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Desactivar gravedad
        rb.constraints = RigidbodyConstraints.FreezePositionY; // Congelar en altura
    }

    void Update()
    {
        // Mover en el eje X (hacia la derecha)
        rb.velocity = new Vector3(-velocidad, 0, 0);
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("¡Colisión con: " + other.gameObject.name);
    }
}


