using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // https://docs.unity3d.com/ScriptReference/CharacterController.Move.html

    CharacterController controller;
    public Animator animator;

    public GameObject viewCamera;
    public float moveSpeed = 4f;
    public float jumpVelocity = 2.5f;
    public float gravity = 4f;
    public float baseDownVelocity = 0.1f;
    //public float coyoteTime = 0.1f;

    float velocityY = 0;


    //float offGroundTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateOnGround();

        bool isOnGround = controller.isGrounded; //IsOnGround();

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

        moveDir.y = velocityY - baseDownVelocity;

        controller.Move(moveSpeed * Time.deltaTime * moveDir);
    }

    // https://stackoverflow.com/questions/53463043/unity-grounded-state-is-flickering-for-character-isgrounded-being-used-but-sti
    /*void UpdateOnGround()
    {
        if (controller.isGrounded)
        {
            offGroundTime = 0;
        }
        else
        {
            offGroundTime += Time.deltaTime;
        }
    }

    bool IsOnGround()
    {
        return offGroundTime < coyoteTime;
    }*/
}
