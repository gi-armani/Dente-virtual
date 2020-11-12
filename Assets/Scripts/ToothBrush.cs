using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToothBrush : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Camera mainCamera = null;
    //[SerializeField] private Image toothBrush = null;

    private Vector3 _initialPosition = Vector3.zero;

    public GameObject movingBrush;

    private void Start()
    {
        _initialPosition = movingBrush.transform.position;
    }

    public void ShowImage()
    {
        movingBrush.SetActive(true);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 position = mainCamera.ScreenToWorldPoint(eventData.position);
        position.z = mainCamera.transform.position.z + 1;
        movingBrush.transform.position = position;
        Debug.Log("Dragging");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        movingBrush.transform.position = _initialPosition;
    }

    public void OnDisable()
    {
        movingBrush.SetActive(false);
    }

}