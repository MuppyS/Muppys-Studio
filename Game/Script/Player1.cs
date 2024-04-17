using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;

    public Animator animator;

    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;

    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(8f, 16f);

    private bool doubleJump;
    private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    private bool canDoubleJump;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private ParticleSystem particles;

    private int playerLayer;
    private int platformLayer;

    private bool isConfused = false;
    private float confusionDuration = 3f;
    private float originalSpeed;

    void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
        platformLayer = LayerMask.NameToLayer("Platform");
        originalSpeed = speed;
        animator.SetBool("isDashing", false); // Certifica-se de que o parâmetro isDashing no Animator começa como false.
    }

    void Update()
    {
        if (isDashing)
            return;

        horizontal = Input.GetAxisRaw("Horizontal");

        if (isGrounded())
        {
            canDoubleJump = true;
            doubleJump = false;
            animator.SetBool("isJumping", false);
            animator.SetBool("isDoubleJumping", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded())
                Jump();
            else if (isWallSliding)
                WallJump();
            else if (canDoubleJump)
                DoubleJump();
        }

        WallSlide();

        if (!isWallJumping)
            Flip();

        if (Input.GetButtonDown("Fire3") && canDash)
            StartCoroutine(Dash());

        animator.SetBool("Run", Mathf.Abs(horizontal) > 0);
        animator.SetBool("isWallSliding", isWallSliding);

        if (isConfused)
        {
            // Implemente a lógica de controle confuso aqui, se necessário
        }
    }

    private IEnumerator EnableCollisionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, false);
    }

    private void FixedUpdate()
    {
        if (isDashing)
            return;

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (!isGrounded() && rb.velocity.y < 0 && !isWallSliding)
            rb.velocity += Vector2.up * Physics2D.gravity.y * (wallSlidingSpeed - 1) * Time.fixedDeltaTime;
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool isWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if (isWalled() && !isGrounded() && rb.velocity.y < 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, -wallSlidingSpeed);
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = true;
            wallJumpingDirection = isFacingRight ? 1 : -1;
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        animator.SetBool("isJumping", true);
    }

    private void DoubleJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        doubleJump = true;
        canDoubleJump = false;
        animator.SetBool("isJumping", true);
        animator.SetBool("isDoubleJumping", true);
    }

    private void Flip()
    {
        if (horizontal > 0 && !isFacingRight || horizontal < 0 && isFacingRight)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        animator.SetBool("isDashing", true); // Define o parâmetro isDashing no Animator como true quando começar a realizar o dash.
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.right.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        animator.SetBool("isDashing", false); // Define o parâmetro isDashing no Animator como false quando terminar o dash.
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    public void ConfuseControls()
    {
        isConfused = true;
        speed *= -1;
        StartCoroutine(ResetConfusion());
    }

    private IEnumerator ResetConfusion()
    {
        yield return new WaitForSeconds(confusionDuration);
        speed = Mathf.Abs(speed);
        isConfused = false;
    }

    public void ResetControls()
    {
        // Implemente aqui a lógica para redefinir os controles do jogador, se necessário
        // Este método será chamado para redefinir os controles após o tempo de confusão
    }
}
