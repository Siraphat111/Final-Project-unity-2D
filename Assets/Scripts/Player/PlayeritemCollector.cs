using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeritemCollector : MonoBehaviour
{
    private Inventory inventory;

    void Start()
    {
        inventory = FindAnyObjectByType<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            if (inventory == null)
            {
                inventory = FindAnyObjectByType<Inventory>();
                if (inventory == null) return;
            }

            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                GameObject prefabToAdd = item.itemPrefab != null ? item.itemPrefab : item.gameObject;
                bool itemAdded = inventory.AddItem(prefabToAdd);
                if (itemAdded)
                {
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
