using UnityEngine;
using UnityEngine.UI;

public class HorizontalArrowPanel : MonoBehaviour
{
    [SerializeField] private RectTransform canvas = null;
    [SerializeField] private int visibleItemCount = 1;

    private RectTransform[] children = null;
    private RectTransform scrollView = null;

    private void Awake()
    {
        scrollView = transform.Find("ScrollView").GetComponent<RectTransform>();
        children = scrollView.GetComponentsInChildren<RectTransform>();
    }

    private void Start()
    {
        SetViewWidth();
    }
    
    [ContextMenu("Recalculate View Width")]
    private void SetViewWidth()
    {
        if (scrollView.childCount == 0)
            return;

        // Set scrollView Width
        int itemBlockNum = (Mathf.CeilToInt(scrollView.childCount / (float)visibleItemCount) - 1);
        float width = canvas.rect.width * itemBlockNum;
        scrollView.sizeDelta = new Vector2(width, scrollView.sizeDelta.y);
        
        // Set Children width
        float childWidth = (canvas.rect.width / visibleItemCount);
        for(int i = 1; i < children.Length; i++)
        {
            children[i].sizeDelta = new Vector2(childWidth, children[i].sizeDelta.y);
        }

        // TODO: Set Child Spacing Here
    }
}
