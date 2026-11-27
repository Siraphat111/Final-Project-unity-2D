using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject slotPrefab;
    public int slotCount;
    public GameObject[] itemPrefabs;

    void Start()
    {
        if (inventoryPanel == null || slotPrefab == null)
        {
            Debug.LogWarning("[Inventory] inventoryPanel or slotPrefab is not assigned in Inspector.");
            return;
        }

        if (inventoryPanel.GetComponent<LayoutGroup>() == null)
        {
            GridLayoutGroup grid = inventoryPanel.AddComponent<GridLayoutGroup>();
            grid.cellSize = new Vector2(100f, 100f);
            grid.spacing = new Vector2(15f, 15f);
            grid.padding = new RectOffset(20, 20, 20, 20);
        }

        for (int i = 0; i < slotCount; i++)
        {
            GameObject slotObj = Instantiate(slotPrefab, inventoryPanel.transform);
            slotObj.transform.localScale = Vector3.one;

            Slot slot = slotObj.GetComponent<Slot>();
            if (slot == null)
            {
                slot = slotObj.AddComponent<Slot>();
            }

            if (itemPrefabs != null && i < itemPrefabs.Length && itemPrefabs[i] != null)
            {
                GameObject item = Instantiate(itemPrefabs[i], slot.transform);
                item.transform.localScale = Vector3.one;

                RectTransform itemRect = item.GetComponent<RectTransform>();
                if (itemRect != null)
                {
                    itemRect.anchoredPosition3D = Vector3.zero;
                }

                slot.currentItem = item;
            }

        }
    }
    public bool AddItem(GameObject itemPrefab)
    {
        if (itemPrefab == null || inventoryPanel == null) return false;

        foreach (Transform slotTransform in inventoryPanel.transform)
        {
            Slot slot = slotTransform.GetComponent<Slot>();
            if (slot != null && slot.currentItem == null)
            {
                GameObject newItem = Instantiate(itemPrefab, slot.transform);
                newItem.transform.localScale = Vector3.one;

                RectTransform rect = newItem.GetComponent<RectTransform>();
                if (rect != null)
                {
                    rect.anchoredPosition3D = Vector3.zero;
                }

                slot.currentItem = newItem;
                return true;
            }
        }
        Debug.Log("Inventory is full.");
        return false;
    }
}
