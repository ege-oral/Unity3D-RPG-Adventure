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

    public Equipment[] defaultItems;
    public SkinnedMeshRenderer targetMesh;
    Equipment[] currentEquipment;
    SkinnedMeshRenderer[] currentMeshes;

    public delegate void OnEquipmentChange(Equipment newItem, Equipment oldItem);
    public OnEquipmentChange onEquipmentChange;

    Inventory inventory;



    private void Start() 
    {
        inventory = Inventory.instance;
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
        currentMeshes = new SkinnedMeshRenderer[numSlots];

        EquipDefaultItem();
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }    
    }

    private void LateUpdate() 
    {
        SetEquipmentBlendShapes();
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int) newItem.equipSlot;

        Equipment oldItem = Unequip(slotIndex);
        

        if(onEquipmentChange != null)
        {
            onEquipmentChange.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem;

        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
        newMesh.transform.parent = targetMesh.transform;
        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        currentMeshes[slotIndex] = newMesh;
    }

    public Equipment Unequip(int slotIndex)
    {
        if(currentEquipment[slotIndex] != null)
        {
            if(currentMeshes[slotIndex] != null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }
            Equipment oldItem = currentEquipment[slotIndex];
            
            //SetEquipmentBlendShapes(oldItem, 0);
    
            inventory.AddItem(oldItem);
            currentEquipment[slotIndex] = null;
        
            if(onEquipmentChange != null)
            {
                onEquipmentChange.Invoke(null, oldItem);
            }
            return oldItem; 
        }
        return null;
    }

    public void UnequipAll()
    {
        for(int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
        EquipDefaultItem();
    }

    public void SetEquipmentBlendShapes()
    {
        foreach(Equipment equipment in currentEquipment)
        {
            if(equipment != null)
            {
                foreach(EquipmentMeshRegion equipmentMeshRegion in equipment.coveredMeshRegions)
                {
                    targetMesh.SetBlendShapeWeight((int)equipmentMeshRegion, 100f);
                }
            }
        }
    }

    public void EquipDefaultItem()
    {
        foreach(Equipment item in defaultItems)
        {
            Equip(item);
        }
    }
}
