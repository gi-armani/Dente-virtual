using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToothBrush : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject movingBrush;

    [SerializeField] private Camera mainCamera = null;
    [SerializeField] private FillToothPaste fillToothPaste = null;

    private Vector3 _initialPosition = Vector3.zero;
    public static Action ReleasedToothBrush;

    private void Start()
    {
        _initialPosition = movingBrush.transform.position;
    }

    private void OnEnable()
    {
        Vector3 toothPasteScale = fillToothPaste.GetToothPasteScale();
        Transform toothPasteBall = movingBrush.transform.Find("ToothPasteBall");
        toothPasteBall.localScale = toothPasteScale;
    }

    public void ShowImage()
    {
        movingBrush.SetActive(true);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 position = mainCamera.ScreenToWorldPoint(eventData.position);
        // position.z = mainCamera.transform.position.z + 1;
        position.z = 5;
        movingBrush.transform.position = position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        movingBrush.transform.position = _initialPosition;
        ReleasedToothBrush?.Invoke();
    }

    public void OnDisable()
    {
        movingBrush.SetActive(false);
    }

}