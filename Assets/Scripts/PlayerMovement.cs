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
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    private int jumpCount = 0;
    bool isGrounded, passThroughPlatform;

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
        if (context.performed && (isGrounded || (activeAbility == Abilities.DoubleJump && jumpCount < 1)))
        {
            velocity.y = jumpHeight;
            jumpCount++;
        }
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            passThroughPlatform = true;
        }

        if (context.canceled)
        {
            passThroughPlatform = false;
        }
    }
    
    //public void OnCrouchRelease()

    void FixedUpdate()
    {
        //Check if player is grounded, if true reset jump count and downwards velocity
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
        
        //If player is jumping, allow passing through platforms
        if ((controller.velocity.y > 0 && !isGrounded) || passThroughPlatform)
        {
            Physics.IgnoreLayerCollision(7, 8, true);
        }
        else
        {
            Physics.IgnoreLayerCollision(7, 8, false);
        }
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * moveSpeed * Time.deltaTime);
    }
}
