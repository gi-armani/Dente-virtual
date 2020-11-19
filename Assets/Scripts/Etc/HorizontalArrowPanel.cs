using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HorizontalArrowPanel : MonoBehaviour
{
    [SerializeField] private RectTransform canvas = null;
    [SerializeField] private int visibleItemCount = 1;

    private RectTransform[] children = null;
    private RectTransform scrollView = null;
    private Button leftArrow = null;
    private Button rightArrow = null;

    private void Awake()
    {
        scrollView = transform.Find("ScrollView").GetComponent<RectTransform>();
        leftArrow = transform.Find("LeftArrow").GetComponent<Button>();
        rightArrow = transform.Find("RightArrow").GetComponent<Button>();

        leftArrow.onClick.AddListener(MoveViewToLeft);
        rightArrow.onClick.AddListener(MoveViewToRight);

        PopulateChildrenArray();
    }

    private void PopulateChildrenArray()
    {
        children = new RectTransform[scrollView.childCount];
        int i = 0;
        foreach(Transform child in scrollView)
        {
            children[i] = child.GetComponent<RectTransform>();
            i++;
        }
    }

    private void Start()
    {
        RecalculateHorizontalLayout();
    }
    
    private void SetScrollViewWidth()
    {
        if (scrollView.childCount == 0)
            return;

        int itemBlockNum = (Mathf.CeilToInt(scrollView.childCount / (float)visibleItemCount) - 1);
        float width = canvas.rect.width * itemBlockNum;
        scrollView.sizeDelta = new Vector2(width, scrollView.sizeDelta.y);
        
    }

    private void SetChildrenWidthAndPosition()
    {
        if (scrollView.childCount == 0)
            return;
        
        float childWidth = (canvas.rect.width / visibleItemCount);
        float anchoredPositionX = childWidth / 2;
        for(int i = 0; i < children.Length; i++)
        {
            children[i].sizeDelta = new Vector2(childWidth, scrollView.rect.height);
            children[i].anchoredPosition = new Vector2(anchoredPositionX, -scrollView.rect.height / 2);
            anchoredPositionX += childWidth;
        }
    }

    private void MoveViewToLeft()
    {
        float positionX = scrollView.anchoredPosition.x + canvas.rect.width;
        positionX = Mathf.Clamp(positionX, -scrollView.sizeDelta.x, 0f);
        scrollView.anchoredPosition = new Vector2(positionX, scrollView.anchoredPosition.y);
    }

    private void MoveViewToRight()
    {
        
        float positionX = scrollView.anchoredPosition.x - canvas.rect.width;
        positionX = Mathf.Clamp(positionX, -scrollView.sizeDelta.x, 0f);
        scrollView.anchoredPosition = new Vector2(positionX, scrollView.anchoredPosition.y);
    }

    public void RecalculateHorizontalLayout()
    {
        SetScrollViewWidth();
        SetChildrenWidthAndPosition();
    }

    [ContextMenu("Recalculate View Width")]
    private void EditorSetViewWidth()
    {
        scrollView = transform.Find("ScrollView").GetComponent<RectTransform>();
        leftArrow = transform.Find("LeftArrow").GetComponent<Button>();
        rightArrow = transform.Find("RightArrow").GetComponent<Button>();
        
        PopulateChildrenArray();
        
        RecalculateHorizontalLayout();
    }
}
