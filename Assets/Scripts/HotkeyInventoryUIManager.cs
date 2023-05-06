using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotkeyInventoryUIManager : MonoBehaviour
{
    public Inventory playerInventory;
    public Button[] hotkeyItemButtons;
    public Image[] hotkeyItemIconImages;
    public PlayerSkinManager playerSkinManager;
    private Dictionary<string, bool> equippedSkins = new Dictionary<string, bool>();

    private void Awake()
    {
        playerInventory.OnItemChanged += UpdateHotkeyInventoryUI;
        UpdateHotkeyInventoryUI(null);
    }

    private void Start()
    {
        UpdateHotkeyInventoryUI(null);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OnHotkey(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            OnHotkey(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            OnHotkey(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            OnHotkey(4);
        }
    }





    public void UpdateHotkeyInventoryUI(Item item)
    {
        for (int i = 0; i < hotkeyItemIconImages.Length; i++)
        {
            if (playerInventory.hotkeyItems[i] != null)
            {
                hotkeyItemIconImages[i].sprite = playerInventory.hotkeyItems[i].icon;
                hotkeyItemIconImages[i].enabled = true;
            }
            else
            {
                hotkeyItemIconImages[i].enabled = false;
            }
        }
    }

    private void OnHotkey(int hotkeyIndex)
    {
        Item hotkeyItem = playerInventory.hotkeyItems[hotkeyIndex - 1];
        Debug.Log($"Hotkey {hotkeyIndex} pressed");
        if (hotkeyItem != null && hotkeyItem.itemType == ItemType.Skin)
        {
            playerSkinManager.SetSkin(hotkeyItem.skinLayerIndex);
        }
    }


}

