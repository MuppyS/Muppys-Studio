using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPU : MonoBehaviour
{
    public float increase = 2f;
    public float duration = 5;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")    
        {
            GameObject player = collision.gameObject;
            Player playerScript = player.GetComponent<Player>();
            
            if (playerScript)
            {
                playerScript.Speed += increase;

                Destroy(gameObject);
            }
        }
    }
}
