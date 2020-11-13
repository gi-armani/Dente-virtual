using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrushMovementHandler : MonoBehaviour
{
    [SerializeField] private BarValues showerBar;
    [SerializeField] private float healQuantity = 0.25f;
    static GameObject lastActive;

    public static void DisplayImage(GameObject image)
    {
        lastActive?.SetActive(false);
        image?.SetActive(true);

        lastActive = image;
    }

    public void OnEnable()
    {
        MovementTrigger.FinishedMovement += CleanTooth;
    }

    public void OnDisable()
    {
        MovementTrigger.FinishedMovement -= CleanTooth;
        lastActive?.SetActive(false);
    }

    public void CleanTooth()
    {
        showerBar.AddFillPercentage(healQuantity);
    }

}
