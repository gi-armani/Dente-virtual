using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClotheItems : MonoBehaviour
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
        Dentinho.transform.Find("Cape").gameObject.SetActive(false);
        Dentinho.transform.Find("Armor").gameObject.SetActive(false);
        Dentinho.transform.Find("ShortHair").gameObject.SetActive(false);
        Dentinho.transform.Find("LongHair").gameObject.SetActive(false);

        if (type == ClothesType.Cape) Dentinho.transform.Find("Cape").gameObject.SetActive(true);
        if (type == ClothesType.Armor) Dentinho.transform.Find("Armor").gameObject.SetActive(true);
        if (type == ClothesType.ShortHair) Dentinho.transform.Find("ShortHair").gameObject.SetActive(true);
        if (type == ClothesType.LongHair) Dentinho.transform.Find("LongHair").gameObject.SetActive(true);

    }
}
