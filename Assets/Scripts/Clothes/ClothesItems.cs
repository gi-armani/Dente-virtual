using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothesItems : MonoBehaviour
{
    public GameObject Dentinho;
    public enum ClothesType
    {
        ShortHair,
        LongHair,
        Cape,
        Armor,
    };
    public ClothesType type;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ChangeClothes);
    }

    public void ChangeClothes()
    {
        Color currentColor = GetComponent<Image>().color;

        if (type == ClothesType.Cape)
        {
            GameObject cape = Dentinho.transform.Find("Cape").gameObject;

            if (!cape.activeSelf)
            {
                cape.SetActive(true);
                cape.GetComponent<Image>().color = currentColor;
            }
            else
            {
                cape.SetActive(false);
            }
        }

        if (type == ClothesType.Armor)
        {
            GameObject armor = Dentinho.transform.Find("Armor").gameObject;

            if (!armor.activeSelf)
            {
                armor.SetActive(true);
                armor.GetComponent<Image>().color = currentColor;
            }
            else
            {
                armor.SetActive(false);
            }

            Dentinho.transform.Find("ShortHair").gameObject.SetActive(false);
            Dentinho.transform.Find("LongHair").gameObject.SetActive(false);
        }

        if (type == ClothesType.ShortHair)
        {
            GameObject shortHair = Dentinho.transform.Find("ShortHair").gameObject;

            if (!shortHair.activeSelf)
            {
                shortHair.SetActive(true);
                shortHair.GetComponent<Image>().color = currentColor;
            }
            else
            {
                shortHair.SetActive(false);
            }

            Dentinho.transform.Find("Armor").gameObject.SetActive(false);
            Dentinho.transform.Find("LongHair").gameObject.SetActive(false);
        }

        if (type == ClothesType.LongHair)
        {
            GameObject longHair = Dentinho.transform.Find("LongHair").gameObject;

            if (!longHair.activeSelf)
            {
                longHair.SetActive(true);
                longHair.GetComponent<Image>().color = currentColor;
            }
            else
            {
                longHair.SetActive(false);
            }

            Dentinho.transform.Find("ShortHair").gameObject.SetActive(false);
            Dentinho.transform.Find("Armor").gameObject.SetActive(false);
        }
    }
}
