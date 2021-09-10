using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void OnEnable()
    {
        Actions.HandleScoreChanged += AddScore;
    }

    private void OnDestroy()
    {
        Actions.HandleScoreChanged -= AddScore;
    }

    public void AddScore()
    {
        DataBank.PlayerCurrentScore += 1;
        scoreText.text = "Score: " + DataBank.PlayerCurrentScore;
    }

}
