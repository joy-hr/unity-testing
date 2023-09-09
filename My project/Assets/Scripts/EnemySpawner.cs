using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float _spawnTimer = 0;

    [Tooltip("The rate at which the enemies spawn in seconds")]
    [Min(0)]
    public float SpawnIntervalSeconds = 1;

    [Tooltip("The size of the gap between the enemies in pixels")]
    [Min(0)]
    public int GapOffset = 100;

    [Tooltip("The amount of columns to spawn from")]
    [Range(0, 4)]
    public int Columns = 4;

    public GameObject[] EnemyPrefabs;
    private void Update()
    {
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer >= SpawnIntervalSeconds && EnemyPrefabs.Length > 0)
        {
            _spawnTimer = 0;

            // Here, we first convert to screen space so we can add pixel-based offset.
            // This is then converted back into a world position so the enemy can be instantiated with a new position.

            Vector3 screenPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            Vector3 worldPosition = GetRandomWorldPosition(screenPosition);

            GameObject enemy = GetRandomEnemyPrefab();

            Instantiate(enemy, worldPosition, Quaternion.identity);
        }
    }

    void OnDrawGizmos()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        // Calculate the total width of all columns and gaps
        float totalWidth = (Columns - 1) * GapOffset;

        // Calculate the starting x position
        float startX = screenPosition.x - totalWidth / 2;

        for (int i = 0; i < Columns; i++)
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(startX + i * GapOffset, screenPosition.y, screenPosition.z));
            Gizmos.DrawSphere(worldPosition, 0.5f);
        }
    }

    private Vector3 GetRandomWorldPosition(Vector3 screenPosition)
    {
        float randomXOffset = (Random.Range(-Columns / 2, Columns / 2) + 0.5f) * GapOffset;
        return Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x + randomXOffset, screenPosition.y, screenPosition.z));
    }

    private GameObject GetRandomEnemyPrefab()
    {
        return EnemyPrefabs[Random.Range(0, EnemyPrefabs.Length)];
    }


}
