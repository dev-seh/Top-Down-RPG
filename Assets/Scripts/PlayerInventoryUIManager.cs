using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInventoryUIManager : MonoBehaviour
{
    public GameObject itemSlotPrefab;
    public Transform playerItemContainer;
    public Inventory playerInventory;
    public Shop shop;
    public Currency playerCurrency;
    public TextMeshProUGUI itemNameTextPrefab;
    public TextMeshProUGUI itemPriceTextPrefab;
    public Item[] hotkeyItems;

    private void Awake()
    {
        hotkeyItems = new Item[4];
        playerInventory.OnItemChanged += UpdatePlayerInventoryUI;
    }

    private void Start()
    {
        UpdatePlayerInventoryUI(null);
    }

    private void UpdatePlayerInventoryUI(Item item)
    {
        // Clear previous items
        foreach (Transform child in playerItemContainer)
        {
            Destroy(child.gameObject);
        }

        // Populate player inventory UI
        foreach (Item playerItem in playerInventory.items)
        {
            CreatePlayerItemButton(playerItem);
        }
    }

    private void CreatePlayerItemButton(Item item)
    {
        GameObject itemButton = Instantiate(itemSlotPrefab, playerItemContainer.transform);
        itemButton.GetComponent<Image>().sprite = item.icon;
        itemButton.GetComponent<Button>().onClick.AddListener(() => SellItem(item));

        GameObject itemNameText = Instantiate(itemNameTextPrefab.gameObject, itemButton.transform);
        itemNameText.GetComponent<TextMeshProUGUI>().text = item.itemName;

        GameObject itemPriceText = Instantiate(itemPriceTextPrefab.gameObject, itemButton.transform);
        itemPriceText.GetComponent<TextMeshProUGUI>().text = "Sell for " + (item.price).ToString() + " gold";
    }


    public void SellItem(Item item)
    {
        shop.SellItem(item, playerInventory, playerCurrency);
        playerInventory.RemoveItem(item);
        playerInventory.RemoveItemFromHotkeyInventory(item);
        UpdatePlayerInventoryUI(item);
        FindObjectOfType<ShopUIManager>().PopulateShop();
        FindObjectOfType<HotkeyInventoryUIManager>().UpdateHotkeyInventoryUI(item);
    }

    
}

