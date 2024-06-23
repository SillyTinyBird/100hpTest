using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateBase : MonoBehaviour 
{
    [SerializeField]
    public List<GameObject> gameObjectsToDisable;
    [SerializeField]
    public List<GameObject> gameObjectsToEnable;

    public abstract void TickState(StateController context);

    public abstract void UpdateState(StateController context);
    public abstract void InitState(StateController context);
    public void UpdateGameObjects(List<GameObject> gameObjectsToDisable, List<GameObject> gameObjectsToEnable)
    {
        foreach (var item in gameObjectsToDisable)
            item.SetActive(false);

        foreach (var item in gameObjectsToEnable)
            item.SetActive(true);
    }
}
