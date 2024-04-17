using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto que entrou na zona de destrui��o tem a tag "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the kill zone.");
            // Destroi o objeto que tem a tag "Player"
            Destroy(other.gameObject);
            Debug.Log("Player destroyed.");
        }
    }
}
