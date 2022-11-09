using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();

        Pickup();
    }

    private void Pickup()
    {
        Debug.Log("Picking up: " + item.itemName);

        // If there is enough room in inventory.
        if(Inventory.instance.AddItem(item))
            Destroy(gameObject);
    }
}
