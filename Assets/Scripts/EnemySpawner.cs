using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private SimplePool enemyPool;
    [SerializeField] private Transform player;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval = 2f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), spawnInterval, spawnInterval);
    }

    public void StopSpawning()
    {
        CancelInvoke(nameof(SpawnEnemy));
    }

    private void SpawnEnemy()
    {
        GameObject obj = enemyPool.GetFromPool();
        if (obj != null)
        {
            Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];
            obj.transform.position = point.position;
            Enemy enemy = obj.GetComponent<Enemy>();
            enemy.SetTarget(player);
            enemy.SetGameManager(gameManager);
        }
    }
}