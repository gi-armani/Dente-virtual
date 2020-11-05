using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpressionControl : MonoBehaviour
{
    public Bar MainBar;

    public Sprite VeryHappySprite;
    public Sprite HappySprite;
    public Sprite NeutralSprite;
    public Sprite SadSprite;
    public Sprite VerySadSprite;

    //public float VeryHappyUpperLimit = 0.30f;
    public float HappyUpperLimit = 0.80f;
    public float NeutralUpperLimit = 0.60f;
    public float SadUpperLimit = 0.40f;
    public float VerySadUpperLimit = 0.20f;

    Image dentinhoImage;

    private void Start()
    {
        dentinhoImage = GetComponent<Image>();
    }

    public void Update()
    {
        ChangeDentinho();
    }

    public void ChangeDentinho()
    {
        float MainBarFill = MainBar.CalculateFillAmount();

        if (MainBarFill < VerySadUpperLimit)
        {
            dentinhoImage.sprite = VerySadSprite;
        }
        else if (MainBarFill < SadUpperLimit)
        {
            dentinhoImage.sprite = SadSprite;
        }
        else if (MainBarFill < NeutralUpperLimit)
        {
            dentinhoImage.sprite = NeutralSprite;
        }
        else if (MainBarFill < HappyUpperLimit)
        {
            dentinhoImage.sprite = HappySprite;
        }
        else
        {
            dentinhoImage.sprite = VeryHappySprite;
        }
    }
}
