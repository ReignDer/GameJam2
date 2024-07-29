using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private float senX;
    [SerializeField]
    private float senY;

    [SerializeField]
    private Transform orientation;
    private Light light;

    private float xRotation;
    private float yRotation;

    private bool state;
    // Start is called before the first frame update

    private void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.State.STATE, GameStateChange);
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        light = GetComponent<Light>();
    }

    private void GameStateChange(Parameters state)
    {
        switch (state.GetStateExtra(EventNames.State.STATE, GameState.PLAY))
        {
            case GameState.PLAY:
                this.state = true;
                break;
            case GameState.PAUSE:
                this.state = false;
                break;
        }
    }

    // Update is called once per frame
    private void Update()
    {

        if (this.state)
        {

            if (Input.GetMouseButtonDown(1))
            {
                light.enabled = !light.enabled;
            }
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * senX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * senY;

            yRotation += mouseX;
            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -90, 90);
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
        

    }

    private void OnDisable()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.State.STATE);

    }
}
