using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState state;

    private bool isPaused = false;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        this.UpdateGameState(GameState.PLAY);
    }

    // Update is called once per frame
    void Update()
    {
        this.EscapeInput();
    }
    private void EscapeInput()
    {

        switch (Input.GetKeyDown(KeyCode.Escape), this.isPaused)
        {
            case (true, false):
                this.isPaused = !this.isPaused;
                this.UpdateGameState(GameState.PAUSE);
                break;
            case (true, true):
                this.isPaused = !this.isPaused;
                this.UpdateGameState(GameState.PLAY);

                break;
        }
    }
    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.PLAY:
                this.HandlePlay();
                Debug.Log("Play");
                break;
            case GameState.PAUSE:
                this.HandlePause();
                Debug.Log("PAUSE");
                break;
        }
        Parameters parameters = new Parameters();
        parameters.PutExtra(EventNames.State.STATE, newState);
        parameters.PutExtra(EventNames.UI_Events.UI_STATE, newState);
        EventBroadcaster.Instance.PostEvent(EventNames.State.STATE, parameters);
        EventBroadcaster.Instance.PostEvent(EventNames.UI_Events.UI_STATE, parameters);

    }

    private void HandlePlay()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void HandlePause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

}
