using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Instance
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }
    #endregion

    public int space = 20;
    public List<Item> items = new List<Item>();

    public delegate void ItemChange();
    public ItemChange OnItemChaged;

    public bool Add(Item item)
    {
        if(!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                print("Inventory Full");
                return false;
            }
            items.Add(item);
            OnItemChaged();
        }

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        OnItemChaged();
    }
}
