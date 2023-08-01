using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class BlockHolder : MonoBehaviour
{
    private Block currentBlockToPickup;
    
    private Block topBlock;

    private int height = 0;
    
    public void PickupBlock(InputAction.CallbackContext context)
    {
        if (context.performed && currentBlockToPickup != null)
        {
            if (topBlock == null)
            {
                height = 1;
                topBlock = currentBlockToPickup;
                currentBlockToPickup = null;
                topBlock.Pickup(transform, transform.position + Vector3.up, height, BlockLayerAlignment.Center);
            }
            else
            {
                bool canPlaceLeft = true;
                bool canPlaceRight = true;

                Block currentBlock = topBlock;
                while (currentBlock != null && currentBlock.Height == height)
                {
                    if (currentBlock.LayerAlignment == BlockLayerAlignment.Left)
                    {
                        canPlaceLeft = false;
                    }
                    else if (currentBlock.LayerAlignment == BlockLayerAlignment.Right)
                    {
                        canPlaceRight = false;
                    }

                    currentBlock = currentBlock.Parent;
                }

                if (canPlaceLeft)
                {
                    StartCoroutine(WaitToPlaceLeft());
                }

                if (canPlaceRight)
                {
                    StartCoroutine(WaitToPlaceRight());
                }

                if (!canPlaceLeft && !canPlaceRight)
                {
                    PlaceTop();
                }
                else
                {
                    StartCoroutine(WaitToPlaceTop());
                }
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

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Block>().Equals(currentBlockToPickup))
        {
            currentBlockToPickup = null;
        }
    }

    public BlockType GetCurrentBlockPower()
    {
        return topBlock.BlockType;
    }

    private IEnumerator WaitForKeyDown(KeyControl key)
    {
        while (!key.wasPressedThisFrame)
        {
            yield return null;
        }
    }

    private IEnumerator WaitToPlaceLeft()
    {
        yield return WaitForKeyDown(Keyboard.current.leftArrowKey);

        Vector3 pickupPosition = transform.position + Vector3.up * height;
        pickupPosition.x -= 1;
        currentBlockToPickup.Pickup(transform, pickupPosition, height, BlockLayerAlignment.Left, topBlock);
        topBlock = currentBlockToPickup;
        currentBlockToPickup = null;
        
        StopAllCoroutines();
    }
    
    private IEnumerator WaitToPlaceRight()
    {
        yield return WaitForKeyDown(Keyboard.current.rightArrowKey);
        
        Vector3 pickupPosition = transform.position + Vector3.up * height;
        pickupPosition.x += 1;
        currentBlockToPickup.Pickup(transform, pickupPosition, height, BlockLayerAlignment.Right, topBlock);
        topBlock = currentBlockToPickup;
        currentBlockToPickup = null;
        
        StopAllCoroutines();
    }
    
    private IEnumerator WaitToPlaceTop()
    {
        yield return WaitForKeyDown(Keyboard.current.upArrowKey);

        PlaceTop();
        
        StopAllCoroutines();
    }

    private void PlaceTop()
    {
        height++;
        Vector3 pickupPosition = transform.position + Vector3.up * height;
        currentBlockToPickup.Pickup(transform, pickupPosition, height, BlockLayerAlignment.Center, topBlock);
        topBlock = currentBlockToPickup;
        currentBlockToPickup = null;
    }
}
