using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public int gold;


    public void AddGold(int amount)
    {
        gold += amount;
    }

    public void RemoveGold(int amount)
    {
        gold -= amount;
    }
}

