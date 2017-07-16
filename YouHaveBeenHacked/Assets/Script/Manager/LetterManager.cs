using System;
using UnityEngine;
using UnityEngine.UI;

public class LetterManager : Manager
{
    public Animator Letter;
    public Image LetterContent;
    public Text LetterText;
    private String _oneAndTwo = "Hallo Alex,\\n vielen dank für den Upgrade deines Vertrags.\\n Mit freundlichen Grüßen\\n 1&2 Team";
    private String _bank = "Hallo Alex,\\n dein Konto wird gespert da du es um 2.000 € überzogen hast.\\n Mit freundlichen Grüßen\\n Bank";
    
    public override void HandleNewState(State state)
    {
        if (state == State.LetterOneAndTwo)
        {
            LetterText.text = _oneAndTwo;
            Incoming();    
        }
        if (state == State.LetterBankAccountEmpty)
        {
            LetterText.text = _bank;
            Incoming();
        }
    }

    private void Incoming()
    {
        Letter.gameObject.SetActive(true);
        Letter.SetTrigger("Open");
        
    }

    public void OpenLetter()
    {
        Debug.Log("Open Letter.");
        Letter.gameObject.SetActive(false);
        LetterContent.gameObject.SetActive(true);
    }

    public void CloseLetter()
    {
        Debug.Log("Close Letter.");
        LetterContent.gameObject.SetActive(false);
        SetNextState();
    }
}