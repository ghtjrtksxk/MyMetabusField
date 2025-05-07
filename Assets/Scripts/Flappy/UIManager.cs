using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inGameScoreText;

    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    [SerializeField] private TextMeshProUGUI restartText;
    [SerializeField] private TextMeshProUGUI exitText;

    GameManager gameManager;

    int gameScore;

    int bestScore = 0;
    private const string BestScoreKey = "BestScore";

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;

        gameOverPanel.SetActive(false);

        gameScore = GameManager.Instance.currentScore;

        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);

    }

    public void SetRestart()
    {
        inGameScoreText.gameObject.SetActive(false);

        gameOverPanel.SetActive(true);

        scoreText.text = gameScore.ToString();

        bestScoreText.text = bestScore.ToString();
    }

    public void UpdateScore(int score)
    {
        inGameScoreText.gameObject.SetActive(true);

        inGameScoreText.text = score.ToString();
    }

    public void SaveScore()
    {
        if (bestScore < gameScore)
        {
            bestScore = gameScore;

            PlayerPrefs.SetInt(BestScoreKey, bestScore);
        }
    }
}
