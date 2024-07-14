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
                Transform objectHit = hit.transform;

                if (objectHit.CompareTag(targetTag)) // Check if the object has the specific tag
                {
                    // Do something with the object that was hit by the raycast.
                    Debug.Log("Anomaly found on tagged object");
                }
            }
        }
    }
}
