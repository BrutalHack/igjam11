using UnityEngine;
using UnityEngine.UI;

public class PaketManager : Manager
{
    public Animator Paket;
    public Image PaketContent;
    
    public override void HandleNewState(State state)
    {
        switch (state)
        {
                case State.LetterOneAndTwo:
                case State.LetterBankAccountEmpty:
                    return;
        }
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
    }
}