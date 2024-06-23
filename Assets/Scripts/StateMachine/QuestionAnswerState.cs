using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionAnswerState : StateBase
{
    [SerializeField,Range(0,60)] private float secondsToAnswer;
    private float secondsLeft = 0;
    [SerializeField] private Slider slider;
    private bool gotAnswer;
    [SerializeField] ScoreManager score;

    //public bool IsQuestionsAreOver { get; set; }

    public override void TickState(StateController context)
    {
        secondsLeft -= Time.deltaTime;
        slider.value = Mathf.InverseLerp(0, secondsToAnswer, secondsLeft);
        this.UpdateState(context);
    }

    public override void UpdateState(StateController context)
    {
        if (secondsLeft < 0 || gotAnswer)
        {
            context.SwitchState(context.stateBriefResult);
        }
    }

    public override void InitState(StateController context)
    {
        base.UpdateGameObjects(this.gameObjectsToDisable, this.gameObjectsToEnable);
        secondsLeft = secondsToAnswer;
        gotAnswer = false;
    }

    public void GetButtonPressAnswer(bool isAnswerRight)
    {
        if(!gotAnswer)
            score.UpdateScore(Mathf.InverseLerp(0, secondsToAnswer, secondsLeft), isAnswerRight);
        gotAnswer = true;
        //update score
    }
}