using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject InitialPanel;
    public GameObject DamageAnimation;

    public Text TurnsCountText;
    public Text ScoreCountText;

    public GameOverUI gameOverUI;
    public ScoreAnimationUI scoreAnimationUI;

    private void OnEnable()
    {
        InitialPanel.gameObject.SetActive(true);

        EventManager.GameEnd += OnGameOver;
        EventManager.BallScored += OnScoreAnimation;
        EventManager.BonusItemTouched += OnBonusAnimation;
        EventManager.NegativeItemTouched += OnNegativeScoreAnimation;
    }

    private void OnDisable()
    {
        EventManager.GameEnd -= OnGameOver;
        EventManager.BallScored -= OnScoreAnimation;
        EventManager.BonusItemTouched -= OnBonusAnimation;
        EventManager.NegativeItemTouched -= OnNegativeScoreAnimation;
    }

    public void UpdateScoreText(int score)
    {
        ScoreCountText.text = score.ToString();
    }

    public void UpdateRemainingTurnText(int remainingTurns)
    {
        TurnsCountText.text = remainingTurns.ToString();
    }

    public void GameStartUI(int numberOfTurns, int _score)
    {
        
        UpdateRemainingTurnText(numberOfTurns);
        UpdateScoreText(_score);
    }

    private void OnGameOver(int finalScore)
    {
        gameOverUI.gameOverPanel.SetActive(true);
        gameOverUI.ResultText.text = "Your Score: " + finalScore;
    }

    private void OnScoreAnimation(int score)
    {
        scoreAnimationUI.NormalScoreAnimation.SetActive(true);
    }

    public void OnBonusAnimation(int bonus)
    {
        scoreAnimationUI.BonusAnimation.SetActive(true);
    }

    public void OnNegativeScoreAnimation(int damage)
    {
        scoreAnimationUI.NegativeAnimation.SetActive(true);
    }

    public void OnClickRestart()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}


