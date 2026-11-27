using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject slotPrefab;
    public int slotCount = 21;
    public GameObject[] itemPrefabs;

    private GameObject[] slots;

    void Start()
    {
        slots = new GameObject[slotCount];
        for (int i = 0; i < slotCount; i++)
        {
            GameObject slot = Instantiate(slotPrefab, inventoryPanel.transform);
            slots[i] = slot;
        }
    }

    public bool AddItem(GameObject itemPrefab)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount == 0)
            {
                GameObject item = Instantiate(itemPrefab, slots[i].transform);
                RectTransform rect = item.GetComponent<RectTransform>();
                rect.anchorMin = new Vector2(0.5f, 0.5f);
                rect.anchorMax = new Vector2(0.5f, 0.5f);
                rect.pivot = new Vector2(0.5f, 0.5f);
                rect.anchoredPosition = Vector2.zero;
                return true;
            }
        }
        return false;
    }
}
