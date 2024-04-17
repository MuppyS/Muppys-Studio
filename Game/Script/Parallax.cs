using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform[] backgrounds; // Lista das camadas de fundo a serem movidas
    public float[] parallaxScales; // A propor��o do movimento dos objetos

    public float smoothing = 1f; // Qu�o suave ser� o movimento

    private Vector3 previousCameraPosition; // A posi��o da c�mera no frame anterior

    private void Start()
    {
        // A posi��o da c�mera no in�cio do jogo
        previousCameraPosition = transform.position;
    }

    private void Update()
    {
        // Para cada camada de fundo
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // A paralaxe � o oposto do movimento da c�mera multiplicado pela escala
            float parallax = (previousCameraPosition.x - transform.position.x) * parallaxScales[i];

            // Define uma posi��o alvo x que � a posi��o atual mais a paralaxe
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            // Cria uma posi��o alvo que � a posi��o atual da camada de fundo com sua posi��o alvo x
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            // Suaviza o movimento usando Lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        // Define a posi��o da c�mera do frame anterior para a posi��o da c�mera atual
        previousCameraPosition = transform.position;
    }
}
