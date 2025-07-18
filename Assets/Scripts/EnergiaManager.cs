using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnergiaController : MonoBehaviour
{
    public Slider energiaSlider;
    // public Slider energiaSliderCustom; // Barra personalizada (opcional)
    public float energiaMaxima = 100f;
    public float energiaActual;
    public float velocidadAgotamiento = 5f;

    public AudioClip sonidoMuerte;


    // agregar sprite de personaje para cambiar su alfa
    // y que se vea como si se estuviera agotando
     public SpriteRenderer personaje;

    void Start()
    {
        energiaActual = energiaMaxima;

        energiaSlider.maxValue = energiaMaxima;
        energiaSlider.value = energiaActual;

            // Barras personalizadas
            // energiaSliderCustom.maxValue = energiaMaxima;
            // energiaSliderCustom.value = energiaActual;
    }

    void Update()
    {
        energiaActual -= velocidadAgotamiento * Time.deltaTime;
        energiaSlider.value = energiaActual;

        // energiaSliderCustom.value = energiaActual;

        if (energiaActual <= 0)
        {
            ReiniciarNivel();
        }

        // Cambiar color según energía restante
        UpdateColor(energiaSlider);
        // UpdateColor(energiaSliderCustom);

        // Reducir el alfa del personaje para que vaya desapareciendo
        SpriteRenderer sr = personaje.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            float alpha = Mathf.Clamp01(energiaActual / energiaMaxima);
            Color color = sr.color;
            color.a = alpha;
            sr.color = color;
        }

    }

    public void BajarEnergia(float cantidad)
    {
        energiaActual -= cantidad;
        energiaSlider.value = energiaActual;
    }

public void ReiniciarEnergia()
{
    energiaActual = energiaMaxima;
    energiaSlider.value = energiaActual;

    // Restaurar visibilidad del personaje
    if (personaje != null)
    {
        Color color = personaje.color;
        color.a = 1f;
        personaje.color = color;
    }
}

    void ReiniciarNivel()
    {
        if (sonidoMuerte != null)
        {
            AudioSource.PlayClipAtPoint(sonidoMuerte, transform.position);
        }

        GameObject jugador = GameObject.FindWithTag("Player");

            if (jugador != null)
            {
                FadeController.Instance.FadeToBlackThenRespawn(jugador);
            }
            else
            {
                Debug.LogError("No se encontró el jugador con tag Player.");
            }
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UpdateColor(Slider s)
    {
        Image fill = s.fillRect.GetComponent<Image>();

        if (energiaActual / energiaMaxima > 0.6f)
            fill.color = Color.green;
        else if (energiaActual / energiaMaxima > 0.3f)
            fill.color = Color.yellow;
        else
            fill.color = Color.red;
    }
}
