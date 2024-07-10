using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Parameters parameters = new Parameters();
        parameters.PutExtra("Portal", this.gameObject.name);
        if(other.tag == "Player")
        {
            EventBroadcaster.Instance.PostEvent(EventNames.Loop.BACK_TO_ORIGIN, parameters);
        }
    }
}
