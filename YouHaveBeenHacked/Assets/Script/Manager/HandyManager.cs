using System.Linq;
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
                ShowBuddyMessages();
                break;
            case State.CatPictureWhatsappView:
                break;
            case State.CatPictureMailLogin:
                break;
            case State.BreakupWhatsappGirlfriendNotification:
                ShowGFMessages();
                break;
            case State.BreakupWhatsappGirlfriendView:
                break;
            case State.BreakupWhatsappBuddyNotification:
                break;
            case State.BreakupWhatsappBuddyView:
                break;
        }
    }

    public void OpenHandy()
    {
        HandyOpen.gameObject.SetActive(true);
        HandyGlassPane.gameObject.SetActive(true);
        HandyClosed.gameObject.SetActive(false);
        AdvanceStateIfIn(State.CatPictureWhatsappNotification, State.BreakupWhatsappGirlfriendNotification,
            State.BreakupWhatsappBuddyNotification);
    }

    public void CloseHandy()
    {
        HandyOpen.SetActive(false);
        HandyClosed.gameObject.SetActive(true);
        HandyGlassPane.SetActive(false);
        AdvanceStateIfIn(State.CatPictureWhatsappView, State.BreakupWhatsappBuddyView);
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
        ContentFreundin.SetActive(
            false);
        ContentKumpel.SetActive(true);
        SendButton.panel = ContentKumpel.GetComponent<RectTransform>();
        ScrollView.content = ContentKumpel.GetComponent<RectTransform>();
    }

    private void ShowGFInternal()
    {
        ContentFreundin.SetActive(
            true);
        ContentKumpel.SetActive(
            false);
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
}