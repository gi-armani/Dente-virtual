using UnityEngine;
using UnityEngine.Events;

public class UnityEventInvoker : MonoBehaviour
{
    public UnityEvent MyEvent = new UnityEvent();

    public void Invoke() => MyEvent?.Invoke();

    public void AddListener(UnityAction actionCall) => MyEvent.AddListener(actionCall);
}