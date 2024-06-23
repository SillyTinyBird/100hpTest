using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseState : StateBase
{
    [HideInInspector]
    public StateBase previousState;
    private bool paused = true;
    public override void TickState(StateController context)
    {
        this.UpdateState(context);
        
    }
    public override void UpdateState(StateController context)
    {
        if (!this.paused)
        {
            context.SwitchState(previousState);
        }
    }
    public override void InitState(StateController context)
    {
        base.UpdateGameObjects(this.gameObjectsToDisable,this.gameObjectsToEnable);
        Time.timeScale = 0;
        paused = true;
    }

    public void Continue()
    {
        Time.timeScale = 1;
        paused = false;
    }
}
