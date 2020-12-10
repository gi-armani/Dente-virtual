using UnityEngine;

public class ShowIsEmptyMessage : MonoBehaviour
{
    [SerializeField] private Transform parent = default;
    [SerializeField] private GameObject text = default;

    private void OnEnable()
    {
        ShowMessage();
    }

    public void ShowMessage()
    {
        bool hasActiveChild = false;
        foreach (Transform child in parent)
        {
            if (child.gameObject.activeSelf)
            {
                hasActiveChild = true;
            }
        }

        if (!hasActiveChild)
            text.SetActive(true);
        else
            text.SetActive(false);
    }
}
