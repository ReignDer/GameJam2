using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform OriginPoint;
    public Transform Entrance;
    public Transform EntranceTarget;
    public Transform OriginTarget;
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
        if (OriginPoint.name == Portal.GetStringExtra("Portal", "Cube"))
        {
            Debug.Log("ToEntrance");
            Vector3 point = new Vector3(EntranceTarget.position.x, 1, EntranceTarget.position.z);
            Player.transform.position = point;

        }
        else if(Entrance.name == Portal.GetStringExtra("Portal", "Cube (1)"))
        {
            Debug.Log("ToOrigin");
            Vector3 point = new Vector3(OriginTarget.position.x, 1, OriginTarget.position.z);
            Player.transform.position = point;

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
