using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class Medicine : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public IntVariable Quantity;
    [SerializeField] private TextMeshProUGUI QuantityText;
    [SerializeField] private Image DragImage;

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

    public void OnBeginDrag(PointerEventData eventData)
    {
        DragImage.gameObject.SetActive(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(eventData.position);
        position.z = 1;
        DragImage.transform.position = position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Verifica se está emcima do dentinho
        

        //Se sim, usa o remedio

        // "devolve" a imagem
        DragImage.transform.position = transform.position;
        DragImage.gameObject.SetActive(false);
    }
}
