using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int previousScore = -1;
    public Sprite[] numberSprites;
    public SpriteRenderer unitBit, tenBit, hundredBit;
    public static int Score { get; set; }

   
    void Start()
    {
        (tenBit.gameObject as GameObject).SetActive(false);
        (hundredBit.gameObject as GameObject).SetActive(false);
    }

    void Update()
    {
        if (previousScore != Score) //save perf from non needed calculations
        { 
            if(Score < 10)
            {
                //just draw units
                unitBit.sprite = numberSprites[Score];
            }
            else if(Score >= 10 && Score < 100)
            {
                (tenBit.gameObject as GameObject).SetActive(true);
                tenBit.sprite = numberSprites[Score / 10];
                unitBit.sprite = numberSprites[Score % 10];
            }
            else if(Score >= 100)
            {
                (hundredBit.gameObject as GameObject).SetActive(true);
                hundredBit.sprite = numberSprites[Score / 100];
                int rest = Score % 100;
                tenBit.sprite = numberSprites[rest / 10];
                unitBit.sprite = numberSprites[rest % 10];
            }
        }
    }
}
