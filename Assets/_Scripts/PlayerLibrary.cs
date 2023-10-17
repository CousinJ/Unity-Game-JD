using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLibrary 
{
   public void MoveOnAxisX(float horizontalInput, Rigidbody rb, int moveSpeed) {
    // Move the player along the X-axis
        Vector3 moveDirection = new Vector3(horizontalInput, 0, 0);
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, 0);
   }

   public void JumpListener(bool isGrounded, Rigidbody rb, int jumpForce)
    {
        if (!isGrounded)
        {
           
        }

        // Check for jumping input and make the player jump if grounded
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
