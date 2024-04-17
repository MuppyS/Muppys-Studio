using UnityEngine;

public class Trap : MonoBehaviour
{
    private bool isPlayerInside = false;

    // Tempo de dura��o dos controles bagun�ados
    public float confusedDuration = 3f;

    // Refer�ncia ao componente de controle do jogador
    private PlayerMovement playerController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInside = true;
            playerController = collision.gameObject.GetComponent<PlayerMovement>();

            // Bagun�a os controles do jogador
            if (playerController != null)
            {
                playerController.ConfuseControls();
                Invoke("ResetControls", confusedDuration);
            }

            // Destroi a armadilha
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInside = false;
        }
    }

    private void ResetControls()
    {
        // Reseta os controles do jogador ap�s o tempo de confus�o
        if (playerController != null && isPlayerInside)
        {
            playerController.ResetControls();
        }
    }
}
