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

    private Camera _mainCamera = null;

    private void OnEnable() {
        QuantityText.text = "x" + Quantity.Value.ToString();
    }

    private void Awake()
    {
        _mainCamera = Camera.main;
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
        //UseMedicine();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        DragImage.gameObject.SetActive(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 position = _mainCamera.ScreenToWorldPoint(eventData.position);
        position.z = 1;
        DragImage.transform.position = position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Verifica se está emcima do dentinho
        Ray screenPointRay = _mainCamera.ScreenPointToRay(eventData.position);
        RaycastHit hitInfo = default;
        Debug.Log(screenPointRay + "origin: " + screenPointRay.origin);
        screenPointRay.origin = new Vector3(screenPointRay.origin.x, screenPointRay.origin.y, transform.position.z);
        //Se sim, usa o remedio
        if(Physics.Raycast(screenPointRay, out hitInfo))
        {
            UseMedicine();
        }
        Debug.Log(hitInfo.point);


        // "devolve" a imagem
        DragImage.transform.position = transform.position;
        DragImage.gameObject.SetActive(false);
    }
}
