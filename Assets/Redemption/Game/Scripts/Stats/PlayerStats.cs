using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    private void Start()
    {
        EquipmentManager.instance.OnEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if(newItem != null)
        {
            armor.AddModifier(newItem.armorModifier);
            basicAttackDamageMin.AddModifier(newItem.damageModifier);
            basicAttackDamageMax.AddModifier(newItem.damageModifier);
            secondaryAttackDamageMin.AddModifier(newItem.damageModifier);
            secondaryAttackDamageMax.AddModifier(newItem.damageModifier);
        }

        if (oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            basicAttackDamageMin.RemoveModifier(oldItem.damageModifier);
            basicAttackDamageMax.RemoveModifier(oldItem.damageModifier);
            secondaryAttackDamageMin.RemoveModifier(oldItem.damageModifier);
            secondaryAttackDamageMax.RemoveModifier(oldItem.damageModifier);
        }
    }


    public override void Die()
    {
        base.Die();
        PlayerManager.instance.KillPlayer();
    }
}
