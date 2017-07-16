using UnityEngine;

public class MailManager : Manager
{
    public GameObject Notification;
    public GameObject MailLogin;
    public GameObject MailCatView;
    public GameObject MailLoginFailed;

    public override void HandleNewState(State state)
    {
        switch (state)
        {
            case State.CatPictureMailLogin:
                Notification.SetActive(true);
                MailLogin.SetActive(true);
                break;
            case State.CatPictureMailView:
                MailLogin.SetActive(false);
                MailCatView.SetActive(true);
                Notification.SetActive(false);
                WaitAndNextState();
                break;
            case State.FacebookShitpostFacebookForgotPassword:
                break;
            case State.FacebookShitpostMailNotification:
                Notification.SetActive(true);
                break;
            case State.FacebookShitpostMailLogin:
                MailCatView.SetActive(false);
                MailLogin.SetActive(true);
                break;
            case State.FacebookShitpostMailLoginFailed:
                Notification.SetActive(false);
                MailLogin.SetActive(false);
                MailLoginFailed.SetActive(true);
                WaitAndNextState();
                break;
        }
    }
}