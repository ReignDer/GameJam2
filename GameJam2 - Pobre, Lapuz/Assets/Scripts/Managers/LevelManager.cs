using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public List<Transform> TriggerLoop;
    public List<Transform> TeleportTo;

    public GameObject Player;

    public List<Level> level;

    private int currentStage;
    private int nextStage;
    private int trackLoop;
    private int trackIndex;
    private int stageIndex;
    private string triggerName = null;
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
        stageIndex = currentStage - 1;
        nextStage = currentStage + 1;

        EventBroadcaster.Instance.AddObserver(EventNames.Loop.BACK_TO_ORIGIN, OnLoop);
        EventBroadcaster.Instance.AddObserver(EventNames.Loop.ON_HIT_ANOMALY, RemoveAnomaly);
    }
    private void ProgressToNextLevel(int currentStage, int index)
    {
        Debug.Log(this.currentStage);
        switch (currentStage) {
            case 1:
                trackLoop++;
                switch (trackLoop)
                {
                    case 3:
                        trackLoop = 0;
                        nextStage = currentStage + 1;
                        this.Teleport(nextStage, index);

                        this.currentStage = nextStage;
                        break;
                    default:
                        this.Teleport(index);
                        break;

                }
                break;
            case 2: Debug.Log("Stage2");
                this.stageIndex = currentStage - 1;
                Debug.Log(level[stageIndex].anomalies.Count);
                switch (level[stageIndex].anomalies.Count)
                {
                    case 0:
                        nextStage = currentStage + 1;
                        this.Teleport(nextStage + 1, index);

                        this.currentStage = nextStage;
                    break;

                    default:
                        this.Teleport(index);
                        break;
                }
                break;

            case 3:
                Debug.Log("Stage3");
                
                this.stageIndex = currentStage - 1;

                switch (level[stageIndex].anomalies.Count)
                {
                    case 0:
                        nextStage = currentStage + 1;
                        Debug.Log(nextStage + 1);
                        this.Teleport(nextStage + 2, index);

                        this.currentStage = nextStage;
                        break;

                    default:
                        this.Teleport(index);
                        break;
                }
                break;

            case 4:
                Debug.Log("Stage4");
                this.stageIndex = currentStage - 1;
                switch (level[stageIndex].anomalies.Count)
                {
                    case 0:
                        nextStage = currentStage + 1;
                        this.Teleport(nextStage + 3, index);

                        this.currentStage = nextStage;
                        break;

                    default:
                        this.Teleport(index);
                        break;
                }
                break;
            case 5:
                Debug.Log("Stage5");
                this.stageIndex = currentStage - 1;
                switch (level[stageIndex].anomalies.Count)
                {
                    case 0:
                        nextStage = currentStage + 1;
                        this.Teleport(nextStage + 4, index);

                        this.currentStage = nextStage;
                        break;

                    default:
                        this.Teleport(index);
                        break;
                }
                break;
            case 6:
                Debug.Log("Stage6");
                this.stageIndex = currentStage - 1;
                switch (level[stageIndex].anomalies.Count)
                {
                    case 0:
                       
                        break;

                    default:
                        this.Teleport(index);
                        break;
                }
                break;


        }
    }

    private void Teleport(int index)
    {
        Vector3 offsetPosition = Player.transform.position - TriggerLoop[index].position;
        Vector3 newPos = TeleportTo[index].position + offsetPosition;
        newPos.y = 1f;
        Player.transform.position = newPos;
        Physics.SyncTransforms();
    }
    private void Teleport(int teleportTo, int lastTrigger)
    {
        Vector3 offsetPosition = Player.transform.position - TriggerLoop[lastTrigger].position;
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


        switch (triggerName)
        {
            case "LVL-1__Trigger-1":
                this.ProgressToNextLevel(currentStage,index);
                break;
            case "LVL-2__Trigger-1":
                this.ProgressToNextLevel(currentStage, index);
                break;
            case "LVL-3__Trigger-1":
                this.ProgressToNextLevel(currentStage, index);
                break;
            case "LVL-4__Trigger-1":
                this.ProgressToNextLevel(currentStage, index);
                break;
            case "LVL-5__Trigger-1":
                this.ProgressToNextLevel(currentStage, index);
                break;
            case "LVL-6__Trigger-1":
                this.ProgressToNextLevel(currentStage, index);
                break;
            case "LVL-1__Trigger-2":

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
    private void RemoveAnomaly(Parameters parameter)
    {
        int stageIndex= currentStage -1;
        
        if (level[stageIndex].anomalies.Count != 0)
        {
            for (int i = 0; i < level[stageIndex].anomalies.Count; i++)
            {
                if (level[stageIndex].anomalies[i].anomalyID == parameter.GetIntExtra("Anomaly", level[stageIndex].anomalies[i].anomalyID))
                {
                    level[stageIndex].anomalies.RemoveAt(i);
                    Debug.Log("AnomalyRemoved");
                    break;
                }
            }
        }
    }
    private void OnDisable()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.State.STATE);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Loop.BACK_TO_ORIGIN);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Loop.ON_HIT_ANOMALY);
        //EventBroadcaster.Instance.RemoveObserver(EventNames.Loop.TRACK_TRIGGER);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
