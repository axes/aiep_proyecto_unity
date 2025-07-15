using UnityEngine;

public class TrampaPuntas : MonoBehaviour
{
    public float dano = 25f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerLetum jugador = other.GetComponent<PlayerLetum>();
            if (jugador != null && !jugador.EstaInvulnerable())
            {
                jugador.RecibirDano(dano);
            }
        }
    }
}
