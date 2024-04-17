using UnityEngine;

public class CanBraw : MonoBehaviour
{
    public float minZoom = 5f; // Zoom m�nimo
    public float maxZoom = 10f; // Zoom m�ximo
    public float zoomSpeed = 5f; // Velocidade de ajuste do zoom

    [SerializeField] private Transform target1; // Player 1
    [SerializeField] private Transform target2; // Player 2

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (target1 != null && target2 != null)
        {
            // Calcula a dist�ncia entre os alvos
            float distance = Vector3.Distance(target1.position, target2.position);

            // Calcula o tamanho de zoom com base na dist�ncia entre os alvos
            float targetZoom = Mathf.Lerp(maxZoom, minZoom, distance / maxZoom);

            // Atualiza o tamanho da c�mera com uma interpola��o suave
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomSpeed);

            // Calcula a posi��o m�dia entre os alvos
            Vector3 targetMidPoint = (target1.position + target2.position) / 2f;
            transform.position = new Vector3(targetMidPoint.x, targetMidPoint.y, transform.position.z);
        }
        else if (target1 != null)
        {
            transform.position = new Vector3(target1.position.x, target1.position.y, transform.position.z);
        }
        else if (target2 != null)
        {
            transform.position = new Vector3(target2.position.x, target2.position.y, transform.position.z);
        }
    }
}
