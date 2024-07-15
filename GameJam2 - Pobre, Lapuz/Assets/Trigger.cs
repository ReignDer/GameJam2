using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Parameters parameters = new Parameters();
        parameters.PutExtra("Portal", this.gameObject.name);
        parameters.PutExtra("PortalID", this.gameObject.GetComponentInParent<Level>().levelID);
        if(other.tag == "Player")
        {
            Debug.Log(other.transform.position);
            EventBroadcaster.Instance.PostEvent(EventNames.Loop.BACK_TO_ORIGIN, parameters);
            EventBroadcaster.Instance.PostEvent(EventNames.Loop.TRACK_TRIGGER, parameters);
            

        }
    }
}
