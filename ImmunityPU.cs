using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmunityPU : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")    
        {
            GameObject player = collision.gameObject;
            Player playerScript = player.GetComponent<Player>();
            
            if (playerScript)
            {
                playerScript.cc.enabled = false;

                Destroy(gameObject);
            }
        }
    }
}
