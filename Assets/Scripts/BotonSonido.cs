using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BotonSonido : MonoBehaviour
{
    public AudioClip sonidoClick;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ReproducirSonido);
    }

    void ReproducirSonido()
    {
        if (sonidoClick != null)
        {
            audioSource.PlayOneShot(sonidoClick);
        }
    }
}
