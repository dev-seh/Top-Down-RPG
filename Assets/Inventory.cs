using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public Item equippedItem;
    public Sprite defaultPlayerSprite; // Add this field to store the default player sprite

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
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
            GetComponent<SpriteRenderer>().sprite = defaultPlayerSprite;
            equippedItem = null;
        }
    }
}



