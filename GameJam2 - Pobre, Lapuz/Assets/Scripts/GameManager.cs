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
            Debug.Log(Player.transform.position.x + "," + Player.transform.position.y + "," + Player.transform.position.z);
            Vector3 offsetPosition = Player.transform.position - OriginPoint.position;
            //Vector3 point = new Vector3(Entrance.position.x + 6.5f + offsetPosition.x, 1, Entrance.position.z + offsetPosition.z);
            //Vector3 point = new Vector3(EntranceTarget.position.x + offsetPosition.x - 0.5f, 1, EntranceTarget.position.z + offsetPosition.z );
            Vector3 newPos = EntranceTarget.position + offsetPosition;
            newPos.y = 1f;
            Player.transform.position = newPos;
            Physics.SyncTransforms();
            Debug.Log(Player.transform.position.x + "," + Player.transform.position.y + "," + Player.transform.position.z);

        }
        else if(Entrance.name == Portal.GetStringExtra("Portal", "Cube (1)"))
        {
            Debug.Log("ToOrigin");
             Debug.Log(Player.transform.position.x + "," + Player.transform.position.y + "," + Player.transform.position.z);
            Vector3 offsetPosition = Player.transform.position - Entrance.position;
            Vector3 point = new Vector3(OriginPoint.position.x - 5.9f - offsetPosition.x, 1, OriginPoint.position.z + offsetPosition.z);
            Player.transform.position = point;
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
