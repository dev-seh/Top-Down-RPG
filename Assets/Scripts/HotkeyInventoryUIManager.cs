using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotkeyInventoryUIManager : MonoBehaviour
{
    public Inventory playerInventory;
    public Image[] hotkeyItemImages;

    private void Start()
    {
        playerInventory.OnItemChanged += UpdateHotkeyInventoryUI;
        UpdateHotkeyInventoryUI(null);
    }

    private void UpdateHotkeyInventoryUI(Item item)
    {
        for (int i = 0; i < hotkeyItemImages.Length; i++)
        {
            if (playerInventory.hotkeyItems[i] != null)
            {
                hotkeyItemImages[i].sprite = playerInventory.hotkeyItems[i].icon;
                hotkeyItemImages[i].enabled = true;
            }
            else
            {
                hotkeyItemImages[i].enabled = false;
            }
        }
    }
}

