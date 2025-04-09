using UnityEngine;

public class ShooterMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float movimiento = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            movimiento = 1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movimiento = -1f;
        }

        Vector3 velocidadActual = rb.velocity;
        rb.velocity = new Vector3(velocidadActual.x, velocidadActual.y, movimiento * speed);
    }
}
