using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceGameObject : MonoBehaviour
{
    public GameObject newPrefab; 

    public void ReplaceCurrentGameObject()
    {
        if (newPrefab != null)
        {

            Vector3 position = transform.position;
            Quaternion rotation = transform.rotation;


            GameObject newObject = Instantiate(newPrefab, position, rotation);


            newObject.transform.parent = transform.parent;


            gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No newPrefab assigned. Please assign a newPrefab in the inspector.");
        }
    }
}
