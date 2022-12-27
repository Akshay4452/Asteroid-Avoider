using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject gameOverHandler;
    public void Crash()
    {
        gameObject.SetActive(false);
        gameOverHandler.SetActive(true);
    }

    private void Update() 
    {
        if(gameOverHandler == null)
        {
            Debug.LogError("Game Over Handler not found");
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameOverHandler.SetActive(true);
        }
    }
}
