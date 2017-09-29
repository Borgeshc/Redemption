using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Instance
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;
    Inventory inventory;

    public delegate void EquipmentChange(Equipment newItem, Equipment oldItem);
    public EquipmentChange OnEquipmentChanged;

    private void Start()
    {
        inventory = Inventory.instance;

        int numberOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numberOfSlots];
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        Equipment oldItem = null;

        if(currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        OnEquipmentChanged(newItem, oldItem);
        currentEquipment[slotIndex] = newItem;
    }

    public void UnEquip(int slotIndex)
    {
        if(currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            OnEquipmentChanged(null, oldItem);
        }
    }

    public void UnEquipAll()
    {
        //This is currently not in use but here in case it is needed.
        for(int i = 0; i < currentEquipment.Length; i++)
        {
            UnEquip(i);
        }
    }
}
