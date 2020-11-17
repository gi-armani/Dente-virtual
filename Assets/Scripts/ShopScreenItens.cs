using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScreenItens : MonoBehaviour
{
    public GameObject dentinho;
    private float inicialYPosition;
    private float inicialXScale;
    private float inicialYScale;

    void OnEnable()
    {
        inicialYPosition = dentinho.transform.position.y;
        inicialXScale = dentinho.transform.localScale.x;
        inicialYScale = dentinho.transform.localScale.y;

        dentinho.transform.position = new Vector3(dentinho.transform.position.x, 2, dentinho.transform.position.z);
        dentinho.transform.localScale = new Vector3(dentinho.transform.localScale.x * .6f, dentinho.transform.localScale.y * .6f, dentinho.transform.localScale.z);

        dentinho.transform.Find("Stage").gameObject.SetActive(true);
        dentinho.transform.Find("Light").gameObject.SetActive(true);
    }

    void OnDisable()
    {
        dentinho.transform.position = new Vector3(dentinho.transform.position.x, inicialYPosition, dentinho.transform.position.z);
        dentinho.transform.localScale = new Vector3(inicialXScale, inicialYScale, dentinho.transform.localScale.z);

        dentinho.transform.Find("Stage").gameObject.SetActive(false);
        dentinho.transform.Find("Light").gameObject.SetActive(false);
    }
}
