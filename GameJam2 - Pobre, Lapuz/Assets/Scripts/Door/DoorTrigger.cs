using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Collider OpenCollider;

    private void OnTriggerEnter(Collider OpenCollider)
    {
        if (OpenCollider.CompareTag("Player"))
        {
            Debug.Log("Player has entered the door's collider.");
        }
    }

    private void OnTriggerExit(Collider OpenCollider)
    {
        if (OpenCollider.CompareTag("Player"))
        {
            Debug.Log("Player has exited the door's collider.");
        }
    }
}

