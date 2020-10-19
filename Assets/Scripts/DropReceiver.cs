using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropReceiver : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        IDropable droppedObject = null;
        if(eventData.pointerDrag.TryGetComponent<IDropable>(out droppedObject))
        {
            droppedObject.OnDrop();
        }
    }
}
