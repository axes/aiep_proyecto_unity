using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuInicial : MonoBehaviour
{
    public AudioClip sonidoClick;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    public void IrAJugar()
    {
        StartCoroutine(CargarJuegoConRetraso());
    }

    public void IrAHistoria()
    {
        StartCoroutine(CargarHistoriaConRetraso());
    }

    IEnumerator CargarJuegoConRetraso()
    {
        audioSource.PlayOneShot(sonidoClick); // 🔊 reproducir sonido
        yield return new WaitForSeconds(0.5f); // esperar para que suene bien
        SceneManager.LoadScene("Nivel1");
    }

    IEnumerator CargarHistoriaConRetraso()
    {
        audioSource.PlayOneShot(sonidoClick); // 🔊 reproducir sonido
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Historia");
    }

    public void Salir()
    {
        audioSource.PlayOneShot(sonidoClick); // 🔊 reproducir sonido (opcional)
        Debug.Log("Saliendo del juego...");
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
