using System;
using UnityEngine;

public class FacebookManager : Manager
{
    public GameObject Notification;
    public GameObject Login;
    public GameObject LoginFailed;
    public GameObject TimelineBreakup;
    public GameObject TimelineBreakPostDeleted;
    public GameObject TimelineCrappost;

    public override void HandleNewState(State state)
    {
        switch (state)
        {
            case State.BreakupFacebookPublicNotification:
                Notification.SetActive(true);
                TimelineBreakup.SetActive(true);
                break;
            case State.BreakupFacebookPublicView:
                break;
            case State.BreakupFacebookLogin:
                TimelineBreakup.SetActive(false);
                Login.SetActive(true);
                break;
            case State.BreakupFacebookProfile:
                Login.SetActive(false);
                TimelineBreakup.SetActive(true);
                break;
            case State.BreakupFacebookProfileEntryDeleted:
                TimelineBreakup.SetActive(false);
                TimelineBreakPostDeleted.SetActive(true);
                Notification.SetActive(false);
                WaitAndNextState();
                break;
            case State.FacebookShitpostFacebookNotification:
                Notification.SetActive(true);
                TimelineBreakPostDeleted.SetActive(false);
                TimelineCrappost.SetActive(true);
                break;
            case State.FacebookShitpostFacebookView:
                break;
            case State.FacebookShitpostFacebookLogin:
                TimelineCrappost.SetActive(false);
                Login.SetActive(true);
                break;
            case State.FacebookShitpostFacebookForgotPassword:
                Notification.SetActive(false);
                Login.SetActive(false);
                LoginFailed.SetActive(true);
                break;
        }
    }
}