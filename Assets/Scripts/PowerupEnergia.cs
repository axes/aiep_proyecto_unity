using UnityEngine;

public class PowerupEnergia : MonoBehaviour
{
    public float cantidadEnergia = 20f;
    public GameObject efectoExplosion; // ← este lo asignas desde el editor

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            EnergiaController energia = FindAnyObjectByType<EnergiaController>();
            if (energia != null)
            {
                energia.BajarEnergia(-cantidadEnergia);
            }

            // Instanciar la explosión en la posición visual del powerup
            Instantiate(efectoExplosion, transform.position, Quaternion.identity);

            // Destruir el padre completo del powerup
            Destroy(transform.parent.gameObject);
        }
    }
}
