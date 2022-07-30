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
        InvokeRepeating("ImproveGameDifficulty", 0, 20 ); //every 20 second to improve the difficulty
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

    private void ImproveGameDifficulty()
    {
        GameObject pipeSpawner = GameObject.FindGameObjectWithTag("PipeSpawner");
		pipeSpawner.SendMessage("setMinTime", 0.1);
        pipeSpawner.SendMessage("setMinTime", 0.1);
    }
}
