using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UImanager : MonoBehaviour
{
    public static UImanager instance;

    public Text score;
    public Text NumberOfTurnsRemaining;
    public GameObject GameOverPanel;
    public Text ResultText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void UpdateScore()
    {
        
        try
        {
            score.text = ScoreManager.instance.PlayerScore.ToString();
        }
        catch
        {
            return;
        }
    }

    public void UpdateNumberOfTurns()
    {
        try
        {
            NumberOfTurnsRemaining.text = GameManager.instance.NumberOfTurnRemaining.ToString();
        }
        catch
        {
            return;
        }
    }

    public void GameOver()
    {
        ResultText.text = "Your score: " + ScoreManager.instance.PlayerScore;
        GameOverPanel.SetActive(true);
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene("game");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    private void Update()
    {
      
    }
}
