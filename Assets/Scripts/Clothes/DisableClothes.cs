using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableClothes : MonoBehaviour{
    public Wardrobe wardrobe = default;
    private void OnEnable() {
        foreach (Transform child in transform){
            if(!wardrobe.PlayerHas(child.name)){
                child.gameObject.SetActive(false);
            }
        }
    }
}
