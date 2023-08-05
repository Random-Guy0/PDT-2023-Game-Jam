using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private GameObject winText;
    [SerializeField] private Keyhole finalKeyhole;

    private void Start()
    {
        finalKeyhole.onUnlock += FinishLevel;
    }

    protected virtual void FinishLevel()
    {
        winText.SetActive(true);
    }
}
