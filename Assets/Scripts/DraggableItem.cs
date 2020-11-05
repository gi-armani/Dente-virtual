using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropable
{
    public Inventory Inventory;
    public BarValues BarValues;
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
        DragImage.sprite = GetComponent<Image>().sprite;
    }

    public void UseItem()
    {
        if (Inventory.GetQuantity(gameObject.name) > 0)
        {
            Inventory.AddValue(gameObject.name, -1);
            QuantityText.text = "x" + Inventory.GetQuantity(gameObject.name);
            BarValues.AddFillPercentage(Inventory.GetItem(gameObject.name).healAmount);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Inventory.GetQuantity(gameObject.name) > 0)
        {
            DragImage.gameObject.SetActive(true);
        }
        else
        {
            eventData.pointerDrag = null;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 position = _mainCamera.ScreenToWorldPoint(eventData.position);
        position.z = _mainCamera.transform.position.z + 1;
        DragImage.transform.position = position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragImage.transform.position = transform.position;
        DragImage.gameObject.SetActive(false);
    }

    public virtual void OnDrop()
    {
        UseItem();
    }
}