using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyhole : MonoBehaviour
{
    [SerializeField] private Sprite unlockedSprite;
    [SerializeField] private GameObject keyholeBlockGameobject;
    [SerializeField] private float keyholeBlockScale = 0.5f;
    [SerializeField] private KeyRow[] blockPositions;

    private BoxCollider coll;

    public delegate void OnUnlock();

    public event OnUnlock onUnlock;
    
    public bool Locked { get; private set; }

    private void Start()
    {
        onUnlock += Unlock;
        Locked = true;
    }

    public void CreateKeyhole()
    {
        Vector3 scale = new Vector3(1f, blockPositions.Length * keyholeBlockScale * 1.5f, 1f);
        transform.localScale = scale;
        
        Vector3 blockScale = Vector3.one * keyholeBlockScale;
        blockScale.y /= scale.y;
        keyholeBlockGameobject.transform.localScale = blockScale;

        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
        
        for (int i = 0; i < blockPositions.Length; i++)
        {
            Vector3 position = i * keyholeBlockScale * 3f * Vector3.up;
            position += transform.position;
            position.y -= blockPositions.Length * keyholeBlockScale * 1.8f;

            if (blockPositions[i].center)
            {
                Instantiate(keyholeBlockGameobject, position, Quaternion.identity, transform);
            }
            
            if (blockPositions[i].left)
            {
                Vector3 leftPos = position;
                leftPos.x -= keyholeBlockScale * 3f;
                Instantiate(keyholeBlockGameobject, leftPos, Quaternion.identity, transform);
            }
            
            if (blockPositions[i].right)
            {
                Vector3 rightPos = position;
                rightPos.x += keyholeBlockScale * 3f;
                Instantiate(keyholeBlockGameobject, rightPos, Quaternion.identity, transform);
            }
        }
    }

    public bool CompareKey(Block topBlock)
    {

        Block currentBlock = topBlock;
        int currentHeight = currentBlock.Height;

        bool result = currentHeight == blockPositions.Length;

        while (currentBlock != null && result != false)
        {
            currentHeight = currentBlock.Height;
            Debug.Log(currentHeight);
            KeyRow currentRow = blockPositions[currentHeight - 1];
            if ((currentBlock.LayerAlignment == BlockLayerAlignment.Center && !currentRow.center) &&
                RowHasLayerAlignment(currentBlock, currentRow, BlockLayerAlignment.Center))
            {
                result = false;
                Debug.Log("CENTER " + currentHeight);
            }
            else if ((currentBlock.LayerAlignment == BlockLayerAlignment.Left && !currentRow.left) &&
                     RowHasLayerAlignment(currentBlock, currentRow, BlockLayerAlignment.Left))
            {
                result = false;
                Debug.Log("LEFT " + currentHeight);
            }
            else if ((currentBlock.LayerAlignment == BlockLayerAlignment.Right && !currentRow.right) &&
                     RowHasLayerAlignment(currentBlock, currentRow, BlockLayerAlignment.Right))
            {
                result = false;
                Debug.Log("RIGHT " + currentHeight);
            }

            if (result)
            {
                Debug.Log(currentBlock.LayerAlignment.ToString() + " " + currentHeight + " SUCCESS");
            }
            
            currentBlock = currentBlock.Parent;
        }

        if (result)
        {
            onUnlock();
        }
        
        return result;
    }

    private bool RowHasLayerAlignment(Block currentBlock, KeyRow currentRow, BlockLayerAlignment layerAlignment)
    {
        bool result = false;
        int currentHeight = currentBlock.Height;
        while (currentBlock != null && currentBlock.Height == currentHeight)
        {
            if (currentBlock.LayerAlignment == layerAlignment &&
                currentRow.GetRowPositionFromLayerAlignment(layerAlignment))
            {
                result = true;
                break;
            }

            currentBlock = currentBlock.Parent;
        }

        return result;
    }

    private void Unlock()
    {
        GetComponent<SpriteRenderer>().sprite = unlockedSprite;
    }
}

[System.Serializable]
public class KeyRow
{
    public bool left;
    public bool center;
    public bool right;

    public bool GetRowPositionFromLayerAlignment(BlockLayerAlignment layerAlignment)
    {
        switch (layerAlignment)
        {
            case BlockLayerAlignment.Center:
                return center;
            case BlockLayerAlignment.Left:
                return left;
            case BlockLayerAlignment.Right:
                return right;
            default:
                return center;
        }
    }
}
