using UnityEngine;

public class Flotar : MonoBehaviour
{
    public float velocidad = 2f;
    public float altura = 0.2f;
    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.localPosition;
    }

    void Update()
    {
        transform.localPosition = posicionInicial + Vector3.up * Mathf.Sin(Time.time * velocidad) * altura;
    }
}
