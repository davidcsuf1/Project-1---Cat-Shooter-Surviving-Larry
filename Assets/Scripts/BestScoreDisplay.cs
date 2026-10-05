using UnityEngine;
using TMPro;

public class BestScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text bestScoreText;

    private void Start()
    {
        bestScoreText.text = "Best: " + PlayerPrefs.GetInt("BestScore", 0);
    }
}