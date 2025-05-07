using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;

    public static GameManager Instance { get { return gameManager; } }

    public int currentScore = 0;

    UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } }

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");

        UIManager.SaveScore();
        UIManager.SetRestart();

        Time.timeScale = 0f;   
    }

    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainScene");
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
        UIManager.UpdateScore(currentScore);
    }
}
