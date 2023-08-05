using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHolderUI : MonoBehaviour
{
    [SerializeField] private GameObject pressArrowText;
    [SerializeField] private GameObject leftArrow;
    [SerializeField] private GameObject rightArrow;
    [SerializeField] private GameObject upArrow;

    public void DisableAll()
    {
        pressArrowText.SetActive(false);
        leftArrow.SetActive(false);
        rightArrow.SetActive(false);
        upArrow.SetActive(false);
    }

    public void EnableLeftArrow()
    {
        leftArrow.SetActive(true);
        pressArrowText.SetActive(true);
    }

    public void EnableRightArrow()
    {
        rightArrow.SetActive(true);
        pressArrowText.SetActive(true);
    }

    public void EnableUpArrow()
    {
        upArrow.SetActive(true);
        pressArrowText.SetActive(true);
    }
}
