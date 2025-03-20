using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    private Rigidbody rb; // Referencia al Rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtiene el Rigidbody
        rb.freezeRotation = true; // Evita que la cápsula se incline
    }

    void FixedUpdate()
    {
        // Obtener entrada de movimiento
        float moveX = Input.GetAxis("Horizontal"); // A (-1) y D (+1)
        float moveZ = Input.GetAxis("Vertical");   // W (+1) y S (-1)

        // Crear vector de movimiento
        Vector3 moveDirection = new Vector3(moveX, 0, moveZ).normalized;

        // Aplicar movimiento con Rigidbody
        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
    }
}

