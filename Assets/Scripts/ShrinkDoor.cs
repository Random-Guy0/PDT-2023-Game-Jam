using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkDoor : MonoBehaviour
{
    public Vector3 twinDoorLocation;

    private PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.GetSiblingIndex() == 1)
        {
            twinDoorLocation = transform.parent.transform.GetChild(0).position;
        }
        else
        {
            twinDoorLocation = transform.parent.transform.GetChild(1).position;
        }

        twinDoorLocation = new Vector3(twinDoorLocation.x, twinDoorLocation.y, twinDoorLocation.z - 1);

        playerMovement = GameObject.Find("Character with block systems").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            if (playerMovement.isShrinking == true)
            {
                playerMovement.isShrinking = false;
                Debug.Log("shrinking to " + twinDoorLocation);
                playerMovement.gameObject.GetComponent<CharacterController>().enabled = false;
                playerMovement.gameObject.transform.position = twinDoorLocation;
                playerMovement.gameObject.GetComponent<CharacterController>().enabled = true;
            }
        }
    }
}
