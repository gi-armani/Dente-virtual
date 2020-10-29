using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class FillToothPaste : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent OnToothPasteDone = new UnityEvent();

    [SerializeField] private Transform toothPasteBall = null;
    [SerializeField] private float scaleAmountPerTime = 0.01f;
    [SerializeField] private float desiredScale = 0.5f;
    [SerializeField] private float maxScale = 1f;
    private bool _pointerDown = false;
    private Vector3 initialScale = Vector3.zero;
    private void Awake()
    {
        initialScale = toothPasteBall.localScale;
    }

    private void OnEnable() => toothPasteBall.localScale = initialScale;

    void Update()
    {
        if(_pointerDown)
        {
            toothPasteBall.localScale *= 1f + (scaleAmountPerTime * Time.deltaTime);
        }
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        _pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _pointerDown = false;
        OnToothPasteDone.Invoke();
    }

    // Nao pronta
    private bool VerifyScaleAmount()
    {
        return false;
    }
}
