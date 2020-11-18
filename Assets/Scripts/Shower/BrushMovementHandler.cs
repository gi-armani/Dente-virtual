using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrushMovementHandler : MonoBehaviour
{
    [SerializeField] private BarValues showerBar = default;
    [SerializeField] private Resources resources = default;
    private float healQuantity;
    static GameObject lastActiveMovement;
    static GameObject lastCheck;
    static GameObject lastUsedIcon;
    int movementsFinished = 0;

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
        movementsFinished = 0;
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
        resources.AddMoney(50);
        lastCheck?.SetActive(true);
        changeIconAlpha();
        showerBar.AddFillPercentage(healQuantity);
        movementsFinished++;
    }

    private void changeIconAlpha()
    {
        Image image = lastUsedIcon.GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = .3f;
        image.color = tempColor;
    }
}
