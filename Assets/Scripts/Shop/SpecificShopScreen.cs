using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class SpecificShopScreen : MonoBehaviour
{
    public GameObject dentinho;
    private float inicialYPosition;
    private float inicialXScale;
    private float inicialYScale;

    [SerializeField] private GameObject Cape = default;
    [SerializeField] private GameObject Armor = default;
    [SerializeField] private GameObject ShortHair = default;
    [SerializeField] private GameObject LongHair = default;
    
    private bool isCapeActive = false;
    private bool isArmorActive = false;
    private bool isLongHairActive = false;
    private bool isShortHairActive = false;

    private Color capeColor;
    private Color armorColor;
    private Color longHairColor;
    private Color shortHairColor;

    void OnEnable()
    {
        inicialYPosition = dentinho.transform.position.y;
        inicialXScale = dentinho.transform.localScale.x;
        inicialYScale = dentinho.transform.localScale.y;

        dentinho.transform.position = new Vector3(dentinho.transform.position.x, 2, dentinho.transform.position.z);
        dentinho.transform.localScale = new Vector3(dentinho.transform.localScale.x * .6f, dentinho.transform.localScale.y * .6f, dentinho.transform.localScale.z);

        dentinho.transform.Find("Stage").gameObject.SetActive(true);
        dentinho.transform.Find("Light").gameObject.SetActive(true);

        VerifyClothes();
    }

    private void VerifyClothes()
    {
        if (Cape.activeSelf)
        {
            isCapeActive = true;
            capeColor = Cape.GetComponent<Image>().color;
        }
        else
        {
            isCapeActive = false;
        }

        if (Armor.activeSelf)
        {
            isArmorActive = true;
            armorColor = Armor.GetComponent<Image>().color;
        }
        else
        {
            isArmorActive = false;
        }

        if (ShortHair.activeSelf)
        {
            isShortHairActive = true;
            shortHairColor = ShortHair.GetComponent<Image>().color;
        }
        else
        {
            isShortHairActive = false;
        }

        if (LongHair.activeSelf)
        {
            isLongHairActive = true;
            longHairColor = LongHair.GetComponent<Image>().color;
        }
        else
        {
            isLongHairActive = false;
        }
    }

    void OnDisable()
    {
        dentinho.transform.position = new Vector3(dentinho.transform.position.x, inicialYPosition, dentinho.transform.position.z);
        dentinho.transform.localScale = new Vector3(inicialXScale, inicialYScale, dentinho.transform.localScale.z);

        dentinho.transform.Find("Stage").gameObject.SetActive(false);
        dentinho.transform.Find("Light").gameObject.SetActive(false);

        VerifyClothesWhenDisableScreen();
    }

    private void VerifyClothesWhenDisableScreen()
    {
        if (isCapeActive)
        {
            Cape.SetActive(true);
            Cape.GetComponent<Image>().color = capeColor;
        }
        else
        {
            Cape.SetActive(false);
        }

        if (isArmorActive)
        {
            Armor.SetActive(true);
            Armor.GetComponent<Image>().color = armorColor;
        }
        else
        {
            Armor.SetActive(false);
        }

        if (isShortHairActive)
        {
            ShortHair.SetActive(true);
            ShortHair.GetComponent<Image>().color = shortHairColor;
        }
        else
        {
            ShortHair.SetActive(false);
        }

        if (isLongHairActive)
        {
            LongHair.SetActive(true);
            LongHair.GetComponent<Image>().color = longHairColor;
        }
        else
        {
            LongHair.SetActive(false);
        }
    }
}
