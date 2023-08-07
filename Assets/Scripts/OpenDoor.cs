using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Keyhole keyhole;
    [SerializeField] private float doorHeightOffset;
    [SerializeField] private float doorOpenSpeed;

    private void Start()
    {
        keyhole.onUnlock += StartOpenDoor;
    }

    private void StartOpenDoor()
    {
        StartCoroutine(LerpOpenDoor());
    }

    private IEnumerator LerpOpenDoor()
    {
        Vector3 initialPosition = transform.position;
        while (transform.position.y < initialPosition.y + doorHeightOffset)
        {
            Vector3 position = transform.position;
            position.y += doorOpenSpeed * Time.deltaTime;
            transform.position = position;
            yield return null;
        }
    }
}
