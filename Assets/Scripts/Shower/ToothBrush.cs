using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;

public class ToothBrush : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject movingBrush;

    [SerializeField] private Camera mainCamera = null;
    [SerializeField] private FillToothPaste fillToothPaste = null;
    [SerializeField] private GameObject bubblePrefab = null;

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
        instantiateImage(movingBrush.transform.position);
    }

    private void OnCollisionEnter(Collision other)
    {
        // NÃO TA FUNCIONANDO
        if (other.gameObject.name == "Dente")
        {
            instantiateImage(movingBrush.transform.position);
        }
    }

    private void instantiateImage(Vector3 position)
    {
        var canvas = GameObject.Find("Canvas");
        // Instancia uma bubble na posição
        var screenToOpen = GameObject.Instantiate(bubblePrefab, position, Quaternion.identity, canvas.transform);
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
