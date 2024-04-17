using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    public int damage = 10;
    public float attackRange = 1f;
    public LayerMask playerLayer; // Renomeado de Player para evitar confusão

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on GameObject: " + gameObject.name);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Fire1 representa o botão esquerdo do mouse
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }
        else
        {
            Debug.LogWarning("Animator component not found.");
        }

        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(transform.position, attackRange, playerLayer);

        foreach (Collider2D player in hitPlayers)
        {
            if (player.gameObject != gameObject && player.gameObject.CompareTag("Player")) // Verifica se é outro jogador
            {
                LifeSystem playerLife = player.GetComponent<LifeSystem>();
                if (playerLife != null)
                {
                    playerLife.TakeDamage(damage);
                }
                else
                {
                    Debug.LogWarning("LifeSystem component not found on player: " + player.name);
                }

                Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();
                if (playerRB != null)
                {
                    Vector2 direction = player.transform.position - transform.position;
                    playerRB.AddForce(direction.normalized * 5f, ForceMode2D.Impulse);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
