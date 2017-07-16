using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HandyManager : Manager
{
    public GameObject ContentKumpel;
    public GameObject ContentFreundin;
    public GameObject HandyOpen;
    public GameObject HandyGlassPane;
    public GameObject HandyNotification;
    public GameObject NotificationGF;
    public GameObject NotificationBuddy;
    public Button HandyClosed;
    public SendMessage SendButton;
    public ScrollRect ScrollView;
    public RectTransform messagePrefab;
    public Sprite YourAvatar;
    public Sprite GFAvatar;
    public Sprite BuddyAvatar;
    public RectTransform BuddyButton;
    public RectTransform GFButton;

    public override void HandleNewState(State state)
    {
        switch (state)
        {
            case State.CatPictureWhatsappNotification:
                notifyBuddy(true);
                break;
            case State.CatPictureWhatsappView:
                notifyBuddy(false);
                WaitAndNextState();
                break;
            case State.CatPictureMailLogin:
                break;
            case State.BreakupWhatsappGirlfriendNotification:
                notifyGF(true);
                AddMessage("It's over, asshole!", SetupWhatsappPrefab.ImagePosition.Right, GFAvatar, ContentFreundin);
                break;
            case State.BreakupWhatsappGirlfriendView:
                notifyGF(false);
                WaitAndNextState();
                break;
            case State.BreakupWhatsappBuddyNotification:
                notifyBuddy(true);
                AddMessage("Whats that on Facebook?", SetupWhatsappPrefab.ImagePosition.Right, BuddyAvatar,
                    ContentKumpel);
                break;
            case State.BreakupWhatsappBuddyView:
                notifyBuddy(false);
                WaitAndNextState();
                break;
            case State.BreakupWhatsappGirlfriendSecondMessageNotification:
                notifyGF(true);
                break;
            case State.BreakupWhatsappGirlfriendSecondMessageView:
                
                break;
            case State.BreakupWhatsappGirlfriendSecondMessageAnswered:
                notifyGF(false);
                WaitAndNextState();
                break;
            case State.FacebookShitpostWhatsappBuddyNotification:
                notifyBuddy(true);
                break;
            case State.FacebookShitpostWhatsappBuddyView:
                notifyBuddy(false);
                WaitAndNextState();
                break;
            case State.MailIsGoneWhatsappBuddyNotification:
                notifyBuddy(true);
                break;
            case State.MailIsGoneWhatsappBuddyView:
                break;
            case State.MailIsGoneWhatsappBuddyAnswered:
                break;
            case State.MailIsGoneWhatsappBuddyHaveIBeenPwned:
                notifyBuddy(false);
                WaitAndNextState();
                break;
            case State.NudepicsWhatsappGirlfriendNotification:
                notifyGF(true);
                break;
            case State.NudepicsWhatsappGirlfriendView:
                notifyGF(false);
                WaitAndNextState();
                break;
            case State.PhoneGoneWhatsappBuddyProtectPhoneNotification:
                notifyBuddy(true);
                break;
            case State.PhoneGoneWhatsappBuddyProtectPhoneView:
                break;
            case State.PhoneGoneLocked:
                notifyBuddy(false);
                WaitAndNextState();
                break;
        }
    }

    private void notifyBuddy(bool active)
    {
        HandyNotification.SetActive(active);
        NotificationBuddy.SetActive(active);
    }

    private void notifyGF(bool active)
    {
        HandyNotification.SetActive(active);
        NotificationGF.SetActive(active);
    }

    private void AddMessage(string text, SetupWhatsappPrefab.ImagePosition imagePosition, Sprite image,
        GameObject targetPanel)
    {
        var newMessage = Instantiate(messagePrefab);
        var setup = newMessage.GetComponent<SetupWhatsappPrefab>();
        setup.Layout = imagePosition;
        setup.Text = text;
        setup.Sprite = image;
        newMessage.transform.SetParent(targetPanel.transform, false);
    }

    public void OpenHandy()
    {
        HandyOpen.gameObject.SetActive(true);
        HandyGlassPane.gameObject.SetActive(true);
        HandyClosed.gameObject.SetActive(false);
        switch (StateManager.State)
        {
            case State.CatPictureWhatsappNotification:
            case State.BreakupWhatsappBuddyNotification:
                ShowBuddyInternal();
                break;
            case State.BreakupWhatsappGirlfriendNotification:
                ShowGFInternal();
                break;
        }
        AdvanceStateIfIn(State.CatPictureWhatsappNotification, State.BreakupWhatsappGirlfriendNotification,
            State.BreakupWhatsappBuddyNotification);
    }

    public void CloseHandy()
    {
        HandyOpen.SetActive(false);
        HandyClosed.gameObject.SetActive(true);
        HandyGlassPane.SetActive(false);
    }

    public void ShowBuddyMessages()
    {
        ShowBuddyInternal();
        AdvanceStateIfIn(State.BreakupWhatsappBuddyNotification);
    }

    public void ShowGFMessages()
    {
        ShowGFInternal();
    }

    private void ShowBuddyInternal()
    {
        ContentFreundin.SetActive(false);
        ContentKumpel.SetActive(true);
        SetActiveTabButton(BuddyButton);
        SendButton.panel = ContentKumpel.GetComponent<RectTransform>();
        ScrollView.content = ContentKumpel.GetComponent<RectTransform>();
    }

    private void SetActiveTabButton(RectTransform tabButton)
    {
        if (tabButton.Equals(BuddyButton))
        {
            BuddyButton.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.7f);

            GFButton.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 0.3f);
        }
        else
        {
            GFButton.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.7f);
            BuddyButton.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 0.3f);
        }
    }

    private void ShowGFInternal()
    {
        ContentFreundin.SetActive(true);
        ContentKumpel.SetActive(false);
        SetActiveTabButton(GFButton);
        SendButton.panel = ContentFreundin.GetComponent<RectTransform>();
        ScrollView.content = ContentFreundin.GetComponent<RectTransform>();
    }

    private void AdvanceStateIfIn(params State[] states)
    {
        if (states.Contains(StateManager.State))
        {
            StateManager.NextState();
        }
    }

    private void ScrollToBottom()
    {
        Canvas.ForceUpdateCanvases();
        ScrollView.verticalScrollbar.value = 0f;
        Canvas.ForceUpdateCanvases();
    }
}