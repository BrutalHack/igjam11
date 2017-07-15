using UnityEngine;
using UnityEngine.UI;

public class HandyManager : Manager
{
    public GameObject ContentKumpel;
    public GameObject ContentFreundin;
    public GameObject HandyOpen;
    public GameObject HandyGlassPane;
    public Button HandyClosed;
    public SendMessage SendButton;
    public ScrollRect ScrollView;

    public override void HandleNewState(State state)
    {
        switch (state)
        {
            case State.CatPictureWhatsappNotification:
                break;
            case State.CatPictureWhatsappView:
                ShowBuddyMessages();
                break;
            case State.CatPictureMailLogin:
                break;
            case State.BreakupWhatsappGirlfriendNotification:
                break;
            case State.BreakupWhatsappGirlfriendView:
                ShowGFMessages();
                break;
            case State.BreakupWhatsappBuddyNotification:
                break;
            case State.BreakupWhatsappBuddyView:
                ShowBuddyMessages();
                break;
        }
    }

    public void OpenHandy()
    {
        HandyOpen.gameObject.SetActive(true);
        HandyGlassPane.gameObject.SetActive(true);
        HandyClosed.gameObject.SetActive(false);

        if (StateManager.State == State.CatPictureWhatsappNotification)
        {
            StateManager.NextState();
        }
    }

    public void CloseHandy()
    {
        HandyOpen.SetActive(false);
        HandyClosed.gameObject.SetActive(true);
        HandyGlassPane.SetActive(false);
        if (StateManager.State == State.CatPictureWhatsappView)
        {
            StateManager.NextState();
        }
    }

    public void ShowBuddyMessages()
    {
        ContentFreundin.SetActive(
            false);
        ContentKumpel.SetActive(true);
        SendButton.panel = ContentKumpel.GetComponent<RectTransform>();
        ScrollView.content = ContentKumpel.GetComponent<RectTransform>();
    }

    public void ShowGFMessages()
    {
        ContentFreundin.SetActive(
            true);
        ContentKumpel.SetActive(
            false);
        SendButton.panel = ContentFreundin.GetComponent<RectTransform>();
        ScrollView.content = ContentFreundin.GetComponent<RectTransform>();
    }
}