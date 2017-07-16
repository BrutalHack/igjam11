﻿using System.Collections;
using UnityEngine;

public abstract class Manager : MonoBehaviour
{
    public StateManager StateManager;

    public void SetNextState()
    {
        StateManager.NextState();
    }

    public abstract void HandleNewState(State state);

    public void WaitAndNextState(float secondsToWait)
    {
        StartCoroutine(WaitAndNextStateInternal(secondsToWait));
    }
    private IEnumerator WaitAndNextStateInternal(float secondsToWait)
    {
        yield return new WaitForSeconds(secondsToWait);
        StateManager.NextState();
    }
}