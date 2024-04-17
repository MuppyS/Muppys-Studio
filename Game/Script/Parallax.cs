using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform[] backgrounds; // Lista das camadas de fundo a serem movidas
    public float[] parallaxScales; // A proporção do movimento dos objetos

    public float smoothing = 1f; // Quão suave será o movimento

    private Vector3 previousCameraPosition; // A posição da câmera no frame anterior

    private void Start()
    {
        // A posição da câmera no início do jogo
        previousCameraPosition = transform.position;
    }

    private void Update()
    {
        // Para cada camada de fundo
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // A paralaxe é o oposto do movimento da câmera multiplicado pela escala
            float parallax = (previousCameraPosition.x - transform.position.x) * parallaxScales[i];

            // Define uma posição alvo x que é a posição atual mais a paralaxe
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            // Cria uma posição alvo que é a posição atual da camada de fundo com sua posição alvo x
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            // Suaviza o movimento usando Lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        // Define a posição da câmera do frame anterior para a posição da câmera atual
        previousCameraPosition = transform.position;
    }
}
