using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake() 
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int inventorySpace = 20;
    public List<Item> items = new List<Item>();

    public bool AddItem(Item item)
    {
        if(!item.isDefaultItem)
        {
            if(items.Count >= inventorySpace)
            {
                Debug.Log("Not enough room.");
                return false;
            }
            items.Add(item);

            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);

        if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
