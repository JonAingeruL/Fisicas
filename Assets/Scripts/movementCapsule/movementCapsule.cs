using UnityEngine;

public class MovimientoCapsula : MonoBehaviour
{
    public float fuerza = 10f;
    public float velocidadMovimiento = 5f;
    private Rigidbody rb;
    public bool enSuelo = true;

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimiento horizontal con WASD
        float movimientoX = Input.GetAxis("Horizontal") * velocidadMovimiento * Time.deltaTime;
        float movimientoZ = Input.GetAxis("Vertical") * velocidadMovimiento * Time.deltaTime;
        transform.Translate(new Vector3(movimientoX, 0, movimientoZ));

        // Salto (Con esto miro a ver si esta tocando el suelo para que no sale todo el rato)
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(Vector3.up * fuerza, ForceMode.Impulse);
            enSuelo = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //Y con esto compruebo que el objeto que sea con el tag Suelo si lo toca se active la variabel
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
            Debug.Log("La cápsula tocó el suelo");
        }
    }
}


