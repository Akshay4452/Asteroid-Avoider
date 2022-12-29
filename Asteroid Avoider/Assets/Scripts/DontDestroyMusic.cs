using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyMusic : MonoBehaviour
{
    AudioSource audioSource;
    void Awake() 
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if(objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update() 
    {
       if(SceneManager.GetActiveScene().buildIndex == 2)
       {
            // build index = 2 stands for Game Scene
            Destroy(gameObject);
       }
    }
}
