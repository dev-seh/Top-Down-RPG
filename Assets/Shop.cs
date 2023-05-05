using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Item[] itemsForSale;

    public bool BuyItem(Item item, Inventory playerInventory, Currency playerCurrency)
    {
        if (playerCurrency.gold >= item.price)
        {
            playerInventory.AddItem(item);
            playerCurrency.RemoveGold(item.price);
            return true;
        }
        return false;
    }

    public void SellItem(Item item, Inventory playerInventory, Currency playerCurrency)
    {
        playerInventory.RemoveItem(item);
        playerCurrency.AddGold(item.price);
    }
}


