using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCastGroundCheck : MonoBehaviour
{
    public bool isGrounded;

    // Adjust these in the inspector
    public Transform groundCheckPoint; // The point from where the linecast starts
    public float groundCheckDistance = 1f; // How far down we check for ground
    public LayerMask groundLayer; // The layer to check against

    void Update()
    {
        if (IsGrounded())
        {
            Debug.Log("Player is on the ground");
        }
        else
        {
            Debug.Log("Player is in the air");
        }

        isGrounded = IsGrounded();
    }

    bool IsGrounded()
    {
        return Physics2D.Linecast(groundCheckPoint.position, new Vector2(groundCheckPoint.position.x, groundCheckPoint.position.y - groundCheckDistance), groundLayer);
    }
}
