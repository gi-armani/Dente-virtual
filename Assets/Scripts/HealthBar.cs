using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public BarValues BarValues;

    GameObject fillBar;
    bool isDecaying = false;

    void Start() {
        fillBar = GameObject.FindWithTag("FillBar");
    }

    void Update() {
        if (!isDecaying) {
            StartCoroutine(Decay());
        }
    }

    public void UpdateFill() {
        Image img = fillBar.GetComponent<Image>();
        img.fillAmount = BarValues.FillPercentage;
    }

    IEnumerator Decay() {
        isDecaying = true;
        yield return new WaitForSeconds(BarValues.DecayCooldown);
        BarValues.AddFillPercentage(-BarValues.DecayQuantity);
        UpdateFill();
        isDecaying = false;
    }
}
