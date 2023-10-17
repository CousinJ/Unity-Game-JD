using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed = 3f;
    public float jumpForce = 8f;
    public float gravity = 20f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController characterController;
    public Animator animator;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        ApplyGravity();
        Jump();
    }

    private void Move()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        moveDirection = new Vector3(horizontalInput * moveSpeed, moveDirection.y, 0);
        characterController.Move(moveDirection * Time.deltaTime);

        if(Mathf.Abs(horizontalInput) > 0.1f) {
            animator.SetBool("Move", true);
        }
        else {
            animator.SetBool("Move", false);
        }
        SwitchDirection(horizontalInput);
    }

    private void ApplyGravity()
    {
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        else
        {
            // Ensure we're grounded when standing on a slope or similar situations.
            moveDirection.y = -1;
        }
    }

    private void Jump()
    {
        if (characterController.isGrounded && Input.GetButtonDown("Jump"))
        {
           
            moveDirection.y = jumpForce;
        }
    }

  private void SwitchDirection(float horizontalInput) {
    if (horizontalInput > 0 && transform.forward.x < 0) {
        Turn180Degrees();
    }
    else if (horizontalInput < 0 && transform.forward.x > 0) {
        Turn180Degrees();
    }
}

private void Turn180Degrees() {
    
    transform.Rotate(0, 180, 0); // Rotate 180 degrees around the Y-axis



    
}


    
}
