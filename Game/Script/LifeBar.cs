using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public LifeSystem lifeSystem; // Referência ao componente LifeSystem do jogador
    public Image lifeBar;
    private float maxLifeBar = 100f;

    void Start()
    {
        if (lifeSystem == null)
        {
            Debug.LogWarning("LifeSystem reference not set in LifeBar script!");
        }
    }

    void Update()
    {
        if (lifeSystem != null)
        {
            UpdateLifeBar(lifeSystem.currentHealth);
        }
    }

    // Atualiza a barra de vida com base na vida atual do jogador
    void UpdateLifeBar(int currentHealth)
    {
        lifeBar.fillAmount = (float)currentHealth / maxLifeBar;
    }
}
