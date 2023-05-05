using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public List<Item> hotkeyItems = new List<Item>(new Item[4]);
    public Item equippedItem;

    public event System.Action<Item> OnItemChanged;

    public void AddItem(Item item)
    {
        items.Add(item);
        OnItemChanged?.Invoke(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        OnItemChanged?.Invoke(item);
    }

    public void EquipItem(Item item)
    {
        if (equippedItem != null)
        {
            UnequipItem();
        }
        equippedItem = item;
        // Replace player's sprite renderer with the equipped sprite
        GetComponent<SpriteRenderer>().sprite = item.equippedSprite;
    }

    public void UnequipItem()
    {
        if (equippedItem != null)
        {
            // Replace player's sprite renderer with the default sprite
            GetComponent<SpriteRenderer>().sprite = null; // Set this to your default player sprite
            equippedItem = null;
        }
    }

    public bool AddItemToHotkeyInventory(Item item)
    {
        for (int i = 0; i < hotkeyItems.Count; i++)
        {
            if (hotkeyItems[i] == null)
            {
                hotkeyItems[i] = item;
                Debug.Log("Item " + item.itemName + " added to hotkey slot " + (i + 1));
                OnItemChanged?.Invoke(item);
                return true;
            }
        }
        return false;
    }

        public void RemoveItemFromHotkeyInventory(Item item)
    {
        int index = hotkeyItems.IndexOf(item);
        if (index != -1)
        {
            hotkeyItems[index] = null;
            OnItemChanged?.Invoke(item);
        }
    }

}

