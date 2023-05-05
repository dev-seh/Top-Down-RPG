using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperInteraction : MonoBehaviour
{
    public GameObject shopUI;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            shopUI.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            shopUI.SetActive(false);
        }
    }

    public void CloseShop()
    {
        shopUI.SetActive(false);
    }
}
