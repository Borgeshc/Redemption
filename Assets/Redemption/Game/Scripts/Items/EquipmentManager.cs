﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{
    #region Instance
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    [Header("Character Armor Locations")]
    public GameObject armorSlot;
    public GameObject glovesSlot;
    public GameObject bootsSlot;
    public GameObject weaponSlot;
    public GameObject shieldSlot;

    GameObject oldArmorSlot;
    GameObject oldGlovesSlot;
    GameObject oldBootsSlot;
    GameObject oldWeaponSlot;
    GameObject oldShieldSlot;

    [Space, Header("UI")]
    public GameObject equippedInfoPanel;
    public Text equippedItemName;
    public Text equippedItemDamage;
    public Text equippedItemArmor;

    public Equipment[] starterGear;

    Equipment[] currentEquipment;
    Inventory inventory;

    public delegate void EquipmentChange(Equipment newItem, Equipment oldItem);
    public EquipmentChange OnEquipmentChanged;

    private void Start()
    {
        inventory = Inventory.instance;

        int numberOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numberOfSlots];

        for (int i = 0; i < starterGear.Length; i++)
            Equip(starterGear[i]);
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

        switch (newItem.equipSlot)
        {
            case EquipmentSlot.Armor:
                if (oldArmorSlot != null)
                    oldArmorSlot.SetActive(false);

                oldArmorSlot = armorSlot.transform.Find(newItem.name).gameObject;
                oldArmorSlot.SetActive(true);

                break;
            case EquipmentSlot.Gloves:
                if (oldGlovesSlot != null)
                    oldGlovesSlot.SetActive(false);

                oldGlovesSlot = glovesSlot.transform.Find(newItem.name).gameObject;
                oldGlovesSlot.SetActive(true);
                break;
            case EquipmentSlot.Boots:
                if (oldBootsSlot != null)
                    oldBootsSlot.SetActive(false);

                oldBootsSlot = bootsSlot.transform.Find(newItem.name).gameObject;
                oldBootsSlot.SetActive(true);
                break;
            case EquipmentSlot.Weapon:
                if (oldWeaponSlot != null)
                    oldWeaponSlot.SetActive(false);

                oldWeaponSlot = weaponSlot.transform.Find(newItem.name).gameObject;
                oldWeaponSlot.SetActive(true);
                break;
            case EquipmentSlot.Shield:
                if (oldShieldSlot != null)
                    oldShieldSlot.SetActive(false);

                oldShieldSlot = shieldSlot.transform.Find(newItem.name).gameObject;
                oldShieldSlot.SetActive(true);
                break;
            default:
                break;
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

    public void CheckCurrentItemInSlot(Item itemInQuestion)
    {
        switch(itemInQuestion.equipSlot)
        {
            case EquipmentSlot.Armor:
                ShowStats(currentEquipment[0]);
                break;
            case EquipmentSlot.Gloves:
                ShowStats(currentEquipment[1]);
                break;
            case EquipmentSlot.Boots:
                ShowStats(currentEquipment[2]);
                break;
            case EquipmentSlot.Weapon:
                ShowStats(currentEquipment[3]);
                break;
            case EquipmentSlot.Shield:
                ShowStats(currentEquipment[4]);
                break;
            default:
                break;
        }
    }

    void ShowStats(Equipment item)
    {
        if (item == null) return;
        equippedInfoPanel.SetActive(true);
        equippedItemName.text = item.name;

        switch (item.ItemRarity)
        {
            case Item.Rarity.Common:
                equippedItemName.color = new Color32(70, 248, 0, 255);
                break;
            case Item.Rarity.Rare:
                equippedItemName.color = new Color32(0, 125, 248, 255);
                break;
            case Item.Rarity.Epic:
                equippedItemName.color = new Color32(162, 0, 248, 255);
                break;
            case Item.Rarity.Legendary:
                equippedItemName.color = new Color32(248, 118, 0, 255);
                break;
        }

        equippedItemDamage.text = "+" + item.damageModifier + " Damage";
        equippedItemArmor.text = "+" + item.armorModifier + " Armor";
    }

    public void DisablePanel()
    {
        equippedInfoPanel.SetActive(false);
    }
}
