using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BriefResultState : StateBase
{
    [SerializeField, Range(0, 10)]
    private float secondsToShowResult;
    private float secondsLeft = 0;

    [SerializeField]
    private Slider slider;

    [SerializeField] EnemyController enemyController;

    public bool IsQuestionsAreOver { get; set; }

    public override void TickState(StateController context)
    {
        secondsLeft -= Time.deltaTime;
        slider.value = Mathf.InverseLerp(0, secondsToShowResult, secondsLeft);

        this.UpdateState(context);
    }
    public override void UpdateState(StateController context)
    {
        if (secondsLeft < 0)
        {
            if(IsQuestionsAreOver)
                context.SwitchState(context.stateFinalResult);
            else
                context.SwitchState(context.stateLoadQuestions);
            
        }
    }
    public override void InitState(StateController context)
    {
        enemyController.RandomAnswer();
        base.UpdateGameObjects(this.gameObjectsToDisable, this.gameObjectsToEnable);
        secondsLeft = secondsToShowResult;
    }
}
