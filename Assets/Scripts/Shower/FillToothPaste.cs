using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class FillToothPaste : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent OnToothPasteDone = new UnityEvent();

    [Header("References")]
    [SerializeField] private Transform toothPasteBall = null;
    [Header("Scale settings")]
    [SerializeField] private float scaleAmountPerTime = 0.01f;
    [SerializeField] private float desiredScale = 0.5f;
    [SerializeField] private float maxScale = 1f;
    [Header("Money Resource")]
    [SerializeField] private Resources money = null;
    [SerializeField] private int moneyAmount = 10;

    private bool _pointerDown = false;
    private Vector3 initialScale = Vector3.zero;
    private void Awake()
    {
        initialScale = toothPasteBall.localScale;
    }

    private void OnEnable()
    {
        _pointerDown = false;
        toothPasteBall.localScale = initialScale;
    }

    void Update()
    {
        if (_pointerDown && toothPasteBall.localScale.magnitude < maxScale)
        {
            toothPasteBall.localScale *= 1f + (scaleAmountPerTime * Time.deltaTime);
        }
    }

    public Vector3 GetToothPasteScale()
    {
        return toothPasteBall.localScale;
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        _pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _pointerDown = false;
        OnToothPasteDone.Invoke();
        if (VerifyScaleAmount())
        {
            money.AddMoney(moneyAmount);
        }
    }

    public bool VerifyScaleAmount()
    {
        float threshold = 0.03f;
        bool biggerThan = (toothPasteBall.localScale.x >= desiredScale - threshold);
        bool lowerThan = (toothPasteBall.localScale.x <= desiredScale + threshold);
        Debug.Log($"scale{toothPasteBall.localScale.x}|desired{desiredScale}: {biggerThan && lowerThan}");
        return biggerThan && lowerThan;
    }
}
