using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;

    // Update is called once per frame
    private void Update()
    {
        this.transform.position = cameraPosition.position;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
