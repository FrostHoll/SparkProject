using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public enum ItemType
{
    Consumable,
    NotConsumable,
}

public abstract class Item : MonoBehaviour
{ 
    public string itemName;
    public Sprite icon;
    public int maxStack = 1;
    public int currentStack = 1;
    public ItemType type;

    public ItemType GetItemType() { return type; }
    public abstract void ItemUse();
}
