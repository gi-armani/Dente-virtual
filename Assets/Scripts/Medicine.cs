using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Medicine : MonoBehaviour, IPointerClickHandler {
    public IntVariable Quantity;
    public TextMeshProUGUI QuantityText;

    private void OnEnable() {
        QuantityText.text = "x" + Quantity.Value.ToString();
    }

    void Start() {
    }

    void Update() {
    }

    public void UseMedicine() {
        if (Quantity.Value > 0) {
            Quantity.DecreaseValue();
            QuantityText.text = "x" + Quantity.Value.ToString();
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        UseMedicine();
    }
}
