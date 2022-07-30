using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int previousScore = -1;
    public static int Score { get; set; }
    [SerializeField] private TextMeshProUGUI scoreNumText;
    void Start()
    {
        Score = 0;
    }

    void Update()
    {
        if (GameStateManager.GameState == GameState.Dead)
            return;
        if (previousScore != Score) //save the score for display
        { 
            scoreNumText.text = Score.ToString();
        }
    }
}
