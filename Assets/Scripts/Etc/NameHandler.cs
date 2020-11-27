using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button button;

    private void Awake()
    {
        inputField.onTouchScreenKeyboardStatusChanged.AddListener(ShowButton);
        inputField.onSelect.AddListener(arg0 => Debug.Log("testeee"));
    }

    private void ShowButton(TouchScreenKeyboard.Status tsk)
    {
        if(tsk == TouchScreenKeyboard.Status.Done)
            button.gameObject.SetActive(true);
    }
}
