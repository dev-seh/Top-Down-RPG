using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperInteraction : MonoBehaviour
{
    public GameObject shopUI;
    public GameObject playerInventoryUI;
    public GameObject playerGoldText;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            shopUI.SetActive(true);
            playerInventoryUI.SetActive(true);
            playerGoldText.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            shopUI.SetActive(false);
            playerInventoryUI.SetActive(false);
            playerGoldText.SetActive(false);
        }
    }

    public void CloseShop()
    {
        shopUI.SetActive(false);
        playerInventoryUI.SetActive(false);
        playerGoldText.SetActive(false);
    }
}
