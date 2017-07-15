using UnityEngine;

public abstract class Manager : MonoBehaviour
{
    public StateManager StateManager;

    public void SetNextState()
    {
        StateManager.NextState();
    }

    public abstract void HandleNewState(State state);
}