using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner spawner;
    [SerializeField] private TMP_Text killsText;
    [SerializeField] private TMP_Text finalScoreText;
    [SerializeField] private TMP_Text bestScoreText;
    [SerializeField] private GameObject gameOverPanel;

    private int kills = 0;
    private int bestScore = 0;

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        killsText.text = "Score: " + kills;
    }

    public void AddKill()
    {
        kills++;
        killsText.text = "Score: " + kills;

        if (kills > bestScore)
        {
            bestScore = kills;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
        }
    }

    public void GameOver()
    {
        spawner.StopSpawning();
        finalScoreText.text = "Score: " + kills;
        bestScoreText.text = "Best Score: " + bestScore;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}