using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResetPlayer : MonoBehaviour
{
    [SerializeField] private BlockHolder blockHolder;
    
    private Vector3 checkpointPosition;

    private void Start()
    {
        checkpointPosition = transform.position;
    }

    public void OnReset(InputAction.CallbackContext context)
    {
        //drop blocks
        blockHolder.DropAllBlocks();
        
        //reset blocks
        ResetAllBlocks();
        
        //reset player to last checkpoint
        CharacterController controller = GetComponent<CharacterController>();
        controller.enabled = false;
        transform.position = checkpointPosition;
        controller.enabled = true;
    }

    private void ResetAllBlocks()
    {
        ResetPosition[] blocks = FindObjectsOfType<ResetPosition>();
        foreach (ResetPosition block in blocks)
        {
            block.ResetValues();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            checkpointPosition = other.transform.position;
        }
    }
}
