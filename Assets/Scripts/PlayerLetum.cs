using UnityEngine;
using System.Collections;


public class PlayerLetum : MonoBehaviour
{
    private bool invulnerable = false;
    public float tiempoInvulnerable = 1f;
    public AudioClip sonidoDano;
    public AudioClip sonidoCaida;


    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10f)
        {
             if (sonidoCaida != null)
                AudioSource.PlayClipAtPoint(sonidoCaida, transform.position);

            FadeController.Instance.FadeToBlackThenRespawn(gameObject);
        }
    }

    public void RecibirDano(float cantidad)
    {
        EnergiaController energia = FindAnyObjectByType<EnergiaController>();
        if (energia != null)
        {
            energia.BajarEnergia(cantidad);
            if (sonidoDano != null)
            {
                AudioSource.PlayClipAtPoint(sonidoDano, transform.position);
            }
        }


        StartCoroutine(InvulnerabilidadTemporal());
    }

    private IEnumerator InvulnerabilidadTemporal()
    {
        invulnerable = true;

        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>(); // Asegúrate que apunte al sprite correcto
        float elapsed = 0f;
        float blinkInterval = 0.1f;

        while (elapsed < tiempoInvulnerable)
        {
            if (sr != null)
                sr.enabled = !sr.enabled;

            yield return new WaitForSeconds(blinkInterval);
            elapsed += blinkInterval;
        }

        if (sr != null)
            sr.enabled = true; // Asegura que termine visible

        invulnerable = false;
    }

    public bool EstaInvulnerable()
    {
        return invulnerable;
    }
}