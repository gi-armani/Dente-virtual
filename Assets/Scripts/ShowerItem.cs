using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowerItem : MonoBehaviour
{
    [SerializeField] private GameObject displayImage;
    [SerializeField] private GameObject checkImage;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowMove);
    }

    private void OnEnable()
    {
        checkImage?.SetActive(false);
        Image image = this.gameObject.GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = 1f;
        image.color = tempColor;
    }

    void ShowMove()
    {
        if (!checkImage.activeSelf)
        {
            BrushMovementHandler.DisplayImage(displayImage, checkImage, this.gameObject);
        }
    }
}
