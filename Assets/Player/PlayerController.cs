using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    Animator animator;

    public GameObject viewCamera;
    public float moveSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = viewCamera.transform.forward;
        Vector3 right = viewCamera.transform.right;

        Vector3 moveDir = Input.GetAxisRaw("Vertical") * forward + Input.GetAxisRaw("Horizontal") * right;
        moveDir.y = 0;
        moveDir = moveDir.normalized;

        animator.SetBool("isWalking", moveDir.magnitude > 0.01);

        controller.Move(moveDir * moveSpeed * Time.deltaTime);
    }
}
