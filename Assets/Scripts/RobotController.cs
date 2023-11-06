using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Animator animator;
    public GameObject robotCamera;
    
    public float walkSpeed;
    private float input_right = 0;
    private float input_forward = 0;

    public float jumpStrength;
    private int onGround = 0;
    private bool input_jump = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        input_right = Input.GetAxis("Horizontal");
        input_forward = Input.GetAxis("Vertical");
    
        if (onGround > 0 && Input.GetButtonDown("Jump"))
        {
            input_jump = true;
        }
    }
    
    void FixedUpdate() {
        Vector3 forward = Vector3.ProjectOnPlane(robotCamera.transform.forward, Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(robotCamera.transform.right, Vector3.up).normalized;
        
        // Walking
        Vector3 movement = input_right * right + input_forward * forward;
        if (movement.sqrMagnitude > 1)
        {
            movement = movement.normalized;
        }

        movement = walkSpeed * movement;
        bool isMoving = movement.magnitude > 0.01;

        //rigidBody.MovePosition(rigidBody.position + movement*Time.deltaTime);
        rigidBody.velocity = new Vector3(movement.x, rigidBody.velocity.y, movement.z);

        if (isMoving)
        {
            transform.LookAt(transform.position + forward);
        }

        animator.SetBool("isWalking", isMoving);
        animator.SetBool("isOnGround", onGround > 0);

        // Jumping
        Vector3 up = transform.up;

        if (input_jump)
        {
            rigidBody.AddForce(jumpStrength * up, ForceMode.Impulse);
            input_jump = false;

            animator.SetBool("isJumping", true);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;

        //if (obj.tag == "Ground")
        //{
            onGround += 1;

            animator.SetBool("isJumping", false);
        //}
    }

    void OnCollisionExit(Collision collision)
    {
        GameObject obj = collision.gameObject;

        //if (obj.tag == "Ground")
        //{
            onGround -= 1;

            if (onGround < 0)
            {
                onGround = 0;
            }
        //}
    }
}
