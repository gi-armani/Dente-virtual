using UnityEngine;

public class DisableBoughtItems : MonoBehaviour
{
    public Wardrobe wardrobe = default;
    public bool setActive = false;
    [SerializeField] private Transform parent = default;
    

    private void OnEnable()
    {
        DisableItems();
    }

    public void DisableItems()
    {
        foreach(var item in wardrobe.WardrobeList)
        {
            if (item.has)
            {
                parent.Find(item.itemName)?.gameObject.SetActive(setActive);
            }
        }
    }
}
