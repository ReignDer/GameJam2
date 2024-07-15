using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<Transform> TriggerLoop;
    public List<Transform> TeleportTo;

    public GameObject Player;

    public List<Level> level;

    private int currentStage;
    private int nextStage;
    private int trackLoop;
    private int trackIndex;
    string triggerName = null;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        trackLoop = 0;
        currentStage = level[0].levelID;
        nextStage = currentStage + 1;
        EventBroadcaster.Instance.AddObserver(EventNames.Loop.BACK_TO_ORIGIN, OnLoop);
        EventBroadcaster.Instance.AddObserver(EventNames.Loop.TRACK_TRIGGER, ProgressToNextLevel);


    }


    private void ProgressToNextLevel()
    {
        
        switch (currentStage) {
            case 1:
                if (trackLoop == 3)
                {
                    trackLoop = 0;
                    nextStage = currentStage + 1;
             
                    
                    currentStage = nextStage;
                }
                break;
            case 2: Debug.Log("Stage2"); break;

            case 3: break;
            case 4:
            break;
            case 5:
            break;
            case 6:
            break;


        }
    }

    private void Teleport(int index)
    {
        Vector3 offsetPosition = Player.transform.position - TriggerLoop[index].position;
        //Debug.Log("Local: " + offsetPosition);
        Vector3 newPos = TeleportTo[index].position + offsetPosition;
        newPos.y = 1f;
        Player.transform.position = newPos;
        Physics.SyncTransforms();
    }
    private void Teleport(int teleportTo, int lastTrigger)
    {
        Debug.Log(TriggerLoop[lastTrigger].name);
        Debug.Log(TeleportTo[teleportTo].name);
        Vector3 offsetPosition = Player.transform.position - TriggerLoop[lastTrigger].position;
        //Debug.Log("Level: " + offsetPosition);
        Vector3 newPos = TeleportTo[teleportTo].position + offsetPosition;
        newPos.y = 1f;
        Player.transform.position = newPos;
        Physics.SyncTransforms();
    }

    private int TriggerPortal(Parameters Portal)
    {
        int index = 0;
        for (int i = 0; i < TriggerLoop.Count; i++)
        {
            if (TriggerLoop[i].name == Portal.GetStringExtra("Portal", TriggerLoop[i].name))
            {
                triggerName = TriggerLoop[i].name;
                Debug.Log(triggerName);
                index = i;
                return index;
            }

        }

        return index;
    }
    private void OnLoop(Parameters Portal)
    {

        int index = this.TriggerPortal(Portal);
        this.trackIndex = index;
        Debug.Log(trackIndex);

        switch (triggerName)
        {
            case "LVL-1__Trigger-1":
                //Debug.Log("Trigger");
                trackLoop++;
                switch (trackLoop)
                {
                    case 3:
                        this.Teleport(2, index);
                        break;
                    default:
                        this.Teleport(index);
                        break;
                }
                
                break;
            case "LVL-2__Trigger-1":
                this.Teleport(index);
                break;
            case "LVL-3__Trigger-1":
                this.Teleport(index);
                break;
            case "LVL-4__Trigger-1":
                this.Teleport(index);
                break;
            case "LVL-5__Trigger-1":
                this.Teleport(index);
                break;
            case "LVL-6__Trigger-1":
                this.Teleport(index);
                break;
            case "LVL-1__Trigger-2":
                //Debug.Log("Trigger2");

                this.Teleport(index);
                break;

            case "LVL-2__Trigger-2":
                this.Teleport(index);
                break;
            case "LVL-3__Trigger-2":
                this.Teleport(index);
                break;
            case "LVL-4__Trigger-2":
                this.Teleport(index);
                break;
            case "LVL-5__Trigger-2":
                this.Teleport(index);
                break;
            case "LVL-6__Trigger-2":
                this.Teleport(index);
                break;
        }

    }

    private void OnDisable()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Loop.BACK_TO_ORIGIN);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Loop.TRACK_TRIGGER);

    }
    // Update is called once per frame
    void Update()
    {
        this.ProgressToNextLevel();
    }
}
