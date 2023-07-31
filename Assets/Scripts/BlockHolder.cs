using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BlockHolder : MonoBehaviour
{
    private Block currentBlockToPickup;
    
    private Block topBlock;
    
    public void PickupBlock(InputAction.CallbackContext context)
    {
        if (context.performed && currentBlockToPickup != null)
        {
            if (topBlock == null)
            {
                topBlock = currentBlockToPickup;
                currentBlockToPickup = null;
                topBlock.Pickup(transform, transform.position + Vector3.up);
            }
        }
    }

    public void DropBlock(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (topBlock != null)
            {
                topBlock.Drop(transform.position, 1f);
                topBlock = topBlock.Parent;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (currentBlockToPickup == null)
        {
            currentBlockToPickup = other.GetComponent<Block>();
        }
    }

    public BlockType GetCurrentBlockPower()
    {
        return topBlock.BlockType;
    }
}
