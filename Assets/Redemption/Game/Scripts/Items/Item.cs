using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public EquipmentSlot equipSlot;
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public float damage;
    public float armor;
    public float critChance;
    public float critDamage;
    public float maxHealth;
    public float healthRegen;
    public float maxMana;
    public float manaRegen;

    public enum Rarity
    {
        Common,             //1 Modifier
        Rare,               //2 Modifiers
        Epic,               //4 Modifiers
        Legendary           //6 Modifiers
    }

    public Rarity ItemRarity;

    public virtual void Use()
    {

    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
