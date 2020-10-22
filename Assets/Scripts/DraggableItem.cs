using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropable {
    public GenericInventory Inventory;
    public BarValues BarValues;
    private float fillQuantity = 0.2f;
    [SerializeField] private TextMeshProUGUI QuantityText = null;
    [SerializeField] private Image DragImage = null;

    private Camera _mainCamera = null;
    private bool isDragging;

    private void OnEnable()
    {
        QuantityText.text = "x" + Inventory.GetQuantity(gameObject.name);
    }

    private void Awake() 
    {
        _mainCamera = Camera.main;
        DragImage.raycastTarget = false;
    }

    public void UseItem() {
        if (Inventory.GetQuantity(gameObject.name) > 0) {
            Inventory.AddValue(gameObject.name, -1);
            QuantityText.text = "x" + Inventory.GetQuantity(gameObject.name);
            BarValues.AddFillPercentage(fillQuantity);
        }
    }

    public void OnBeginDrag(PointerEventData eventData) 
    {
        if(Inventory.GetQuantity(gameObject.name) > 0)
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

    public void OnDrop() => UseItem();
}