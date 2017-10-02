using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public int passiveManaGen;
    public int passiveHealthGen;

    bool regening;

    private void Start()
    {
        EquipmentManager.instance.OnEquipmentChanged += OnEquipmentChanged;
    }

    private void Update()
    {
        if(!regening)
        {
            regening = true;
            StartCoroutine(PassiveRegen());
        }
    }

    IEnumerator PassiveRegen()
    {
        yield return new WaitForSeconds(1);
        GainMana(passiveManaGen);
        GainHealth(passiveHealthGen);
        regening = false;
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
