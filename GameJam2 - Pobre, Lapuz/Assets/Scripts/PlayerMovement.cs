using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float horizontal;
    private float vertical;
    Vector3 movementDir = Vector3.zero;
    [SerializeField]
    private Transform orientation;
    private Rigidbody rb;

    [SerializeField]
    private float playerHeight;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private float groundDrag;
    private bool grounded;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log(this.transform.position.x + ", " + this.transform.position.y + ", " + this.transform.position.z);

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 2f, whatIsGround);

        this.SpeedControl();
        this.ProcessInput();

        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        this.movePlayer();
    }

    private void ProcessInput()
    {
        this.horizontal = Input.GetAxisRaw("Horizontal");
        this.vertical = Input.GetAxisRaw("Vertical");
    }

    private void movePlayer()
    {
        this.movementDir = this.orientation.forward * this.vertical + orientation.right * this.horizontal;
        this.rb.AddForce(this.movementDir.normalized * speed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if(flatVelocity.magnitude > speed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * speed;
            rb.velocity = new Vector3(limitedVelocity.x,rb.velocity.y, limitedVelocity.z);  
        }
    }
}
