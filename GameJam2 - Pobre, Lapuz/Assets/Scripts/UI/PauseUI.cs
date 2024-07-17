using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : View
{
    // Start is called before the first frame update
    private void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.UI_Events.UI_STATE, GameStateChange);
    }

    private void OnEnable()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.UI_Events.UI_STATE, GameStateChange);

    }
    private void GameStateChange(Parameters state)
    {
        Debug.Log("FireUIState");
        GameState newState = state.GetStateExtra(EventNames.UI_Events.UI_STATE, GameState.PLAY);
        switch (newState)
        {
            case GameState.PLAY:
                this.SetVisibility(false);
                Debug.Log("FireState");

                break;
            case GameState.PAUSE:
                this.SetVisibility(true);
                Debug.Log("FireState");

                break;
        }
    }
 
    // Update is called once per frame
    public void OnResumeClick()
    {
        this.SetVisibility(false);
        GameManager.Instance.UpdateGameState(GameState.PLAY);

    }

    public void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.UI_Events.UI_STATE);
    }
}
