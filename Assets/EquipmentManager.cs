using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance { get; private set; }

    private void Awake() 
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }  
        else
        {
            instance = this;
        }
    }
    #endregion

    Equipment[] currentEquipment;

    public delegate void OnEquipmentChange(Equipment newItem, Equipment oldItem);
    public OnEquipmentChange onEquipmentChange;

    Inventory inventory;

    private void Start() 
    {
        inventory = Inventory.instance;
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }    
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int) newItem.equipSlot;

        Equipment oldItem = null;
        
        if(currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.AddItem(oldItem);
        }

        if(onEquipmentChange != null)
        {
            onEquipmentChange.Invoke(newItem, oldItem);
        }
        
        currentEquipment[slotIndex] = newItem;
        
    }

    public void Unequip(int slotIndex)
    {
        if(currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.AddItem(oldItem);
            currentEquipment[slotIndex] = null;
        
            if(onEquipmentChange != null)
            {
                onEquipmentChange.Invoke(null, oldItem);
            }
        }
        
    }

    public void UnequipAll()
    {
        for(int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }
}
