using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public ObjectPool enemyPool;
    public float spawnRate = 2f;
    public float spawnWidth = 8f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnRate);
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(
            Random.Range(-spawnWidth, spawnWidth),
            0,
            15f
        );

        GameObject enemy = enemyPool.GetObject();
        enemy.transform.position = spawnPos;
        enemy.transform.rotation = Quaternion.identity;

        enemy.GetComponent<Enemy>().Init(enemyPool);
    }
}