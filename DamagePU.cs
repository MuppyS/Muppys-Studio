using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePU : MonoBehaviour
{
    public int increase = 2;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")    
        {
            GameObject player = collision.gameObject;
            Player playerScript = player.GetComponent<Player>();
            
            if (playerScript)
            {
                playerScript.damage += increase;

                Destroy(gameObject);
            }
        }
    }
}
