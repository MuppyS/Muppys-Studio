using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public Vector2 minCameraPosition; // Posi��o m�nima da c�mera
    public Vector2 maxCameraPosition; // Posi��o m�xima da c�mera

    // Atualiza a posi��o da c�mera na cena
    void LateUpdate()
    {
        // Obt�m a posi��o atual da c�mera
        Vector3 clampedPosition = transform.position;

        // Limita a posi��o da c�mera horizontalmente
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minCameraPosition.x, maxCameraPosition.x);

        // Limita a posi��o da c�mera verticalmente
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minCameraPosition.y, maxCameraPosition.y);

        // Aplica a nova posi��o � c�mera
        transform.position = clampedPosition;
    }

    // Desenha os limites da c�mera na cena usando gizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        // Desenha as linhas verticais dos limites
        Gizmos.DrawLine(new Vector3(minCameraPosition.x, minCameraPosition.y), new Vector3(minCameraPosition.x, maxCameraPosition.y));
        Gizmos.DrawLine(new Vector3(maxCameraPosition.x, minCameraPosition.y), new Vector3(maxCameraPosition.x, maxCameraPosition.y));
        // Desenha as linhas horizontais dos limites
        Gizmos.DrawLine(new Vector3(minCameraPosition.x, minCameraPosition.y), new Vector3(maxCameraPosition.x, minCameraPosition.y));
        Gizmos.DrawLine(new Vector3(minCameraPosition.x, maxCameraPosition.y), new Vector3(maxCameraPosition.x, maxCameraPosition.y));
    }
}
