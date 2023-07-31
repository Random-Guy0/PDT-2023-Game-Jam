using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetXYRotationToZero : MonoBehaviour
{
    private void Update()
    {
        Vector3 rotation = transform.rotation.eulerAngles;
        rotation.x = 0f;
        rotation.y = 0f;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
