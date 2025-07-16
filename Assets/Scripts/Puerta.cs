using UnityEngine;
using UnityEngine.SceneManagement;

public class Puerta : MonoBehaviour
{
    public string escenaDestino = "MenuInicial";

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Algo tocó la puerta: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador tocó la puerta. ¿Tiene llave? " + PlayerInventory.hasKey);

            if (PlayerInventory.hasKey)
            {
                SceneManager.LoadScene(escenaDestino);
            }
            else
            {
                Debug.Log("No tienes la llave todavía.");
            }
        }
    }
}
