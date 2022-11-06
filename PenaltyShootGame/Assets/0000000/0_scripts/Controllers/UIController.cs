using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject InitialPanel;
    public Text TurnsCountText;
    public Text ScoreCountText;

    private void OnEnable()
    {
        InitialPanel.gameObject.SetActive(true);
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
}

