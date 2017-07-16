using System;
using UnityEngine;

public class InstagramManager : Manager
{
    public GameObject Notification;
    public GameObject CleanTimeline;
    public GameObject NudeTimeline;
    public override void HandleNewState(State state)
    {
        switch (state)
        {
            case State.NudepicsInstagramNotification:
                Notification.SetActive(true);
                CleanTimeline.SetActive(false);
                NudeTimeline.SetActive(true);
                WaitAndNextState(15);
                break;
            case State.NudepicsInstagramView:
                Notification.SetActive(false);
                WaitAndNextState();
                break;
        }
    }
}