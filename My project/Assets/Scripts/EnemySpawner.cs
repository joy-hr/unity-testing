using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float _spawnTimer = 0;

    [Tooltip("The rate at which the enemies spawn in seconds"), Min(0)]
    public float SpawnIntervalSeconds = 1;

    [Tooltip("The size of the gap between the enemies in pixels"), Min(0)]
    public int GapOffset = 100;

    [Tooltip("The amount of columns to spawn from"), Range(0, 4)]
    public int Columns = 4;

    public GameObject[] EnemyPrefabs;

    private void Update()
    {
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer >= SpawnIntervalSeconds && EnemyPrefabs.Length > 0)
        {
            _spawnTimer = 0;
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 worldPosition = GetRandomWorldPosition(screenPosition);
            GameObject enemy = GetRandomEnemyPrefab();
            Instantiate(enemy, worldPosition, Quaternion.identity);
        }
    }

    void OnDrawGizmos()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        float totalWidth = (Columns - 1) * GapOffset;
        float startX = screenPosition.x - totalWidth / 2;

        for (int i = 0; i < Columns; i++)
        {
            Vector3 columnPosition = new Vector3(startX + i * GapOffset, screenPosition.y, screenPosition.z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(columnPosition);
            Gizmos.DrawSphere(worldPosition, 0.5f);
        }
    }

    private Vector3 GetRandomWorldPosition(Vector3 screenPosition)
    {
        float randomXOffset = (Random.Range(-Columns / 2, Columns / 2) + 0.5f) * GapOffset;
        Vector3 randomScreenPosition = new Vector3(screenPosition.x + randomXOffset, screenPosition.y, screenPosition.z);
        return Camera.main.ScreenToWorldPoint(randomScreenPosition);
    }

    private GameObject GetRandomEnemyPrefab()
    {
        int randomIndex = Random.Range(0, EnemyPrefabs.Length);
        return EnemyPrefabs[randomIndex];
    }
}
