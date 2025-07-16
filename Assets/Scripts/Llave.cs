using UnityEngine;

public class Llave : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory.hasKey = true;
            Debug.Log("Llave recogida: " + PlayerInventory.hasKey);
            Destroy(gameObject);
        }
    }
}
