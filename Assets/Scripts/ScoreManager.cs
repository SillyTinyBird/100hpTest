using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    
    [SerializeField] private int basePoints = 500;
    [SerializeField] private TextMeshProUGUI scoreTMP;
    [SerializeField] private TextMeshProUGUI rightsTMP;

    public int Score { private set; get; } = 0;
    public int Rights { private set; get; } = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(float TimeLeftRatio, bool answerRight)
    {
        Rights += answerRight ? 1 : 0;
        rightsTMP.text = $"{Rights}/5";

        var modifier = answerRight ? 10 : 1;
        Score += (int)(basePoints * TimeLeftRatio * modifier);
        scoreTMP.text = Score.ToString("000000");
    }
}
