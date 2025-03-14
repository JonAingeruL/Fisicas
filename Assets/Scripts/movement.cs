using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    public float gravity = 20f; // Intensidad de la gravedad
    public float mouseSensitivity = 2f; // Sensibilidad del mouse

    private CharacterController controller; // Referencia al CharacterController
    private Transform cameraTransform; // Referencia a la c�mara

    private float rotationX = 0f; // Controla la rotaci�n vertical de la c�mara
    private Vector3 velocity; // Maneja el movimiento del jugador

    void Start()
    {
        controller = GetComponent<CharacterController>(); // Obtenemos el CharacterController
        cameraTransform = Camera.main.transform; // Obtenemos la referencia de la c�mara principal

        // Bloqueamos el cursor para que no se mueva de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Movimiento del jugador (WASD o teclas de direcci�n)
        float moveX = Input.GetAxis("Horizontal"); // Movimiento horizontal
        float moveZ = Input.GetAxis("Vertical"); // Movimiento hacia adelante y atr�s
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime); // Aplicar movimiento al CharacterController

        // GRAVEDAD
        if (controller.isGrounded) // Si est� en el suelo
        {
            velocity.y = -1f; // Restablecemos la gravedad
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime; // Aplica gravedad si est� en el aire
        }

        controller.Move(velocity * Time.deltaTime); // Aplica la gravedad al movimiento

        // ROTACI�N DE LA C�MARA (Arriba/Abajo)
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity; // Movimiento vertical del rat�n
        rotationX -= mouseY; // Restamos el valor de mouseY para que se mueva hacia arriba
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Limitamos para evitar rotaciones excesivas
        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0f, 0f); // Rotaci�n de la c�mara

        // ROTACI�N DEL JUGADOR (Izquierda/Derecha)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity; // Movimiento horizontal del rat�n
        transform.Rotate(Vector3.up * mouseX); // Rotaci�n del jugador en el eje Y (horizontal)
    }
}
