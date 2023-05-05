using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUIManager : MonoBehaviour
{
    public GameObject itemPrefab;
    public GameObject itemContainer;
    public Shop shop;
    public Inventory playerInventory;
    public Currency playerCurrency;

    public TextMeshProUGUI itemNameTextPrefab;
    public TextMeshProUGUI itemPriceTextPrefab;
    public TextMeshProUGUI playerGoldText;

    private void Start()
    {
        PopulateShop();
    }

    public void PopulateShop()
    {
        //Clear shop UI
        foreach (Transform child in itemContainer.transform){
            Destroy(child.gameObject);
        }
        //Populate the shop UI with items that are not in the player's inventory

        for (int i = 0; i < shop.itemsForSale.Count; i++)
        {
            Item item = shop.itemsForSale[i];
            
            if(!playerInventory.items.Contains(item))
            {
                CreateItemButton(item);
            }
        }
    }

    private void CreateItemButton(Item item)
    {
        GameObject itemButton = Instantiate(itemPrefab, itemContainer.transform);
        itemButton.GetComponent<Image>().sprite = item.icon;
        itemButton.GetComponent<Button>().onClick.AddListener(() => BuyItem(item));

        GameObject itemNameText = Instantiate(itemNameTextPrefab.gameObject, itemButton.transform);
        itemNameText.GetComponent<TextMeshProUGUI>().text = item.itemName;

        GameObject itemPriceText = Instantiate(itemPriceTextPrefab.gameObject, itemButton.transform);
        itemPriceText.GetComponent<TextMeshProUGUI>().text = "Buy for " + item.price.ToString() + " gold";
    }

    public void BuyItem(Item item)
    {
        bool success = shop.BuyItem(item, playerInventory, playerCurrency);
        if (success)
        {
            playerInventory.EquipItem(item);
            playerInventory.AddItemToHotkeyInventory(item);
            PopulateShop();
        }
    }

        private void Update()
    {
        playerGoldText.text = "Your Gold: " + playerCurrency.gold.ToString();
    }
}



