using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefabs; // Lista de prefabs de itens que podem ser spawnados
    public Transform spawnPoint;  // O ponto onde os itens serão spawnados

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnRandomItem();
            Destroy(gameObject);
        }
    }

    void SpawnRandomItem()
    {
        int randomIndex = Random.Range(0, itemPrefabs.Length);
        Instantiate(itemPrefabs[randomIndex], spawnPoint.position, spawnPoint.rotation);
    }
}
