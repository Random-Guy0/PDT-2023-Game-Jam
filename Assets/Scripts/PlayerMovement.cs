using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public enum Abilities
    {
        Default,
        DoubleJump,
        SpeedBoost
    }

    [SerializeField] private Abilities activeAbility;
    
    public CharacterController controller;

    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 10f;
    [SerializeField] private float speedMultiplier = 20f;

    [SerializeField] private Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private int jumpCount = 0;
    bool isGrounded;
    
    Vector2 velocity;

    public void OnMove(InputAction.CallbackContext context)
    {
        float speed = context.ReadValue<float>();
        if (activeAbility == Abilities.SpeedBoost)
        {
            speed *= speedMultiplier;
        }
        velocity.x = speed;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounded || (activeAbility == Abilities.DoubleJump && jumpCount < 2))
        {
            velocity.y = jumpHeight;
            jumpCount++;
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

            jumpCount = 0;
        }
        else
        {
            isGrounded = false;
        }
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * moveSpeed * Time.deltaTime);
    }
}
