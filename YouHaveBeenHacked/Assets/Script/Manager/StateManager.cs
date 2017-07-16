﻿using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    void Awake()
    {
        State = State.TwitterLogin;
    }

    public TwitterManager TwitterManager;
    public HandyManager HandyManager;
    public MailManager MailManager;
    public InstagramManager InstagramManager;
    public FacebookManager FacebookManager;
    public LetterManager LetterManager;
    public PaketManager PaketManager;
    public Text DebugText;

    public void NextState()
    {
        State++;
        DebugText.text = State.ToString();
        UpdateDrama(State);
        TwitterManager.HandleNewState(State);
        HandyManager.HandleNewState(State);
        MailManager.HandleNewState(State);
        InstagramManager.HandleNewState(State);
        FacebookManager.HandleNewState(State);
        LetterManager.HandleNewState(State);
        PaketManager.HandleNewState(State);
    }

    public State State { get; private set; }

    private void UpdateDrama(State state)
    {
        switch (state)
        {
                case State.BreakupWhatsappGirlfriendView:
                case State.LetterOneAndTwo:
                case State.FacebookShitpostMailLoginFailed:
                case State.NudepicsWhatsappGirlfriendNotification:
                    SoundManager.SOUND_MANAGER.MoreDrama();
                    break;
                case State.PhoneGoneLocked:
                    SoundManager.SOUND_MANAGER.ResetVolume();
                    break;
                case State.LetterBankAccountEmpty:
                    SoundManager.SOUND_MANAGER.PlayEndNotification();
                    break;
        }
    }
}