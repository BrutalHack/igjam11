using System;
using UnityEngine;

public class InstagramManager : Manager
{
    public GameObject Notification;

    public override void HandleNewState(State state)
    {
        switch (state)
        {
            case State.NudepicsInstagramNotification:
                Notification.SetActive(true);
                break;
            case State.NudepicsInstagramView:
                Notification.SetActive(false);
                WaitAndNextState();
                break;
        }
    }
}