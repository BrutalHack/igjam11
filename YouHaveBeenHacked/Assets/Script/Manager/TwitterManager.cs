using System.Collections;
using UnityEngine;

public class TwitterManager : Manager
{
    public RectTransform TwitterLogin;
    public RectTransform TwitterTimeline;
    public GameObject TwitterButton;
    public float SecondsToWaitInTimeline=5;

    public override void HandleNewState(State state)
    {
        switch (state)
        {
            case State.TwitterTimeline:
                TwitterLogin.gameObject.SetActive(false);
                TwitterTimeline.gameObject.SetActive(true);
                WaitAndNextState(SecondsToWaitInTimeline);
                break;
        }
    }
}