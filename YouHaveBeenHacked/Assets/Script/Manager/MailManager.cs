using System;
using UnityEngine;

public class MailManager : Manager
{
    public GameObject Notification;

    public override void HandleNewState(State state)
    {
        switch (state)
        {
            case State.CatPictureMailLogin:
                Notification.SetActive(true);
                break;
            case State.CatPictureMailView:
                Notification.SetActive(false);
                WaitAndNextState();
                break;
            case State.FacebookShitpostFacebookForgotPassword:
                break;
            case State.FacebookShitpostMailNotification:
                Notification.SetActive(true);
                break;
            case State.FacebookShitpostMailLogin:
                break;
            case State.FacebookShitpostMailLoginFailed:
                Notification.SetActive(false);
                WaitAndNextState();
                break;
        }
    }
}