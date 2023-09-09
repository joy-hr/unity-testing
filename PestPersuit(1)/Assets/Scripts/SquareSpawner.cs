using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    public GameObject squarePrefab; // Square prefab to spawn
    public float spawnInterval = 1.0f; // Interval between spawns
    public float spawnRange = 5.0f; // Adjust this to set the range where squares will spawn.

    public Transform squareContainer; // Reference to the square container

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        // Start spawning squares
        StartCoroutine(SpawnSquares());
    }

    IEnumerator SpawnSquares()
    {
        while (true)
        {
            // Calculate a random X position within the specified range, considering margin
            float minX = mainCamera.ViewportToWorldPoint(new Vector3(0.1f, 0, 0)).x; // Adjust this value as needed
            float maxX = mainCamera.ViewportToWorldPoint(new Vector3(0.9f, 0, 0)).x; // Adjust this value as needed
            float randomX = Random.Range(minX, maxX);

            // Calculate the Y position to be just above the screen
            float randomY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1.1f, 0)).y;

            // Create a Vector2 for spawn position
            Vector2 randomSpawnPosition = new Vector2(randomX, randomY);
        
            // Instantiate the square prefab at the random position
            GameObject spawnedSquare = Instantiate(squarePrefab, randomSpawnPosition, Quaternion.identity, squareContainer.transform);

            // Attach a script to the spawned square to handle player clicks
            spawnedSquare.AddComponent<SquareClickHandler>();

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

