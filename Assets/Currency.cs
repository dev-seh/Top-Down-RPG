using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public int gold;

    private void Start()
    {
        gold = 50; // Initial gold
    }

    public void AddGold(int amount)
    {
        gold += amount;
    }

    public void RemoveGold(int amount)
    {
        gold -= amount;
    }
}

