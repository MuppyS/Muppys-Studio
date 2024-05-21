using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class automove: MonoBehaviour
{
    public float speed = 5f;
    public Vector2 movedirection = Vector2.right;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(movedirection * speed *Time.deltaTime);
    }
}