using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    public Image removeButtonImage;
    public Image removeButtonBackground;

    public GameObject itemInfoPanel;
    public Text itemName;

    public Text itemDamage;
    public Text itemArmor;
    public Text itemCritChance;
    public Text itemCritDamage;
    public Text itemMaxHealth;
    public Text itemHealthRegen;
    public Text itemMaxMana;
    public Text itemManaRegen;

    EquipmentManager equipmentManager;

    Item item;

    private void Start()
    {
        equipmentManager = transform.root.GetComponent<EquipmentManager>();
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;

        removeButtonBackground.enabled = true;
        removeButtonImage.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;

        removeButtonBackground.enabled = false;
        removeButtonImage.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
            item.Use();
    }   

    public void RetrieveItemInfo()
    {
        if (item == null) return;
        itemInfoPanel.SetActive(true);
        itemName.text = item.name;

        switch(item.ItemRarity)
        {
            case Item.Rarity.Common:
                itemName.color = new Color32(70, 248, 0, 255);
                break;
            case Item.Rarity.Rare:
                itemName.color = new Color32(0,125,248,255);
                break;
            case Item.Rarity.Epic:
                itemName.color = new Color32(162, 0, 248, 255);
                break;
            case Item.Rarity.Legendary:
                itemName.color = new Color32(248, 118, 0, 255);
                break;
        }

        SetActiveCorrectStats();

        itemDamage.text = "+" + item.damage + " Damage";
        itemArmor.text = "+" + item.armor + " Armor";
        itemCritChance.text = "+" + item.critChance + " Crit Chance";
        itemCritDamage.text = "+" + item.critDamage + " Crit Damage";
        itemMaxHealth.text = "+" + item.maxHealth + " Max Health";
        itemHealthRegen.text = "+" + item.healthRegen + " Health Regen";
        itemMaxMana.text = "+" + item.maxMana + " Max Mana";
        itemManaRegen.text = "+" + item.manaRegen + " Mana Regen";

        equipmentManager.CheckCurrentItemInSlot(item);
    }

    void SetActiveCorrectStats()
    {
        if (item.damage != 0)
            itemDamage.gameObject.SetActive(true);
        else
            itemDamage.gameObject.SetActive(false);

        if (item.armor != 0)
            itemArmor.gameObject.SetActive(true);
        else
            itemArmor.gameObject.SetActive(false);

        if (item.critChance != 0)
            itemCritChance.gameObject.SetActive(true);
        else
            itemCritChance.gameObject.SetActive(false);

        if (item.critDamage != 0)
            itemCritDamage.gameObject.SetActive(true);
        else
            itemCritDamage.gameObject.SetActive(false);

        if (item.maxHealth != 0)
            itemMaxHealth.gameObject.SetActive(true);
        else
            itemMaxHealth.gameObject.SetActive(false);

        if (item.healthRegen != 0)
            itemHealthRegen.gameObject.SetActive(true);
        else
            itemHealthRegen.gameObject.SetActive(false);

        if (item.maxMana != 0)
            itemMaxMana.gameObject.SetActive(true);
        else
            itemMaxMana.gameObject.SetActive(false);

        if (item.manaRegen != 0)
            itemManaRegen.gameObject.SetActive(true);
        else
            itemManaRegen.gameObject.SetActive(false);
    }
}
