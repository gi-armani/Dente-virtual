using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public FloatVariable FillPercentage;
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

    void UpdateFill() {
        Image img = fillBar.GetComponent<Image>();
        img.fillAmount = FillPercentage.Value;
    }

    // REFATORAR SE DER CERTO
    IEnumerator Decay() {
        isDecaying = true;
        yield return new WaitForSeconds(2f);
        FillPercentage.DecreaseValue(0.05f);
        UpdateFill();
        isDecaying = false;
    }
}
