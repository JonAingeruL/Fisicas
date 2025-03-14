using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    public float gravity = 20f; // Intensidad de la gravedad
    public float mouseSensitivity = 2f; // Sensibilidad del mouse

    private CharacterController controller; // Referencia al CharacterController
    private Transform cameraTransform; // Referencia a la cámara

    private float rotationX = 0f; // Controla la rotación vertical de la cámara
    private Vector3 velocity; // Maneja el movimiento del jugador

    void Start()
    {
        controller = GetComponent<CharacterController>(); // Obtenemos el CharacterController
        cameraTransform = Camera.main.transform; // Obtenemos la referencia de la cámara principal

        // Bloqueamos el cursor para que no se mueva de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Movimiento del jugador (WASD o teclas de dirección)
        float moveX = Input.GetAxis("Horizontal"); // Movimiento horizontal
        float moveZ = Input.GetAxis("Vertical"); // Movimiento hacia adelante y atrás
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime); // Aplicar movimiento al CharacterController

        // GRAVEDAD
        if (controller.isGrounded) // Si está en el suelo
        {
            velocity.y = -1f; // Restablecemos la gravedad
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime; // Aplica gravedad si está en el aire
        }

        controller.Move(velocity * Time.deltaTime); // Aplica la gravedad al movimiento

        // ROTACIÓN DE LA CÁMARA (Arriba/Abajo)
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity; // Movimiento vertical del ratón
        rotationX -= mouseY; // Restamos el valor de mouseY para que se mueva hacia arriba
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Limitamos para evitar rotaciones excesivas
        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0f, 0f); // Rotación de la cámara

        // ROTACIÓN DEL JUGADOR (Izquierda/Derecha)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity; // Movimiento horizontal del ratón
        transform.Rotate(Vector3.up * mouseX); // Rotación del jugador en el eje Y (horizontal)
    }
}
