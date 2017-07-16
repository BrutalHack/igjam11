using System;
using UnityEngine;

public class FacebookManager : Manager
{
    public GameObject Notification;

    public override void HandleNewState(State state)
    {
        switch (state)
        {
            case State.BreakupFacebookPublicNotification:
                Notification.SetActive(true);
                break;
            case State.BreakupFacebookPublicView:
                break;
            case State.BreakupFacebookLogin:
                break;
            case State.BreakupFacebookProfile:
                break;
            case State.BreakupFacebookProfileEntryDeleted:
                Notification.SetActive(false);
                WaitAndNextState();
                break;
            case State.FacebookShitpostFacebookNotification:
                Notification.SetActive(true);
                break;
            case State.FacebookShitpostFacebookView:
                break;
            case State.FacebookShitpostFacebookLogin:
                break;
            case State.FacebookShitpostFacebookForgotPassword:
                Notification.SetActive(false);
                WaitAndNextState();
                break;
        }
    }
}