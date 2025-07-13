using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float jumpForce = 10f;
    public float superJumpForce = 15f;

    public float fallMultiplier = 2f;
    public float superFallMultiplier = 2f;
    public float lowJumpMultiplier = 5f;

    public bool superJump = false;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private Animator animator;

[SerializeField] private Transform spriteTransform; // Referencia al hijo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();

    }

    void Update()
    {
        float moveInput = 0f;
        if (Input.GetKey(KeyCode.A)) moveInput = -1f;
        if (Input.GetKey(KeyCode.D)) moveInput = 1f;

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        CheckGround();       

        // Salto   
        // Saltar con fuerza distinta según modo
        if (Input.GetKeyDown(KeyCode.J) && isGrounded)
        {
            float force = superJump ? superJumpForce : jumpForce;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, force);
            animator.SetTrigger("jumpStart");
        }

        // Solo mientras está en el aire
        if (!isGrounded)
        {
            if (rb.linearVelocity.y < 0)
            {
                // Aplica caída acelerada
                float multiplier = superJump ? superFallMultiplier : fallMultiplier;
                rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (multiplier - 1f) * Time.deltaTime;
            }
            else if (!superJump && rb.linearVelocity.y > 0 && !Input.GetKey(KeyCode.J))
            {
                // Aplica salto más corto si NO es superJump y soltó la tecla
                rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1f) * Time.deltaTime;
            }
            // Si es superJump y aún está presionando J → no se modifica gravedad
        }

        // Flip solo en sprite
        if (moveInput < 0)
        {
            spriteTransform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (moveInput > 0)
        {
            spriteTransform.localScale = new Vector3(1f, 1f, 1f);
        }

        // Transiciones entre movimientos
        bool isMoving = Mathf.Abs(moveInput) > 0.01f;
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isJumping", !isGrounded);
        // Detectar caída
        bool isFalling = rb.linearVelocity.y < -0.1f && !isGrounded;
        bool isJumping = !isGrounded;
        
        animator.SetBool("isJumping", isJumping);
        animator.SetBool("isFalling", isFalling);


    }

[SerializeField] private Transform groundCheck;
[SerializeField] private float checkRadius = 0.05f;
[SerializeField] private LayerMask groundLayer;

    private void CheckGround()
    {
    isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    // Dibujo visual del círculo
    Debug.DrawRay(groundCheck.position, Vector3.down * checkRadius, Color.green);
    }

    // Se utiliza Raycast para detectar el suelo
    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Ground"))
    //     {
    //         isGrounded = true;
    //     }
    // }

    // void OnCollisionExit2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Ground"))
    //     {
    //         isGrounded = false;
    //     }
    // }
}
