using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // https://docs.unity3d.com/ScriptReference/CharacterController.Move.html

    CharacterController controller;
    public Animator animator;

    public GameObject viewCamera;
    public float moveSpeed = 1f;
    public float jumpVelocity = 1f;
    public float gravity = 1f;

    float velocityY = 0;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isOnGround = controller.isGrounded;

        animator.SetBool("isOnGround", isOnGround);
        if (isOnGround)
        {
            animator.SetBool("isJumping", false);
            if (velocityY < 0) {
                velocityY = 0;
            }

            if (Input.GetButton("Jump"))
            {
                velocityY = jumpVelocity;
                animator.SetBool("isJumping", true);
            }
        }

        velocityY -= gravity * Time.deltaTime;

        Vector3 forward = Vector3.ProjectOnPlane(viewCamera.transform.forward, Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(viewCamera.transform.right, Vector3.up).normalized;

        Vector3 moveDir = Input.GetAxis("Vertical") * forward + Input.GetAxis("Horizontal") * right;

        bool isMoving = moveDir.sqrMagnitude > 0.01;
        animator.SetBool("isWalking", isMoving);

        if (isMoving)
        {
            transform.LookAt(transform.position + moveDir);
        }

        if (moveDir.magnitude > 1)
        {
            moveDir = moveDir.normalized;
        }

        moveDir.y = velocityY - 0.1f;

        controller.Move(moveSpeed * Time.deltaTime * moveDir);

        animator.SetBool("isOnGround", controller.isGrounded);
    }
}
