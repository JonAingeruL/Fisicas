using UnityEngine;

public class MovimientoRecto : MonoBehaviour
{
    public float velocidad = 10f; // Velocidad del movimiento

    void Update()
    {
        transform.position -= Vector3.right * velocidad * Time.deltaTime;
    }
}

