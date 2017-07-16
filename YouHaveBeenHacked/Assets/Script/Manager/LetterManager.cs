using UnityEngine;
using UnityEngine.UI;

public class LetterManager : Manager
{
    public Animator Letter;
    public Image LetterContent;
    
    public override void HandleNewState(State state)
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