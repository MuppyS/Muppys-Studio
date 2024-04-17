using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifique se o objeto que colidiu com o item é o jogador
        if (other.CompareTag("Player"))
        {
            Debug.Log("Item tocado pelo jogador."); // Adicione uma mensagem de log para depuração

            // Referência ao componente LifeSystem do jogador (supondo que o jogador tenha um componente LifeSystem)
            LifeSystem playerLife = other.GetComponent<LifeSystem>();

            if (playerLife != null)
            {
                // Realize a ação desejada, como curar o jogador
                playerLife.Heal(10); // Exemplo: cura o jogador em 10 unidades

                // Destrua o item após realizar a função desejada
                Destroy(gameObject);
            }

            // Não precisamos mais atualizar a barra de vida do jogador aqui
            // A barra de vida será atualizada automaticamente pelo LifeSystem
        }
    }
}
