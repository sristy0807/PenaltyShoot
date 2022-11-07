using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// this class is responsible for all UI in the game scene
/// </summary>

public class UIController : MonoBehaviour
{
    public GameObject InitialPanel; // initial black panel which fades out

    public Text TurnsCountText; 
    public Text ScoreCountText;

    public GameOverUI gameOverUI;
    public ScoreAnimationUI scoreAnimationUI;

    #region unity callbacks

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
    #endregion

    //UI set up when the game starts
    public void GameStartUI(int numberOfTurns, int _score)
    {
        UpdateRemainingTurnText(numberOfTurns);
        UpdateScoreText(_score);
    }


    //total score is passed and ui update
    public void UpdateScoreText(int score)
    {
        ScoreCountText.text = score.ToString();
    }

    //remaining turns are passed and ui update
    public void UpdateRemainingTurnText(int remainingTurns)
    {
        TurnsCountText.text = remainingTurns.ToString();
    }

    //final score is passed and game over ui initiates
    private void OnGameOver(int finalScore)
    {
        gameOverUI.gameOverPanel.SetActive(true);
        gameOverUI.ResultText.text = "Your Score: " + finalScore;
    }

    //score animation for a normal goal
    private void OnScoreAnimation(int score)
    {
        scoreAnimationUI.NormalScoreAnimation.SetActive(true);
    }

    //score animation with a bonus score
    public void OnBonusAnimation(int bonus)
    {
        scoreAnimationUI.BonusAnimation.SetActive(true);
    }

    //score animation with a negative score
    public void OnNegativeScoreAnimation(int damage)
    {
        scoreAnimationUI.NegativeAnimation.SetActive(true);
    }

    #region button on click

    //reload the scene
    public void OnClickRestart()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    //quit the application
    public void OnClickQuit()
    {
        Application.Quit();
    }

    #endregion
}


