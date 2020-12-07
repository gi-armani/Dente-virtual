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
            cape.SetActive(true);
            cape.GetComponent<Image>().color = currentColor;
        }

        if (type == ClothesType.Armor)
        {
            GameObject armor = Dentinho.transform.Find("Armor").gameObject;
            armor.SetActive(true);
            armor.GetComponent<Image>().color = currentColor;
            
            Dentinho.transform.Find("ShortHair").gameObject.SetActive(false);
            Dentinho.transform.Find("LongHair").gameObject.SetActive(false);
        }

        if (type == ClothesType.ShortHair)
        {
            GameObject shortHair = Dentinho.transform.Find("ShortHair").gameObject;
            shortHair.SetActive(true);
            shortHair.GetComponent<Image>().color = currentColor;
            
            Dentinho.transform.Find("Armor").gameObject.SetActive(false);
            Dentinho.transform.Find("LongHair").gameObject.SetActive(false);
        }

        if (type == ClothesType.LongHair)
        {
            GameObject longHair = Dentinho.transform.Find("LongHair").gameObject;
            longHair.SetActive(true);
            longHair.GetComponent<Image>().color = currentColor;
            
            Dentinho.transform.Find("ShortHair").gameObject.SetActive(false);
            Dentinho.transform.Find("Armor").gameObject.SetActive(false);
        }
    }
}
