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

    Item item;

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

        itemDamage.text = "+" + item.damageModifier + " Damage";
        itemArmor.text = "+" + item.armorModifier + " Armor";
    }
}
