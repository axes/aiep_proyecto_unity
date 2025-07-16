using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class HistoriaController : MonoBehaviour
{
        public AudioClip sonidoClick;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }


    public void VolverAlMenu()
    {
        StartCoroutine(CargarMenuConRetraso());
    }

    IEnumerator CargarMenuConRetraso()
    {
        audioSource.PlayOneShot(sonidoClick);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MenuInicial");
    }
 
  

    // Update is called once per frame
    void Update()
    {
        
    }
}
