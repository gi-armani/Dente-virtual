using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrushMovementHandler : MonoBehaviour
{
    static GameObject lastActive;

    public static void DisplayImage(GameObject image)
    {
        lastActive?.SetActive(false);
        image?.SetActive(true);

        lastActive = image;
    }

    public void OnDisable()
    {
        lastActive?.SetActive(false);
    }
}
