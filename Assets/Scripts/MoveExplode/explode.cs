using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Verifica si la c�psula ha tocado el cubo
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); // Destruye el cubo
        }
    }
}
