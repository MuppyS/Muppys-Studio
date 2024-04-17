using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabs; // Array de prefabs para spawn
    public Vector2 spawnArea; // Área onde os prefabs serão spawnados
    public float spawnDelay = 1f; // Delay entre spawns
    public float spawnTimer = 0f;
    public float despawnDelay = 10f; // Tempo para despawn dos prefabs

    void Update()
    {
        // Controle do tempo entre os spawns
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnDelay)
        {
            SpawnRandomPrefab();
            spawnTimer = 0f;
        }
    }

    void SpawnRandomPrefab()
    {
        // Escolha aleatória de um prefab
        GameObject prefabToSpawn = prefabs[Random.Range(0, prefabs.Length)];

        // Posição de spawn baseada na posição do objeto SpawnManager
        Vector2 spawnPosition = transform.position;

        // Adiciona um deslocamento aleatório à posição de spawn para evitar spawn em cima uns dos outros
        spawnPosition += new Vector2(Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                                     Random.Range(-spawnArea.y / 2, spawnArea.y / 2));

        // Spawn do prefab na posição gerada
        GameObject spawnedPrefab = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

        // Destrói o prefab após um certo tempo
        Destroy(spawnedPrefab, despawnDelay);
    }
}
