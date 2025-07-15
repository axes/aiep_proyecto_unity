using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float tiempo = 0.5f;

    void Start()
    {
        Destroy(gameObject, tiempo);
    }
}