using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadQuestionsState : StateBase
{
    [SerializeField] QuestionLoader questionLoader;

    public override void TickState(StateController context)
    {
        this.UpdateState(context);

    }
    public override void UpdateState(StateController context)
    {
        
        context.SwitchState(context.stateQuestionAnswer);
    }

    public override void InitState(StateController context)
    {
        var result = questionLoader.LoadQuestions();

        if (!result)
            context.stateBriefResult.IsQuestionsAreOver = true;

        base.UpdateGameObjects(this.gameObjectsToDisable, this.gameObjectsToEnable);
    }
}
