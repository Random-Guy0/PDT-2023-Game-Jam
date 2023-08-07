using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class BlockHolder : MonoBehaviour
{
    [SerializeField] private BlockHolderUI ui;
    
    private Block currentBlockToPickup;
    private Keyhole currentKeyhole;

    public Block TopBlock { get; private set; }

    private int height = 0;

    private GameObject blockParent;

    private void Start()
    {
        blockParent = new GameObject("Block Parent");
        blockParent.transform.SetParent(transform);
    }

    private void Update()
    {
        if (currentBlockToPickup == null)
        {
            StopAllCoroutines();
            ui.DisableAll();
        }
    }

    public void PickupBlock(InputAction.CallbackContext context)
    {
        if (context.performed && currentBlockToPickup != null)
        {
            if (TopBlock == null)
            {
                height = 1;
                TopBlock = currentBlockToPickup;
                currentBlockToPickup = null;
                TopBlock.Pickup(blockParent.transform, transform.position + Vector3.up, height, BlockLayerAlignment.Center);
            }
            else
            {
                bool canPlaceLeft = true;
                bool canPlaceRight = true;

                Block currentBlock = TopBlock;
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
            if (TopBlock != null)
            {
                TopBlock.Drop(transform.position, 1f);
                TopBlock = TopBlock.Parent;

                if (TopBlock != null)
                {
                    height = TopBlock.Height;
                }
                else
                {
                    height = 0;
                }
            }
        }
    }

    public void DropAllBlocks()
    {
        height = 0;
        while (TopBlock != null)
        {
            TopBlock.Drop(transform.position, 1f);
            TopBlock = TopBlock.Parent;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Block otherBlock = other.GetComponent<Block>();
        if (currentBlockToPickup == null || (currentBlockToPickup != null && otherBlock != null &&
                                             Vector3.Distance(transform.position, otherBlock.transform.position) <
                                             Vector3.Distance(transform.position,
                                                 currentBlockToPickup.transform.position)))
        {
            currentBlockToPickup = otherBlock;
        }

        Keyhole otherKeyhole = other.GetComponent<Keyhole>();
        if (currentKeyhole == null || (currentKeyhole != null && otherKeyhole != null &&
                                       Vector3.Distance(transform.position, otherKeyhole.transform.position) <
                                       Vector3.Distance(transform.position,
                                           currentKeyhole.transform.position)))
        {
            currentKeyhole = otherKeyhole;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Block otherBlock = other.GetComponent<Block>();
        if (otherBlock != null && otherBlock.Equals(currentBlockToPickup))
        {
            currentBlockToPickup = null;
        }

        Keyhole otherKeyhole = other.GetComponent<Keyhole>();
        if (otherKeyhole != null && otherKeyhole.Equals(currentKeyhole))
        {
            currentKeyhole = null;
        }
    }

    public BlockType GetCurrentBlockPower()
    {
        if (TopBlock != null)
        {
            return TopBlock.BlockType;
        }
        else
        {
            return BlockType.Default;
        }
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
        ui.EnableLeftArrow();
        yield return WaitForKeyDown(Keyboard.current.leftArrowKey);

        if (currentBlockToPickup != null)
        {
            Vector3 pickupPosition = transform.position + Vector3.up * height;
            pickupPosition.x -= 1;
            currentBlockToPickup.Pickup(blockParent.transform, pickupPosition, height, BlockLayerAlignment.Left,
                TopBlock);
            TopBlock = currentBlockToPickup;
            currentBlockToPickup = null;
        }

        StopAllCoroutines();
        ui.DisableAll();
    }

    private IEnumerator WaitToPlaceRight()
    {
        ui.EnableRightArrow();
        yield return WaitForKeyDown(Keyboard.current.rightArrowKey);

        if (currentBlockToPickup != null)
        {
            Vector3 pickupPosition = transform.position + Vector3.up * height;
            pickupPosition.x += 1;
            currentBlockToPickup.Pickup(blockParent.transform, pickupPosition, height, BlockLayerAlignment.Right,
                TopBlock);
            TopBlock = currentBlockToPickup;
            currentBlockToPickup = null;
        }

        StopAllCoroutines();
        ui.DisableAll();
    }

    private IEnumerator WaitToPlaceTop()
    {
        ui.EnableUpArrow();
        yield return WaitForKeyDown(Keyboard.current.upArrowKey);

        if (currentBlockToPickup != null)
        {
            PlaceTop();
        }

        StopAllCoroutines();
        ui.DisableAll();
    }

    private void PlaceTop()
    {
        height++;
        Vector3 pickupPosition = transform.position + Vector3.up * height;
        currentBlockToPickup.Pickup(blockParent.transform, pickupPosition, height, BlockLayerAlignment.Center, TopBlock);
        TopBlock = currentBlockToPickup;
        currentBlockToPickup = null;
    }

    public void UseKey(InputAction.CallbackContext context)
    {
        if (context.performed && currentKeyhole != null && currentKeyhole.Locked)
        {
            if (TopBlock != null && currentKeyhole.CompareKey(TopBlock) && currentKeyhole.DestroyBlocks)
            {
                for (int i = 0; i < blockParent.transform.childCount; i++)
                {
                    Destroy(blockParent.transform.GetChild(i).gameObject);
                }
            }
        }
    }
}