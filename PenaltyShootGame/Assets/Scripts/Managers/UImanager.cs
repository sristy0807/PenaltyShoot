using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public Text score;

    private void Update()
    {
        score.text = ScoreManager.instance.PlayerScore.ToString();
    }
}
