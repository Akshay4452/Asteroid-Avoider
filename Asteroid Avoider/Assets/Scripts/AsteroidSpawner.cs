using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroidPrefabs;
    [SerializeField] private float spawnRate = 1.5f;
    [SerializeField] private Vector2 forceRange;
    private float timer;
    private Camera mainCamera; // Instantiating main camera for viewport to world space conversion
    void Start() 
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            SpawnAsteroid();
            timer = spawnRate;
        }
    }
    private void SpawnAsteroid()
    {
        // side variable is for deciding side of Viewport rectangle [0,1,2,3] with 0 = y-axis, 2 = x-axis
        // Viewport rectangle is used for spawning asteroids from randomly selected sides
        int side = Random.Range(0,4);

        Vector2 spawnPoint = Vector2.zero;
        Vector2 direction = Vector2.zero;

        // Using switch statement to decide trajectory of asteroid according to its spawn location
        switch(side)
        {
            case 0:
                spawnPoint.x = 0;
                spawnPoint.y = Random.value; // Spawning at random height (between 0,1) on y-axis
                direction = new Vector2(1f, Random.Range(-1f, 1f));
                break;
            case 1:
                spawnPoint.x = Random.value; // Spawning at random location on x-axis between 0,1
                spawnPoint.y = 0;
                direction = new Vector2(Random.Range(-1f,1f) ,1f);
                break;
            case 2:
                spawnPoint.x = 1;
                spawnPoint.y = Random.value; // Spawning at random height (between 0,1) on y-axis
                direction = new Vector2(-1f, Random.Range(-1f, 1f));
                break;
            case 3:
                spawnPoint.x = Random.value; // Spawning at random location on x-axis between 0,1
                spawnPoint.y = 1;
                direction = new Vector2(Random.Range(-1f,1f) ,-1f);
                break;
        }

        Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint);
        worldSpawnPoint.z = 0;

        GameObject selectedAsteroid = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];

        //Picking random asteroid from array and instantiate it
        GameObject asteroidInstance = Instantiate(selectedAsteroid, 
                                                worldSpawnPoint, 
                                                Quaternion.Euler(0f,0f,Random.Range(0f,360f)));

        Rigidbody rb = asteroidInstance.GetComponent<Rigidbody>();

        rb.velocity = direction.normalized * Random.Range(forceRange.x, forceRange.y);
        // forceRange.x => min force, forceRange.y => max force 
    }
}
