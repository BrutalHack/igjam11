using UnityEngine;
using UnityEngine.UI;

public class HandyManager : Manager
{
    public GameObject ContentKumpel;
    public GameObject ContentFreundin;
    public GameObject HandyOpen;
    public GameObject HandyGlassPane;
    public Button HandyClosed;

    public override void HandleNewState(State state)
    {
        switch (state)
        {
            case State.CatPictureWhatsappNotification:
                break;
            case State.CatPictureWhatsappView:
                ContentKumpel.SetActive(true);
                break;
            case State.CatPictureMailLogin:
                break;
            case State.BreakupWhatsappGirlfriendNotification:
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
}