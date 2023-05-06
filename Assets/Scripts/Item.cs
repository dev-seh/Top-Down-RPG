using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Default,
    Skin
}

[CreateAssetMenu(fileName = "NewItem", menuName = "Items/Clothing")]
public class Item : ScriptableObject
{
    public string itemName;
    public int price;
    public Sprite icon;
    public Sprite equippedSprite;
    public ItemType itemType = ItemType.Default;
    public int skinLayerIndex = -1;
}



