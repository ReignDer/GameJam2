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
        EventBroadcaster.Instance.AddObserver(EventNames.Loop.BACK_TO_ORIGIN, OnLoop);
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
        }
    }

    private void OnDisable()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Loop.BACK_TO_ORIGIN);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
