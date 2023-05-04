using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Items/Clothing")]
public class Item : ScriptableObject
{
    public string itemName;
    public int price;
    public Sprite icon;
    public Sprite equippedSprite;
}

