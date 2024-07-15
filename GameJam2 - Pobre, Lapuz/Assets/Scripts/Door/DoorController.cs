using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator; // Reference to the Animator component
    private bool isPlayerInRange = false;
    public Collider OpenCollider;

    void OnTriggerEnter(Collider OpenCollider)
    {
        if (OpenCollider.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Entered range");
        }
    }

    void OnTriggerExit(Collider OpenCollider)
    {
        if (OpenCollider.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E)) // Change KeyCode.E to whatever key you want
        {
            bool isOpen = doorAnimator.GetBool("isOpen");
            doorAnimator.SetBool("isOpen", !isOpen);
        }
    }
}
