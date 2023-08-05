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

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private float speedMultiplier = 2f;
    [SerializeField] private float smoothInputSpeed = 0.1f;

    [SerializeField] private Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    private int jumpCount = 0;
    bool isGrounded, passThroughPlatform;
    
    private float xVelocity, yVelocity, xInputVector, smoothInputVelocity;

    public void OnMove(InputAction.CallbackContext context)
    {
        float speed = context.ReadValue<float>() * moveSpeed;
        if (activeAbility == Abilities.SpeedBoost)
        {
            speed *= speedMultiplier;
        }
        xVelocity = speed;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && (isGrounded || (activeAbility == Abilities.DoubleJump && jumpCount < 1)))
        {
            yVelocity = jumpHeight;
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
            if (yVelocity < 0)
            {
                yVelocity = -2f;
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
        
        yVelocity += gravity * Time.deltaTime;

        if (xVelocity == 0 && !isGrounded)
        {
            //Character is moving through air without input
        }
        else
        {
            xInputVector = Mathf.SmoothDamp(xInputVector, xVelocity, ref smoothInputVelocity, smoothInputSpeed);
        }
        
        controller.Move(new Vector3(xInputVector, yVelocity, 0) * moveSpeed * Time.deltaTime);
    }
}
