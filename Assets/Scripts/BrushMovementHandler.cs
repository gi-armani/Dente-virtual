using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrushMovementHandler : MonoBehaviour
{
    [SerializeField] private BarValues showerBar;
    [SerializeField] private float healQuantity = 0.25f;
    static GameObject lastActive;
    static GameObject lastCheck;

    public static void DisplayImage(GameObject movementImage, GameObject checkImage)
    {
        lastActive?.SetActive(false);
        movementImage?.SetActive(true);

        lastActive = movementImage;
        lastCheck = checkImage;
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
        lastCheck?.SetActive(true);
        showerBar.AddFillPercentage(healQuantity);
        
    }

}
