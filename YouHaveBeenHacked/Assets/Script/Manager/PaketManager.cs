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
                case State.LetterOneAndTwo:
                case State.LetterBankAccountEmpty:
                case State.TwitterTimeline:
                    return;
        }
        Incoming();
    }

    private void Incoming()
    {
        PaketGlassPane.gameObject.SetActive(true);
        Paket.gameObject.SetActive(true);
        Paket.SetTrigger("Open");
    }

    public void OpenPaket()
    {
        Debug.Log("Open Paket.");
        Paket.gameObject.SetActive(false);
        PaketContent.gameObject.SetActive(true);
    }

    public void ClosePaket()
    {
        Debug.Log("Close Paket.");
        PaketContent.gameObject.SetActive(false);
        PaketGlassPane.gameObject.SetActive(false);
    }
}