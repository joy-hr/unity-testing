using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float time = 0;

    [Tooltip("The rate at which the enemies spawn in seconds")]
    [Min(0)]
    public float intervalSeconds = 1;

    [Tooltip("The size of the gap between the enemies in pixels")]
    [Min(0)]
    public int gapOffset = 100;

    [Tooltip("The amount of columns to spawn from")]
    [Range(0, 4)]
    public int columns = 4;

    public GameObject[] enemyPrefabs;
    public GameObject spawner;

    void Update()
    {
        if (time >= intervalSeconds && enemyPrefabs.Length > 0)
        {
            time = 0;

            Vector3 screenPosition = Camera.main.WorldToScreenPoint(spawner.transform.position);
            Debug.Log(screenPosition);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x + (Random.Range(0, columns) - columns / 2) * gapOffset, screenPosition.y, screenPosition.z));
            GameObject enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length - 1)];

            Instantiate(enemy, worldPosition, Quaternion.identity);
        }

        time += Time.deltaTime;
    }
}