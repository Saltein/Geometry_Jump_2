using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreLvl4 : MonoBehaviour
{
    public TextMeshProUGUI scoreTXT;

    private float timer = 0;
    private float timeToScore = 1f;
    public float scoreForTime = 100f;

    public float scoreMultipler = 150f;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToScore)
        {
            ScoreScriptMain._score += scoreForTime;  
            timer = 0;
        }
        scoreTXT.text = "Score: " + ScoreScriptMain._score.ToString();
    }
}
