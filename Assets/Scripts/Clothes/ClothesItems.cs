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
        Color clickedColor = GetComponent<Image>().color;

        if (type == ClothesType.Cape)
        {
            GameObject cape = Dentinho.transform.Find("Cape").gameObject;
            Color currentWearingColor = cape.GetComponent<Image>().color;

            if(currentWearingColor == clickedColor)
            {
                if (!cape.activeSelf)
                {
                    cape.SetActive(true);
                    cape.GetComponent<Image>().color = clickedColor;
                }
                else
                {
                    cape.SetActive(false);
                }
            }
            else
            {
                cape.SetActive(true);
                cape.GetComponent<Image>().color = clickedColor;
            }
        }

        if (type == ClothesType.Armor)
        {
            GameObject armor = Dentinho.transform.Find("Armor").gameObject;
            Color currentWearingColor = armor.GetComponent<Image>().color;

            if(currentWearingColor == clickedColor)
            {
                if (!armor.activeSelf)
                {
                    armor.SetActive(true);
                    armor.GetComponent<Image>().color = clickedColor;
                }
                else
                {
                    armor.SetActive(false);
                }
            }
            else
            {
                armor.SetActive(true);
                armor.GetComponent<Image>().color = clickedColor;
            }

            Dentinho.transform.Find("ShortHair").gameObject.SetActive(false);
            Dentinho.transform.Find("LongHair").gameObject.SetActive(false);
        }

        if (type == ClothesType.ShortHair)
        {
            GameObject shortHair = Dentinho.transform.Find("ShortHair").gameObject;
            Color currentWearingColor = shortHair.GetComponent<Image>().color;

            if(currentWearingColor == clickedColor)
            {
                if (!shortHair.activeSelf)
                {
                    shortHair.SetActive(true);
                    shortHair.GetComponent<Image>().color = clickedColor;
                }
                else
                {
                    shortHair.SetActive(false);
                }
            } 
            else
            {
                shortHair.SetActive(true);
                shortHair.GetComponent<Image>().color = clickedColor;
            }

            Dentinho.transform.Find("Armor").gameObject.SetActive(false);
            Dentinho.transform.Find("LongHair").gameObject.SetActive(false);
        }

        if (type == ClothesType.LongHair)
        {
            GameObject longHair = Dentinho.transform.Find("LongHair").gameObject;
            Color currentWearingColor = longHair.GetComponent<Image>().color;

            if(currentWearingColor == clickedColor)
            {
                if (!longHair.activeSelf)
                {
                    longHair.SetActive(true);
                    longHair.GetComponent<Image>().color = clickedColor;
                }
                else
                {
                    longHair.SetActive(false);
                }
            }
            else
            {
                longHair.SetActive(true);
                longHair.GetComponent<Image>().color = clickedColor;
            }

            Dentinho.transform.Find("ShortHair").gameObject.SetActive(false);
            Dentinho.transform.Find("Armor").gameObject.SetActive(false);
        }
    }
}
