using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool activado = false;
    private SpriteRenderer spriteRenderer;
    private Animator anim;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        anim.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !activado)
        {
            activado = true;
            anim.enabled = true;
            GameManager.Instance.SetCheckpoint(transform.position);
        }
    }
}
