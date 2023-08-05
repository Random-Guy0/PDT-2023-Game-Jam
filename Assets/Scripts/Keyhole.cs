using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyhole : MonoBehaviour
{
    [field: SerializeField] public bool DestroyBlocks { get; private set; } = true;
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
        //onUnlock += method; to attach allow a method to be executed when the keyhole unlocks
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

        while (currentBlock != null && result)
        {
            currentHeight = currentBlock.Height;
            KeyRow currentRow = blockPositions[currentHeight - 1];
            Block[] blockRow = GetBlockRow(currentBlock);
            bool containsCenter = BlockRowContainsLayerAlignment(blockRow, BlockLayerAlignment.Center);
            bool containsLeft = BlockRowContainsLayerAlignment(blockRow, BlockLayerAlignment.Left);
            bool containsRight = BlockRowContainsLayerAlignment(blockRow, BlockLayerAlignment.Right);
            if ((containsCenter && !currentRow.center) || (!containsCenter && currentRow.center))
            {
                result = false;
            }
            
            if ((containsLeft && !currentRow.left) || (!containsLeft && currentRow.left))
            {
                result = false;
            }
            if ((containsRight && !currentRow.right) || (!containsRight && currentRow.right))
            {
                result = false;
            }
            
            currentBlock = blockRow[^1].Parent;
        }

        if (result)
        {
            onUnlock();
        }
        
        return result;
    }

    private Block[] GetBlockRow(Block currentBlock)
    {
        List<Block> result = new List<Block>();
        int currentHeight = currentBlock.Height;
        while (currentBlock != null && currentBlock.Height == currentHeight)
        {
            result.Add(currentBlock);
            currentBlock = currentBlock.Parent;
        }

        return result.ToArray();
    }

    private bool BlockRowContainsLayerAlignment(Block[] blockRow, BlockLayerAlignment layerAlignment)
    {
        bool result = false;

        foreach (Block block in blockRow)
        {
            if (block.LayerAlignment == layerAlignment)
            {
                result = true;
                break;
            }
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
