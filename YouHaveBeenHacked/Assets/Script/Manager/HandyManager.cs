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
                AddMessage("Hey dude, I sent you the best cat picture via mail!",
                    SetupWhatsappPrefab.ImagePosition.Right, BuddyAvatar, ContentKumpel);
                break;
            case State.CatPictureWhatsappView:
                notifyBuddy(false);
                WaitAndNextState();
                break;
            case State.CatPictureMailLogin:
                break;
            case State.BreakupWhatsappGirlfriendNotification:
                notifyGF(true);
                AddMessage("What the fuck is wrong with you?!", SetupWhatsappPrefab.ImagePosition.Right, GFAvatar,
                    ContentFreundin);
                AddMessage("Have fun with your cheap whore, you jerk!", SetupWhatsappPrefab.ImagePosition.Right,
                    GFAvatar, ContentFreundin);
                break;
            case State.BreakupWhatsappGirlfriendView:
                notifyGF(false);
                WaitAndNextState();
                break;
            case State.BreakupWhatsappBuddyNotification:
                notifyBuddy(true);
                AddMessage("Woah, you and Vanessa? She's hot, but weren't you with Laura?",
                    SetupWhatsappPrefab.ImagePosition.Right, BuddyAvatar,
                    ContentKumpel);
                break;
            case State.BreakupWhatsappBuddyView:
                notifyBuddy(false);
                WaitAndNextState();
                break;
            case State.BreakupWhatsappGirlfriendSecondMessageNotification:
                notifyGF(true);
                AddMessage("Oh wow... think that changes anything?", SetupWhatsappPrefab.ImagePosition.Right, GFAvatar,
                    ContentFreundin);
                AddMessage("I don't know what happened on stalkbook, that wasn't me!",
                    SetupWhatsappPrefab.ImagePosition.Left, YourAvatar, ContentFreundin);
                AddMessage("I must have been hacked, I haven't seen Vanessa in Ages!",
                    SetupWhatsappPrefab.ImagePosition.Left, YourAvatar, ContentFreundin);
                break;
            case State.BreakupWhatsappGirlfriendSecondMessageView:
                notifyGF(false);
                WaitAndNextState();
                break;
            case State.FacebookShitpostWhatsappBuddyNotification:
                notifyBuddy(true);
                AddMessage("Hey dude, what the hell is that on stalkbook? you mad?",
                    SetupWhatsappPrefab.ImagePosition.Right, BuddyAvatar,
                    ContentKumpel);
                AddMessage("Again? I think I was hacked, I didn't post anything!",
                    SetupWhatsappPrefab.ImagePosition.Left, YourAvatar,
                    ContentKumpel);
                break;
            case State.FacebookShitpostWhatsappBuddyView:
                notifyBuddy(false);
                WaitAndNextState();
                break;
            case State.MailIsGoneWhatsappBuddyNotification:
                AddMessage("Damn, you okay bro? Can I help?", SetupWhatsappPrefab.ImagePosition.Right, BuddyAvatar,
                    ContentKumpel);

                notifyBuddy(true);
                break;
            case State.MailIsGoneWhatsappBuddyView:
                AddMessage("I don't know, I can't login to my stalkbook or mail!",
                    SetupWhatsappPrefab.ImagePosition.Left, YourAvatar,
                    ContentKumpel);
                AddMessage("You're an IT guy, or? What can I do?", SetupWhatsappPrefab.ImagePosition.Left, YourAvatar,
                    ContentKumpel);
                notifyBuddy(false);
                AddMessage("This is bad. You could check if your account was leaked on haveibeenpwned.com...",
                    SetupWhatsappPrefab.ImagePosition.Right, BuddyAvatar, ContentKumpel);
                AddMessage("But first we have to fix this ASAP", SetupWhatsappPrefab.ImagePosition.Right, BuddyAvatar,
                    ContentKumpel);
                WaitAndNextState();
                break;
            case State.NudepicsWhatsappGirlfriendNotification:
                notifyGF(true);
                AddMessage("I just saw that on instakilo! Seriously?", SetupWhatsappPrefab.ImagePosition.Right,
                    GFAvatar, ContentFreundin);
                AddMessage("I can't believe I ever trusted you! Is this funny?",
                    SetupWhatsappPrefab.ImagePosition.Right, GFAvatar, ContentFreundin);
                AddMessage("My lawyer will kill you! You will lose everything!",
                    SetupWhatsappPrefab.ImagePosition.Right, GFAvatar, ContentFreundin);
                break;
            case State.NudepicsWhatsappGirlfriendView:
                notifyGF(false);
                WaitAndNextState();
                break;
            case State.PhoneGoneWhatsappBuddyProtectPhoneNotification:
                notifyBuddy(true);
                AddMessage("Activate two factor authentication on any non-hacked accounts!",
                    SetupWhatsappPrefab.ImagePosition.Right, BuddyAvatar, ContentKumpel);
                AddMessage("And you better call your Phone Provider, before he locks it online.",
                    SetupWhatsappPrefab.ImagePosition.Right, BuddyAvatar, ContentKumpel);
                AddMessage("but first! call your bank and credit card company... anything financial!",
                    SetupWhatsappPrefab.ImagePosition.Right, BuddyAvatar, ContentKumpel);
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
            case State.FacebookShitpostWhatsappBuddyNotification:
            case State.MailIsGoneWhatsappBuddyNotification:
                case State.PhoneGoneWhatsappBuddyProtectPhoneNotification:
                ShowBuddyInternal();
                break;
            case State.BreakupWhatsappGirlfriendNotification:
            case State.BreakupWhatsappGirlfriendSecondMessageNotification:
            case State.NudepicsWhatsappGirlfriendNotification:
                ShowGFInternal();
                break;
        }
        AdvanceStateIfIn(State.CatPictureWhatsappNotification, State.BreakupWhatsappGirlfriendNotification,
            State.BreakupWhatsappBuddyNotification, State.BreakupWhatsappGirlfriendSecondMessageNotification,
            State.FacebookShitpostWhatsappBuddyNotification, State.MailIsGoneWhatsappBuddyNotification,
            State.NudepicsWhatsappGirlfriendNotification,State.PhoneGoneWhatsappBuddyProtectPhoneNotification);
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
        AdvanceStateIfIn(State.BreakupWhatsappBuddyNotification, State.FacebookShitpostWhatsappBuddyNotification,
            State.MailIsGoneWhatsappBuddyNotification,State.PhoneGoneWhatsappBuddyProtectPhoneNotification);
    }

    public void ShowGFMessages()
    {
        ShowGFInternal();
        AdvanceStateIfIn(State.BreakupWhatsappGirlfriendSecondMessageNotification,
            State.NudepicsWhatsappGirlfriendNotification,State.BreakupWhatsappGirlfriendSecondMessageNotification);
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