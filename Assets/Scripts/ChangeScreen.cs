using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScreen : MonoBehaviour
{
    public GameObject screenToOpen;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Change);
    }

    public void Change()
    {
        transform.parent.gameObject.SetActive(false);

        screenToOpen.SetActive(true);
    }
}
