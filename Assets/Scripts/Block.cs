using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Block : MonoBehaviour
{
    [field: SerializeField] public BlockType BlockType { get; private set; }

    [SerializeField] private Rigidbody rb;
    [SerializeField] private BoxCollider pickupTrigger;

    public Block Parent { get; private set; }
    
    public int Height { get; private set; }
    public BlockLayerAlignment LayerAlignment { get; private set; }

    public void Pickup(Transform playerTransform, Vector3 pickupPosition, int height, BlockLayerAlignment layerAlignment, Block parent = null)
    {
        rb.isKinematic = true;
        pickupTrigger.enabled = false;
        transform.position = pickupPosition;
        transform.rotation = Quaternion.identity;
        transform.parent = playerTransform;
        Height = height;
        LayerAlignment = layerAlignment;
        Parent = parent;
    }

    public void Drop(Vector3 playerPosition, float direction)
    {
        rb.isKinematic = false;
        pickupTrigger.enabled = true;
        transform.parent = null;
        Vector3 newPosition = playerPosition;
        newPosition.x += 1.5f * direction;
        transform.position = newPosition;
    }
}

public enum BlockLayerAlignment
{
    Left,
    Center,
    Right
}
