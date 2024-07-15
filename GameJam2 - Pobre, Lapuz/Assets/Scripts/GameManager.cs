using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform TestPoint;
    public Transform TestPoint2;
    public Transform TestTarget;
    public Transform TestTarget2;

    public GameObject Player;

    public List<Level> level;

    private int currentStage;
    private int trackLoop; 
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
        EventBroadcaster.Instance.AddObserver(EventNames.Loop.BACK_TO_ORIGIN, OnLoop);
        EventBroadcaster.Instance.AddObserver(EventNames.Loop.TRACK_TRIGGER, ProgressToNextLevel);


    }


    private void ProgressToNextLevel()
    {
        //if (level[currentStage + 1] == null)
        //    return;
        switch (currentStage) {
            case 1: 
                if(trackLoop == 3)
                {
                    trackLoop = 0;
                    currentStage++;
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

    private void OnLoop(Parameters Portal)
    {
       
        if(TestPoint.name == Portal.GetStringExtra("Portal", "Test")){
            Vector3 offsetPosition = Player.transform.position - TestPoint.position;
            Vector3 newPos = TestTarget.position + offsetPosition;
            newPos.y = 1f;
            Player.transform.position = newPos;
            Physics.SyncTransforms();
        }
        else if (TestPoint2.name == Portal.GetStringExtra("Portal", "Test2"))
        {
            Vector3 offsetPosition = Player.transform.position - TestPoint2.position;
            Vector3 newPos = TestTarget2.position + offsetPosition;
            newPos.y = 1f;
            Player.transform.position = newPos;
            Physics.SyncTransforms();
            trackLoop++;

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
