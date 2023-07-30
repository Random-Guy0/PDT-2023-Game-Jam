using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 10f;

    [SerializeField] private Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    
    Vector2 velocity;

    public void OnMove(InputAction.CallbackContext context)
    {
        velocity.x = context.ReadValue<float>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            velocity.y = jumpHeight;
        }
    }

    void FixedUpdate()
    {
        if (Physics.CheckSphere(groundCheck.position, groundDistance, groundMask))
        {
            isGrounded = true;
            if (velocity.y < 0)
            {
                velocity.y = -2f;
            }
        }
        else
        {
            isGrounded = false;
        }
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * moveSpeed * Time.deltaTime);
    }
}
