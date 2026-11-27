using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public string Name;
    public GameObject itemPrefab;
    public virtual void Pickup()
    {
        // Implement pickup logic here
    }
}
