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
        //scoreNumText = GetComponent<TMPro.TextMeshProUGUI>();
        Score = 0;
    }

    void Update()
    {
        if (previousScore != Score) //save the score for display
        { 
            //GetComponent<TMPro.TextMeshProUGUI>().text = Score.ToString();
            // GameObject.Find("X").GetComponent<TextMeshProUGUI>();
            scoreNumText.text = Score.ToString();
        }
    }
}
