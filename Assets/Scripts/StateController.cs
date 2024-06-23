using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateController : MonoBehaviour
{
    //state machine
    private StateBase currentState;
    //added from inspector
    public GamePauseState stateGamePause;
    public QuestionAnswerState stateQuestionAnswer;
    public LoadQuestionsState stateLoadQuestions;
    public BriefResultState stateBriefResult;
    public FinalResultState stateFinalResult;

    // Start is called before the first frame update
    void Start()
    {
        stateGamePause.previousState = stateLoadQuestions;
        SwitchState(stateGamePause);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.TickState(this);
    }

    public void SwitchState(StateBase state)
    {
        currentState = state;
        currentState.InitState(this);
        Debug.Log("State changed to: " + currentState);
    }
    public void PauseStateMachine()
    {
        stateGamePause.previousState = currentState;
        SwitchState(stateGamePause);
    }
    
    public void UnPauseStateMachine()
    {
        stateGamePause.Continue();
    }
}
