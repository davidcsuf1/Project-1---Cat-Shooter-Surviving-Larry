using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner spawner;
    [SerializeField] private int kills = 0;

    public void AddKill()
    {
        kills++;
    }

    public int GetKills()
    {
        return kills;
    }

    public void GameOver()
    {
        spawner.StopSpawning();
        Time.timeScale = 0f;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}