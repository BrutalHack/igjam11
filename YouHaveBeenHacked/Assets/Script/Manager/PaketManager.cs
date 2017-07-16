using UnityEngine;
using UnityEngine.UI;

public class PaketManager : Manager
{
    public Animator Paket;
    public Image PaketContent;
    public Button PaketGlassPane;

    public override void HandleNewState(State state)
    {
        switch (state)
        {
            case State.BreakupFacebookLogin:
                Incoming();
                return;
        }
    }

    private void Incoming()
    {
        PaketGlassPane.gameObject.SetActive(true);
        Paket.gameObject.SetActive(true);
        Paket.SetTrigger("Open");
        SoundManager.SOUND_MANAGER.PlayDeliveryNotification();
    }

    public void OpenPaket()
    {
        Debug.Log("Open Paket.");
        Paket.gameObject.SetActive(false);
        PaketContent.gameObject.SetActive(true);
        SoundManager.SOUND_MANAGER.PlayOpenNotification();
    }

    public void ClosePaket()
    {
        Debug.Log("Close Paket.");
        PaketContent.gameObject.SetActive(false);
        PaketGlassPane.gameObject.SetActive(false);
    }
}