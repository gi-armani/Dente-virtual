using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopClothesItems : MonoBehaviour
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

    private bool isWearingShortHair;
    private bool isWearingLongHair;
    private bool isWearingCape;
    private bool isWearingArmor;
    private Color capeColor;
    private Color armorColor;
    private Color shortHairColor;
    private Color longHairColor;
    
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(TryOutfit);
    }

    private void OnEnable()
    {
        GameObject cape = Dentinho.transform.Find("Cape").gameObject;
        GameObject armor = Dentinho.transform.Find("Armor").gameObject;
        GameObject longHair = Dentinho.transform.Find("LongHair").gameObject;
        GameObject shortHair = Dentinho.transform.Find("ShortHair").gameObject;
        
        
        if (cape.activeSelf)
        {
            isWearingCape = true;
            capeColor = cape.GetComponent<Image>().color;
        }
        
        if (armor.activeSelf)
        {
            isWearingArmor = true;
            armorColor = armor.GetComponent<Image>().color;
        }
        
        if (longHair.activeSelf)
        {
            isWearingLongHair = true;
            longHairColor = longHair.GetComponent<Image>().color;
        }
        
        if (shortHair.activeSelf)
        {
            isWearingShortHair = true;
            shortHairColor = shortHair.GetComponent<Image>().color;
        }
    }

    private void OnDisable()
    {
        isWearingArmor = false;
        isWearingCape = false;
        isWearingLongHair = false;
        isWearingShortHair = false;
    }

    public void TryOutfit()
    {
        Color clickedColor = GetComponent<Image>().color;
        
        if (type == ClothesType.Cape)
        {
            if(!isWearingArmor)
                Dentinho.transform.Find("Armor").gameObject.SetActive(false);
            else
            {
                Dentinho.transform.Find("Armor").gameObject.SetActive(true);
                Dentinho.transform.Find("Armor").gameObject.GetComponent<Image>().color = armorColor;
            }
            
            if(!isWearingLongHair)
                Dentinho.transform.Find("LongHair").gameObject.SetActive(false);
            else
            {
                Dentinho.transform.Find("LongHair").gameObject.SetActive(true);
                Dentinho.transform.Find("LongHair").gameObject.GetComponent<Image>().color = longHairColor;
            }
            
            if(!isWearingShortHair)
                Dentinho.transform.Find("ShortHair").gameObject.SetActive(false);
            else
            {
                Dentinho.transform.Find("ShortHair").gameObject.SetActive(true);
                Dentinho.transform.Find("ShortHair").gameObject.GetComponent<Image>().color = shortHairColor;
            }
            
            GameObject cape = Dentinho.transform.Find("Cape").gameObject;
            Color currentWearingColor = cape.GetComponent<Image>().color;

            if(isWearingCape)
            {
                if (clickedColor != currentWearingColor)
                    cape.GetComponent<Image>().color = clickedColor;
                else
                    cape.GetComponent<Image>().color = capeColor;
            }
            else
            {
                if (cape.activeSelf)
                {
                    if (currentWearingColor != clickedColor)
                        cape.GetComponent<Image>().color = clickedColor;
                    else
                        cape.SetActive(false);
                }
                else
                {
                    cape.SetActive(true);
                    cape.GetComponent<Image>().color = clickedColor;
                }
            }
        }
        
        if (type == ClothesType.Armor)
        {
            Dentinho.transform.Find("LongHair").gameObject.SetActive(false);
            Dentinho.transform.Find("ShortHair").gameObject.SetActive(false);
            if(!isWearingCape)
                Dentinho.transform.Find("Cape").gameObject.SetActive(false);
            else
            {
                Dentinho.transform.Find("Cape").gameObject.SetActive(true);
                Dentinho.transform.Find("Cape").gameObject.GetComponent<Image>().color = capeColor;
            }
            
            GameObject armor = Dentinho.transform.Find("Armor").gameObject;
            Color currentWearingColor = armor.GetComponent<Image>().color;

            if(isWearingArmor)
            {
                if (clickedColor != currentWearingColor)
                    armor.GetComponent<Image>().color = clickedColor;
                else
                    armor.GetComponent<Image>().color = armorColor;
            }
            else
            {
                if (armor.activeSelf)
                {
                    if (currentWearingColor != clickedColor)
                        armor.GetComponent<Image>().color = clickedColor;
                    else
                    {
                        armor.SetActive(false);
                        
                        if (isWearingLongHair)
                        {
                            Dentinho.transform.Find("LongHair").gameObject.SetActive(true);
                            Dentinho.transform.Find("LongHair").gameObject.GetComponent<Image>().color = longHairColor;
                        }
                        
                        if (isWearingShortHair)
                        {
                            Dentinho.transform.Find("ShortHair").gameObject.SetActive(true);
                            Dentinho.transform.Find("ShortHair").gameObject.GetComponent<Image>().color = shortHairColor;
                        }
                    }
                }
                else
                {
                    armor.SetActive(true);
                    armor.GetComponent<Image>().color = clickedColor;
                }
            }
        }
        
        if (type == ClothesType.ShortHair)
        {
            Dentinho.transform.Find("LongHair").gameObject.SetActive(false);
            Dentinho.transform.Find("Armor").gameObject.SetActive(false);
            if(!isWearingCape)
                Dentinho.transform.Find("Cape").gameObject.SetActive(false);
            else
            {
                Dentinho.transform.Find("Cape").gameObject.SetActive(true);
                Dentinho.transform.Find("Cape").gameObject.GetComponent<Image>().color = capeColor;
            }

            GameObject shortHair = Dentinho.transform.Find("ShortHair").gameObject;
            Color currentWearingColor = shortHair.GetComponent<Image>().color;

            if(isWearingShortHair)
            {
                if (clickedColor != currentWearingColor)
                    shortHair.GetComponent<Image>().color = clickedColor;
                else
                    shortHair.GetComponent<Image>().color = shortHairColor;
            }
            else
            {
                if (shortHair.activeSelf)
                {
                    if (currentWearingColor != clickedColor)
                        shortHair.GetComponent<Image>().color = clickedColor;
                    else
                    {
                        shortHair.SetActive(false);
                        
                        if (isWearingArmor)
                        {
                            Dentinho.transform.Find("Armor").gameObject.SetActive(true);
                            Dentinho.transform.Find("Armor").gameObject.GetComponent<Image>().color = armorColor;
                        }

                        if (isWearingLongHair)
                        {
                            Dentinho.transform.Find("LongHair").gameObject.SetActive(true);
                            Dentinho.transform.Find("LongHair").gameObject.GetComponent<Image>().color = longHairColor;
                        }
                    }
                }
                else
                {
                    shortHair.SetActive(true);
                    shortHair.GetComponent<Image>().color = clickedColor;
                }
            }
        }
        
        if (type == ClothesType.LongHair)
        {
            Dentinho.transform.Find("ShortHair").gameObject.SetActive(false);
            Dentinho.transform.Find("Armor").gameObject.SetActive(false);
            if(!isWearingCape)
                Dentinho.transform.Find("Cape").gameObject.SetActive(false);
            else
            {
                Dentinho.transform.Find("Cape").gameObject.SetActive(true);
                Dentinho.transform.Find("Cape").gameObject.GetComponent<Image>().color = capeColor;
            }
            
            GameObject longHair = Dentinho.transform.Find("LongHair").gameObject;
            Color currentWearingColor = longHair.GetComponent<Image>().color;

            if(isWearingLongHair)
            {
                if (clickedColor != currentWearingColor)
                    longHair.GetComponent<Image>().color = clickedColor;
                else
                    longHair.GetComponent<Image>().color = longHairColor;
            }
            else
            {
                if (longHair.activeSelf)
                {
                    if (currentWearingColor != clickedColor)
                        longHair.GetComponent<Image>().color = clickedColor;
                    else
                    {
                        longHair.SetActive(false);
                        if (isWearingShortHair)
                        {
                            Dentinho.transform.Find("ShortHair").gameObject.SetActive(true);
                            Dentinho.transform.Find("ShortHair").gameObject.GetComponent<Image>().color = shortHairColor;
                        }

                        if (isWearingArmor)
                        {
                            Dentinho.transform.Find("Armor").gameObject.SetActive(true);
                            Dentinho.transform.Find("Armor").gameObject.GetComponent<Image>().color = armorColor;
                        }
                    }
                        
                }
                else
                {
                    longHair.SetActive(true);
                    longHair.GetComponent<Image>().color = clickedColor;
                }
            }
        }
    }
}
