using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Item[] itemsForSale;

    public void BuyItem(Item item, Inventory playerInventory)
    {
        playerInventory.AddItem(item);
    }

    public void SellItem(Item item, Inventory playerInventory)
    {
        playerInventory.RemoveItem(item);
    }
}

