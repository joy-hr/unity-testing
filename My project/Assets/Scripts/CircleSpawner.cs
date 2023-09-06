using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    public GameObject circlePrefab; // Circle prefab to spawn
    public float spawnInterval = 1.0f; // Interval between spawns
    public float spawnRange = 5.0f; // Adjust this to set the range where circles will spawn.

    public Transform circleContainer; // Reference to the circle container

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        // Start spawning circles
        StartCoroutine(SpawnCircles());
    }

    IEnumerator SpawnCircles()
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

            // Check for overlaps with other circles
            Collider2D[] colliders = Physics2D.OverlapCircleAll(randomSpawnPosition, 0.5f, 1 << LayerMask.NameToLayer("Circles"));

            bool overlapDetected = false;

            foreach (Collider2D collider in colliders)
            {
                // If any circle is already at the spawn position, set overlapDetected to true
                if (collider.CompareTag("Circle") && collider.gameObject != null && collider.gameObject != gameObject)
                {
                    overlapDetected = true;
                    break;
                }
            }

            if (!overlapDetected)
            {
                // No overlap, spawn the circle
                GameObject spawnedCircle = Instantiate(circlePrefab, randomSpawnPosition, Quaternion.identity, circleContainer.transform);
                spawnedCircle.tag = "Circle"; // Assign the "Circle" tag to the spawned circle.
                spawnedCircle.layer = LayerMask.NameToLayer("Circles"); // Assign the "Circle" layer to the spawned circle.
                spawnedCircle.AddComponent<CircleClickHandler>();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
