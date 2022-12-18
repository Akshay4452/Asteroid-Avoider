using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if(playerHealth == null)
        {
            return;
        }    
        else
        {
            playerHealth.Crash();
        }
    }
    private void OnBecameInvisible() 
    {
        // Built-in method to perform operation when gameobject becomes invisible
        Destroy(gameObject);
    }
}
