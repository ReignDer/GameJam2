using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCast : MonoBehaviour
{
    public Camera camera;
    public string targetTag = "Anomaly"; // The tag you want to interact with

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for mouse click
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Raycast hit");
                Transform objectHit = hit.transform;
                Debug.Log(objectHit.gameObject.name);

                if (objectHit.CompareTag(targetTag)) // Check if the object has the specific tag
                {
                    Debug.Log("Hit Anomaly");
                    Anomaly hitObjectID = null;
                    if (objectHit.parent != null)
                        hitObjectID = objectHit.parent.GetComponent<Anomaly>();
                    else if(objectHit.parent.parent != null)
                    {
                        hitObjectID = objectHit.parent.GetComponent<Anomaly>();
                    }   

                    if (hitObjectID != null)
                    {
                        Debug.Log("ObjectID not null");
                        Parameters parameters = new Parameters();
                        parameters.PutExtra("Anomaly", hitObjectID.anomalyID);
                        EventBroadcaster.Instance.PostEvent(EventNames.Loop.ON_HIT_ANOMALY, parameters);
                    }
                    // Call the ReplaceCurrentGameObject method on the hit object if it has the ReplaceGameObject component
                    ReplaceGameObject replacer = objectHit.GetComponent<ReplaceGameObject>();

                    if (replacer != null)
                    {
                        replacer.ReplaceCurrentGameObject();
                        Debug.Log("Replacing");
                    }
                    else
                    {
                        Debug.LogWarning("ReplaceGameObject component not found on the hit object.");
                    }
                }
            }
        }
    }
}
