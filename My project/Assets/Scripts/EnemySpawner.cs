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

    private Vector3 GetRandomWorldPosition(Vector3 screenPosition)
    {
        float randomXOffset = (Random.Range(0, Columns) - Columns / 2f) * GapOffset;
        return Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x + randomXOffset, screenPosition.y, screenPosition.z));
    }

    private GameObject GetRandomEnemyPrefab()
    {
        return EnemyPrefabs[Random.Range(0, EnemyPrefabs.Length)];
    }
}
