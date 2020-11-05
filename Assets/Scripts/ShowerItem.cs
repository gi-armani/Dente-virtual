using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowerItem : MonoBehaviour
{
    [SerializeField] private GameObject displayImage;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowMove);
    }

    void ShowMove()
    {
        BrushMovementHandler.DisplayImage(displayImage);
    }
}
