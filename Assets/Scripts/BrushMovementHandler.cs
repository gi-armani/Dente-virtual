using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrushMovementHandler : MonoBehaviour
{
    [SerializeField] private BarValues showerBar;
    private float healQuantity;
    static GameObject lastActiveMovement;
    static GameObject lastCheck;
    static GameObject lastUsedIcon;

    public static void DisplayImage(GameObject movementImage, GameObject checkImage, GameObject iconImage)
    {
        lastActiveMovement?.SetActive(false);
        movementImage?.SetActive(true);

        lastActiveMovement = movementImage;
        lastCheck = checkImage;
        lastUsedIcon = iconImage;
    }

    public void OnEnable()
    {
        MovementTrigger.FinishedMovement += CleanTooth;
        healQuantity = (1 - showerBar.getFillPercentage()) / 4;
    }

    public void OnDisable()
    {
        MovementTrigger.FinishedMovement -= CleanTooth;
        lastActiveMovement?.SetActive(false);
    }

    public void CleanTooth()
    {
        lastCheck?.SetActive(true);
        changeIconAlpha();
        showerBar.AddFillPercentage(healQuantity);
        
    }

    private void changeIconAlpha()
    {
        Image image = lastUsedIcon.GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = .3f;
        image.color = tempColor;
    }
}
