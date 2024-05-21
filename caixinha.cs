using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class caixinha : MonoBehaviour
{
    public GameObject[] arGo;

    public GameObject parent;
    public float timeToSpawn = 2;
    public float minTime = 0;
    public float maxTime = 5;

    BoxCollider2D collider;
    float width;
    float height;

    private void Start()
    {
        collider = parent.GetComponent<BoxCollider2D>();

        width = collider.bounds.size.x / 2;
        height = collider.bounds.size.y / 2;

        //InvokeRepeating("EscrevaNoConsole", 0, timeToSpawn);
        Invoke("IntancieObjeto", 2);
    }

    private void IntancieObjeto()
    {
        float xPos = Random.Range(-width, width) + parent.transform.position.x;
        float yPos = Random.Range(-height, height) + parent.transform.position.y;

        int index = Random.Range(0, arGo.Length);
        Vector2 pos = new Vector2(xPos, yPos);
        Instantiate(arGo[index], pos, Quaternion.identity, parent.transform);

        timeToSpawn = Random.Range(minTime, maxTime);
        Invoke("IntancieObjeto", timeToSpawn);
    }
}
