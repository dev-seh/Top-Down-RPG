using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotkeyInventoryUIManager : MonoBehaviour
{
    public Inventory playerInventory;
    public Button[] hotkeyItemButtons;
    public Image[] hotkeyItemIconImages;

    private void Awake()
    {
        playerInventory.OnItemChanged += UpdateHotkeyInventoryUI;
        UpdateHotkeyInventoryUI(null);
    }
    
    private void Start()
    {
        UpdateHotkeyInventoryUI(null);
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


}

