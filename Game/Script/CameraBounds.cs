using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public Vector2 minCameraPosition; // Posição mínima da câmera
    public Vector2 maxCameraPosition; // Posição máxima da câmera

    // Atualiza a posição da câmera na cena
    void LateUpdate()
    {
        // Obtém a posição atual da câmera
        Vector3 clampedPosition = transform.position;

        // Limita a posição da câmera horizontalmente
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minCameraPosition.x, maxCameraPosition.x);

        // Limita a posição da câmera verticalmente
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minCameraPosition.y, maxCameraPosition.y);

        // Aplica a nova posição à câmera
        transform.position = clampedPosition;
    }

    // Desenha os limites da câmera na cena usando gizmos
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
