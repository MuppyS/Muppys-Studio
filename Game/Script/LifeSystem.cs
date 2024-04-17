using UnityEngine;
using System.Collections;

public class LifeSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public Color damageColor = Color.red;
    public float damageFlashDuration = 0.1f;
    public float damageCooldown = 0.5f;
    private bool isDamaged = false;

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void TakeDamage(int damage)
    {
        if (!isDamaged)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Die();
            }
            else
            {
                // Inicia o flash de dano
                StartCoroutine(DamageFlash());
            }
        }
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth); // Garante que a saúde não exceda o máximo
    }

    void Die()
    {
        // Destroi o GameObject do jogador
        Destroy(gameObject);
    }

    IEnumerator DamageFlash()
    {
        isDamaged = true;
        spriteRenderer.color = damageColor;
        yield return new WaitForSeconds(damageFlashDuration);
        spriteRenderer.color = originalColor;
        yield return new WaitForSeconds(damageCooldown);
        isDamaged = false;
    }
}
