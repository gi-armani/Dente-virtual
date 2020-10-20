using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class Medicine : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropable {
    public IntVariable Quantity;
    public BarValues MedBarValues;
    private float healQuantity = 0.2f;
    [SerializeField] private TextMeshProUGUI QuantityText;
    [SerializeField] private Image DragImage;

    private Camera _mainCamera = null;
    private bool isDragging;

    private void OnEnable() {
        QuantityText.text = "x" + Quantity.Value.ToString();
    }

    private void Awake() {
        _mainCamera = Camera.main;
        DragImage.raycastTarget = false;
    }

    public void UseMedicine() {
        if (Quantity.Value > 0) {
            Quantity.DecreaseValue();
            QuantityText.text = "x" + Quantity.Value.ToString();
            MedBarValues.AddFillPercentage(healQuantity);
        }
    }

    public void OnBeginDrag(PointerEventData eventData) {
        if(Quantity.Value > 0)
        {
            DragImage.gameObject.SetActive(true);
        }
        else
        {
            eventData.pointerDrag = null;
        }
    }

    public void OnDrag(PointerEventData eventData) {
        Vector3 position = _mainCamera.ScreenToWorldPoint(eventData.position);
        position.z = _mainCamera.transform.position.z + 1;
        DragImage.transform.position = position;
    }

    public void OnEndDrag(PointerEventData eventData) {
        DragImage.transform.position = transform.position;
        DragImage.gameObject.SetActive(false);
    }

    public void OnDrop()
    {
        Debug.Log("is Dropping");
        UseMedicine();
    }
}